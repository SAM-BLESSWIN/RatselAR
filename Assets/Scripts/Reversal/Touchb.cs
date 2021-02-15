using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Touchb : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoretext;
    private int score=0;

    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private GameObject correct;
    [SerializeField]
    private GameObject wrong;

    private int numofhearts = 3;

    private bool isdead = false;

    [SerializeField]
    private GameObject ongame;
    [SerializeField]
    private GameObject winscreen;
    [SerializeField]
    private GameObject lossscreen;

    private GameObject crct;
    private GameObject wrng;

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

        if (Input.touchCount > 0 && Input.touches[0].phase==TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.tag=="b")
                {
                    score += 10;
                    scoretext.text = score.ToString();
                    crct=Instantiate(correct, hit.point, Quaternion.identity);
                    Destroy(crct,0.2f);
                    Destroy(hit.collider.gameObject);
                }
                else if(hit.collider.tag=="d" || hit.collider.tag == "p" || hit.collider.tag == "q")
                {
                    wrng=Instantiate(wrong, hit.point, Quaternion.identity);
                    Destroy(wrng,0.2f);
                    Handheld.Vibrate();
                    numofhearts -= 1;
                }
            }
        }

        if(score >=100)
        {
            ongame.SetActive(false); 
            winscreen.SetActive(true);
            Time.timeScale = 0f;
        }

        if(numofhearts<=0)
        {
            ongame.SetActive(false);
            lossscreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
