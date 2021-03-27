using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Count : MonoBehaviour
{
    [SerializeField]
    private TMP_Text toshootcount;
    [SerializeField]
    private GameObject counter;
    [SerializeField]
    private GameObject winscreen;
    [SerializeField]
    private GameObject lossscreen;
    [SerializeField]
    private GameObject crct;
    [SerializeField]
    private GameObject wrng;
    [SerializeField]
    private Image[] hearts;

    private int numofhearts = 3;
    private int ghostshotcount = 0;
    private int shotcount;
    private int score = 1;

    [SerializeField]
    private int start;
    [SerializeField]
    private int end;

    private int toshootcnt;
    private int prevtoshootcnt;

    private void Start()
    {
        toshootcnt = Random.Range(start, end);
        prevtoshootcnt = toshootcnt;
        toshootcount.text = toshootcnt.ToString();
    }

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

        if (score >= 5)
        {
            StartCoroutine(loadwin());
        }

        IEnumerator loadwin()
        {
            yield return new WaitForSeconds(1f);
            Time.timeScale = 0f;
            winscreen.SetActive(true);

            int currentlevel = SceneManager.GetActiveScene().buildIndex;
            if (currentlevel - 15 >= PlayerPrefs.GetInt("NUMBERSLEVELUNLOCKED"))
            {
                PlayerPrefs.SetInt("NUMBERSLEVELUNLOCKED", (currentlevel - 15) + 1);
            }
        }

        if (numofhearts <= 0)
        {
            lossscreen.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    public void checkcrct()
    {
        if(toshootcnt==ghostshotcount)
        {
            score += 1;
            crct.SetActive(true);
            ghostshotcount = 0;
            StartCoroutine(correct());
        }
        else
        {
            numofhearts -= 1;
            wrng.SetActive(true);
            ghostshotcount = 0;
            StartCoroutine(wrong());
        }
    }

    public void shotghostcount()
    {
        ghostshotcount++;
    }


    IEnumerator correct()
    {
        yield return new WaitForSeconds(1f);
        crct.SetActive(false);
        setnewcount();
    }

    IEnumerator wrong()
    {
        yield return new WaitForSeconds(1f);
        wrng.SetActive(false);
        setnewcount();
    }

    private void setnewcount()
    {
        toshootcnt = Random.Range(start, end);

        while (true)
        {
            if (prevtoshootcnt != toshootcnt)
            {
                toshootcount.text = toshootcnt.ToString();
                prevtoshootcnt = toshootcnt;
                break;
            }
            else
            {
                toshootcnt = Random.Range(start, end);
            }
        }
    }
}
