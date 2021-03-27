using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour
{
    private string emailinput;
    private string pwdinput;
    private string conpwdinput;
    private string nameinput;
    private string displayinput;
    
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
    private GameObject namewindow;
    [SerializeField]
    private GameObject leaderbdicon;
    [SerializeField]
    private GameObject logicon;
    [SerializeField]
    private GameObject gameicon;
    [SerializeField]
    private GameObject logouticon;
    [SerializeField]
    private PlayfabStats playfabstats;
    [SerializeField]
    private GameObject logging;
    [SerializeField]
    private GameObject loggingout;

    private void Start()
    {
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            logging.SetActive(true);
            Login(); 
        }
    }

    public void Getusername(string usernameIn)
    {
        nameinput = usernameIn;
    }
    public void Getdispname(string displaynameIn)
    {
        displayinput = displaynameIn;
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
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, Onerror);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        if(!PlayerPrefs.HasKey("EMAIL"))
        {
            PlayerPrefs.SetString("EMAIL", emailinput);
            PlayerPrefs.SetString("PASSWORD", pwdinput);
        }
        playfabstats.Sendscore();

        string name = " ";

        if (result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;

        if (name == null)
            namewindow.SetActive(true);

        login.SetActive(false);
        logicon.SetActive(false);
        gameicon.SetActive(true);
        logouticon.SetActive(true);
        leaderbdicon.SetActive(true);
        logging.SetActive(false);
    }

    public void submitname()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = displayinput
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, Onnameset, Onerror);
    }

    private void Onnameset(UpdateUserTitleDisplayNameResult result)
    {
        namewindow.SetActive(false);
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
        register.SetActive(false);
        messagetext.text = " ";
    }

    public void Onclicklogin()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailinput,
            Password = pwdinput,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, Onerror);
    }

    public void Getleaderboardstats()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Overall Score",
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
        loggingout.SetActive(true);
        StartCoroutine(loadout());
        
    }

    IEnumerator loadout()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
    
}
