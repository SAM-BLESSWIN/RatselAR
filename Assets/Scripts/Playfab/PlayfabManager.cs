using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    [SerializeField]
    private GameObject rowprefab;
    [SerializeField]
    private Transform rowparent;
    [SerializeField]
    private TMP_Text messagetext;
    [SerializeField]
    private InputField usernameinput;
    [SerializeField]
    private InputField emailinput;
    [SerializeField]
    private InputField pwdinput;
    [SerializeField]
    private GameObject namewindow;
    [SerializeField]
    private GameObject leaderboardwindow;

    private void Start()
    {
        login();
    }

    private void login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, Onerror);
    }

    public void Sendlevel(int level)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
               new StatisticUpdate
               {
                   StatisticName="Level Progress",
                    Value = level
               }
            }   
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, Onsuccessupdate, Onerror);
    }

    private void Onsuccessupdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("User statistics updated");
    }

    public void Getleaderboardstats()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Level Progress",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, Getresult, Onerror);
    }

    private void Getresult(GetLeaderboardResult result)
    {
        foreach(Transform item in rowparent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in result.Leaderboard)
        {
            GameObject newgo = Instantiate(rowprefab, rowparent);
            TMP_Text[] texts = newgo.GetComponentsInChildren<TMP_Text>();
            int pos = item.Position + 1;
            texts[0].text = pos.ToString();
            texts[1].text = item.PlayFabId;
            texts[2].text = item.StatValue.ToString();

            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }

    public void Register()
    {
        if(pwdinput.text.Length <6)
        {
            messagetext.text = "Password too short";
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = emailinput.text,
            Password = pwdinput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, Onregistersucccess, Onerror);
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailinput.text,
            Password = pwdinput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, Onerror);
    }

    public void Resetpwd()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email=emailinput.text,
            TitleId= "823BE",
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request,Onpwdreset,Onerror);
    }

    private void Onregistersucccess(RegisterPlayFabUserResult result)
    {
        messagetext.text = "Registered and logged in!";
    }

    private void OnLoginSuccess(LoginResult result)
    {
       // messagetext.text = "Logged in";
        Debug.Log("Congratulations, you made your first successful API call!");
        int l = PlayerPrefs.GetInt("levelsunlocked");
        Sendlevel(l + 1);

        string name = null;
        if(result.InfoResultPayload.PlayerProfile !=null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }

        if(name==null)
        {
            namewindow.SetActive(true);
        }
        else
        {
            leaderboardwindow.SetActive(true);
        }
    }

    private void Onpwdreset(SendAccountRecoveryEmailResult result)
    {
        messagetext.text = "Password reset mail sent";
    }

    public void Submitname()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = usernameinput.text
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, Onnameset, Onerror);
    }

    private void Onnameset(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("updated display name");
        leaderboardwindow.SetActive(true);
    }

    private void Onerror(PlayFabError error)
    {
        messagetext.text = error.ErrorMessage;
        Debug.LogError(error.GenerateErrorReport());
    }
}
