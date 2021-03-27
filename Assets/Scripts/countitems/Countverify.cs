using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Countverify : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField countvalue;
    [SerializeField]
    private GameObject crct;
    [SerializeField]
    private GameObject wrng;
    [SerializeField]
    private GameObject win;
    [SerializeField]
    private GameObject loss;

    private int eggscount;
    private int playercount;

    [SerializeField]
    private DuckPlacement duck;

    public void check()
    {
        eggscount = duck.passcount();
        playercount=int.Parse(countvalue.text);

        if (eggscount==playercount)
        {
            crct.SetActive(true);
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            StartCoroutine(wrong());
        }
    }

    IEnumerator correct()
    {
        yield return new WaitForSeconds(1f);
        crct.SetActive(false);
        win.SetActive(true);
        int currentlevel = SceneManager.GetActiveScene().buildIndex;
        if (currentlevel - 15 >= PlayerPrefs.GetInt("NUMBERSLEVELUNLOCKED"))
        {
            PlayerPrefs.SetInt("ALPHABETSLEVELUNLOCKED", (currentlevel - 15) + 1);
        }
    }

    IEnumerator wrong()
    {
        yield return new WaitForSeconds(1f);
        wrng.SetActive(false);
        loss.SetActive(true);
    }
}
