using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Changeaction : MonoBehaviour
{
    private int totalscore;
    [SerializeField]
    private TMP_Text word;
    [SerializeField]
    private int start;
    [SerializeField]
    private int end;
    [SerializeField]
    private GameObject winscreen;

    private string currentword;
    private static int count;

    string[] wordlist = { "sit","stand","Run", "walk", "jump","clap","push","pull","left","right","dance","fight"};

    private void Start()
    {
        count = start;
        changeword();
    }

    public void changeword()
    {
        if(count<end)
        {
            currentword = wordlist[count];
            word.text = currentword;
            count++;
        }
        else
        {
            gameover();
        }
    }

    public string Getword()
    {
        return currentword;
    }

    private void gameover()
    {
        StartCoroutine(loadwin());
    }

    IEnumerator loadwin()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        winscreen.SetActive(true);

        int currentlevel = SceneManager.GetActiveScene().buildIndex;
        if (currentlevel - 4 >= PlayerPrefs.GetInt("ALPHABETSLEVELUNLOCKED"))
        {
            PlayerPrefs.SetInt("ALPHABETSLEVELUNLOCKED", (currentlevel - 4) + 1);

            totalscore = PlayerPrefs.GetInt("TOTALSCORE") + 100;
            PlayerPrefs.SetInt("TOTALSCORE", totalscore);
        }
    }
}
