using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColorDecider : MonoBehaviour
{
    private int totalscore;
    [SerializeField]
    private TMP_Text scoretxt;
    [SerializeField]
    private GameObject winscreen;
    [SerializeField]
    private GameObject lossscreen;
    [SerializeField]
    private Image[] hearts;

    private int numofhearts = 3;
    [SerializeField]
    private GameObject crct;
    [SerializeField]
    private GameObject wrng;
    [SerializeField]
    private OrginPlacement colorindicator;
    [SerializeField]
    private Lambocolor lambocolor;

    private int score;

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numofhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (score >= 20)
        {
            StartCoroutine(loadwin());
        }

        IEnumerator loadwin()
        {
            yield return new WaitForSeconds(1f);
            Time.timeScale = 0f;
            winscreen.SetActive(true);

            int currentlevel = SceneManager.GetActiveScene().buildIndex;
            if (currentlevel - 20 >= PlayerPrefs.GetInt("GENERALLEVELUNLOCKED"))
            {
                PlayerPrefs.SetInt("GENERALLEVELUNLOCKED", (currentlevel - 20) + 1);
                totalscore = PlayerPrefs.GetInt("TOTALSCORE") + 100;
                PlayerPrefs.SetInt("TOTALSCORE", totalscore);
            }
        }

        if (numofhearts <= 0)
        {
            lossscreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void red()
    {
        if (colorindicator.textcolor() == "red")
        {
            score += 1;
            scoretxt.text = score.ToString();
            crct.SetActive(true);
            lambocolor.setred();
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            Handheld.Vibrate();
            numofhearts -= 1;
            StartCoroutine(wrong());
        }
    }

    public void green()
    {
        if (colorindicator.textcolor() == "green")
        {
            score += 1;
            scoretxt.text = score.ToString();
            crct.SetActive(true);
            lambocolor.setgreen();
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            Handheld.Vibrate();
            numofhearts -= 1;
            StartCoroutine(wrong());
        }
    }

    public void blue()
    {
        if (colorindicator.textcolor() == "blue")
        {
            score += 1;
            scoretxt.text = score.ToString();
            crct.SetActive(true);
            lambocolor.setblue();
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            Handheld.Vibrate();
            numofhearts -= 1;
            StartCoroutine(wrong());
        }
    }

    public void yellow()
    {
        if (colorindicator.textcolor() == "yellow")
        {
            score += 1;
            scoretxt.text = score.ToString();
            crct.SetActive(true);
            lambocolor.setyellow();
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            Handheld.Vibrate();
            numofhearts -= 1;
            StartCoroutine(wrong());
        }
    }

    public void orange()
    {
        if (colorindicator.textcolor() == "orange")
        {
            score += 1;
            scoretxt.text = score.ToString();
            crct.SetActive(true);
            lambocolor.setorange();
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            Handheld.Vibrate();
            numofhearts -= 1;
            StartCoroutine(wrong());
        }
    }

    public void violet()
    {
        if (colorindicator.textcolor() == "violet")
        {
            score += 1;
            scoretxt.text = score.ToString();
            crct.SetActive(true);
            lambocolor.setviolet();
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            Handheld.Vibrate();
            numofhearts -= 1;
            StartCoroutine(wrong());
        }

    }

    IEnumerator correct()
    {
        yield return new WaitForSeconds(1f);
        crct.SetActive(false);
        colorindicator.namechange();
    }

    IEnumerator wrong()
    {
        yield return new WaitForSeconds(1f);
        wrng.SetActive(false);
    }
}
