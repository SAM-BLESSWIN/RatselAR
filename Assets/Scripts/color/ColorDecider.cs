using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorDecider : MonoBehaviour
{
    [SerializeField]
    private GameObject crct;
    [SerializeField]
    private GameObject wrng;
    [SerializeField]
    private OrginPlacement colorindicator;
    [SerializeField]
    private Lambocolor lambocolor;

    public void red()
    {
        if (colorindicator.textcolor() == "red")
        {
            crct.SetActive(true);
            lambocolor.setred();
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            StartCoroutine(wrong());
        }
    }

    public void green()
    {
        if (colorindicator.textcolor() == "green")
        {
            crct.SetActive(true);
            lambocolor.setgreen();
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            StartCoroutine(wrong());
        }
    }

    public void blue()
    {
        if (colorindicator.textcolor() == "blue")
        {
            crct.SetActive(true);
            lambocolor.setblue();
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            StartCoroutine(wrong());
        }
    }

    public void yellow()
    {
        if (colorindicator.textcolor() == "yellow")
        {
            crct.SetActive(true);
            lambocolor.setyellow();
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            StartCoroutine(wrong());
        }
    }

    public void orange()
    {
        if (colorindicator.textcolor() == "orange")
        {
            crct.SetActive(true);
            lambocolor.setorange();
            StartCoroutine(correct());
        }
        else
        {
            wrng.SetActive(true);
            StartCoroutine(wrong());
        }
    }

    public void violet()
    {
        if (colorindicator.textcolor() == "violet")
        {
            crct.SetActive(true);
            lambocolor.setviolet();
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
        colorindicator.namechange();
    }

    IEnumerator wrong()
    {
        yield return new WaitForSeconds(0.5f);
        wrng.SetActive(false);
    }
}
