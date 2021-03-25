using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static SpeechRecognizerPlugin;

public class Wordrecognize : MonoBehaviour, ISpeechRecognizerPlugin
{
    [SerializeField]
    private GameObject wrong;
    [SerializeField] private Button startListeningBtn = null;
    [SerializeField] private TMP_Text resultsTxt = null;

    private bool found=false;
    private Changeaction changeaction;

    [SerializeField] private Characterplacement characterplacement;

    private SpeechRecognizerPlugin plugin = null;

    void Start()
    {
        plugin = SpeechRecognizerPlugin.GetPlatformPluginVersion(this.gameObject.name);

        startListeningBtn.onClick.AddListener(StartListening);

        changeaction = gameObject.GetComponent<Changeaction>();
    }

    private void StartListening()
    {
        plugin.StartListening();
    }

    public void OnResult(string recognizedResult)
    {
        char[] delimiterChars = { '~' };
        string[] result = recognizedResult.Split(delimiterChars);

        resultsTxt.text = "";

        for (int i = 0; i < result.Length; i++)
        {
            if (changeaction.Getword()==result[i])
            {
                found = true;
                resultsTxt.text = result[i];
                wordmatch();
                break;
            }
            else
            {
                found = false;
            }
        }

        if(!found)
        {
            tryagain();
        }
    }

    private void wordmatch()
    {
        if(changeaction.Getword()=="sit")
        {
            characterplacement.sit();
        }
        if (changeaction.Getword() == "stand")
        {
            characterplacement.stand();
        }
        if (changeaction.Getword() == "walk")
        {
            characterplacement.walk();
        }
        if (changeaction.Getword() == "Run")
        {
            characterplacement.run();
        }
        if (changeaction.Getword() == "jump")
        {
            characterplacement.jump();
        }
        if (changeaction.Getword() == "clap")
        {
            characterplacement.clap();
        }
        if (changeaction.Getword() == "push")
        {
            characterplacement.push();
        }
        if (changeaction.Getword() == "pull")
        {
            characterplacement.pull();
        }
        if (changeaction.Getword() == "left")
        {
            characterplacement.left();
        }
        if (changeaction.Getword() == "right")
        {
            characterplacement.right();
        }
        if (changeaction.Getword() == "fight")
        {
            characterplacement.fight();
        }
        if (changeaction.Getword() == "dance")
        {
            characterplacement.dance();
        }

        StartCoroutine(changer()); 
    }

    IEnumerator changer()
    {
        yield return new WaitForSeconds(3f);
        changeaction.changeword();
        resultsTxt.text = "";
    }

    private void tryagain()
    {
        wrong.SetActive(true);
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        wrong.SetActive(false);
    }
}
