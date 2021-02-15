using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTimer : MonoBehaviour
{
    private int timer=3;
    [SerializeField]
    private TMP_Text timertext;
    [SerializeField]
    private GameObject ufo;

    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(countdownstart());
    }

    IEnumerator countdownstart()
    {
        while(timer>0)
        {
            timertext.text = timer.ToString();
            yield return new WaitForSeconds(1f);
            timer--;
        }
        timertext.text = "GO!";
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        ufo.SetActive(true);
    }
}
