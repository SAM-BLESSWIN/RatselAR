using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countverify : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField countvalue;
    [SerializeField]
    private GameObject crct;
    [SerializeField]
    private GameObject wrng;

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
        yield return new WaitForSeconds(0.5f);
        crct.SetActive(false);
    }

    IEnumerator wrong()
    {
        yield return new WaitForSeconds(0.5f);
        wrng.SetActive(false);
    }
}
