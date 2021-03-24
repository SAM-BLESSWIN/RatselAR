using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    private string emailinput;
    private string pwdinput;
    private string conpwdinput;
    private string nameinput;

    [SerializeField]
    private TMP_Text messagetext;
    [SerializeField]
    private GameObject rowprefab;
    [SerializeField]
    private Transform rowparent;
    [SerializeField]
    private GameObject login;
    [SerializeField]
    private GameObject register;
    [SerializeField]
    private GameObject reset;
    [SerializeField]
    private GameObject leaderbdicon;
    [SerializeField]
    private GameObject logicon;
    [SerializeField]
    private GameObject gameicon;
    [SerializeField]
    private GameObject logouticon;

    private void Start()
    {
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            Login();
        }
    }

    public void Getusername(string usernameIn)
    {
        nameinput = usernameIn;
    }
    public void GetUsermailid(string usermailidIn)
    {
        emailinput = usermailidIn;
    }
    public void Getuserpassword(string passwordIn)
    {
        pwdinput = passwordIn;
    }
    public void Getuserconpassword(string passwordIn)
    {
        conpwdinput = passwordIn;
    }

    private void Login()
    {
        emailinput = PlayerPrefs.GetString("EMAIL");
        pwdinput = PlayerPrefs.GetString("PASSWORD");
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailinput,
            Password = pwdinput,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, Onerror);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        login.SetActive(false);
        logicon.SetActive(false);
        gameicon.SetActive(true);
        logouticon.SetActive(true);
        leaderbdicon.SetActive(true);
    }

    public void Register()
    {
        if (pwdinput.Length < 6)
        {
            messagetext.text = "Password too short";
        }

        if(pwdinput==conpwdinput)
        {
            var request = new RegisterPlayFabUserRequest
            {
                Username = nameinput,
                Email = emailinput,
                Password = pwdinput,
                RequireBothUsernameAndEmail = true
            };
            PlayFabClientAPI.RegisterPlayFabUser(request, Onregistersucccess, Onerror); 
        }
        else
        {
            messagetext.text = "Pasword mismatch";
        }
        
    }

    private void Onregistersucccess(RegisterPlayFabUserResult result)
    {
        PlayerPrefs.SetString("EMAIL", emailinput);
        PlayerPrefs.SetString("PASSWORD", pwdinput);
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest { DisplayName = nameinput },
            displaynamesuccess,
            Onerror);
        register.SetActive(false);
        messagetext.text = " ";
    }

    private void displaynamesuccess(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log(result.DisplayName);
    }

    public void Onclicklogin()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailinput,
            Password = pwdinput,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, Onerror);
    }

    

    public void Sendscore( )
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
               new StatisticUpdate
               {
                   StatisticName="Overall Score",
                    Value = PlayerPrefs.GetInt("OVERALLSCORE")
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
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString(); 
        }
    }

    public void Resetpwd()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email=emailinput,
            TitleId= "823BE",
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request,Onpwdreset,Onerror);
    }

    private void Onpwdreset(SendAccountRecoveryEmailResult result)
    {
        messagetext.text = "Password reset mail sent";
        reset.SetActive(false);
        messagetext.text = " ";
    }

    private void Onerror(PlayFabError error)
    {
        messagetext.text = error.ErrorMessage;
        Debug.LogError(error.GenerateErrorReport());
    }

    public void logout()
    {
        PlayerPrefs.DeleteKey("EMAIL");
        PlayerPrefs.DeleteKey("PASSWORD");
    }
}
