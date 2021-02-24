using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    [SerializeField]
    private TMP_Text toshootcount;
    [SerializeField]
    private GameObject counter;
    [SerializeField]
    private GameObject crct;
    private TMP_Text shotcount;
    private int ghostshotcount=0;

    private void Awake()
    {
        shotcount = counter.GetComponent<TMP_Text>();
    }

    private void Start()
    {
        toshootcount.text = Random.Range(1, 10).ToString();
    }

    public void checkcrct()
    {
        if(toshootcount.text==shotcount.text)
        {
            crct.SetActive(true);
            ghostshotcount = 0;
            StartCoroutine(correct());
        }
    }

    public void shotghostcount()
    {
        ghostshotcount++;
        counter.SetActive(true);
        StartCoroutine(showcount());
        shotcount.text = ghostshotcount.ToString();
    }

    IEnumerator showcount()
    {
        yield  return new WaitForSeconds(0.5f);
        counter.SetActive(false);
    }

    IEnumerator correct()
    {
        yield return new WaitForSeconds(1f);
        crct.SetActive(false);
        toshootcount.text =Random.Range(1, 11).ToString();
    }
}
