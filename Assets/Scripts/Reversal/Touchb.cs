using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
                    score += 1;
                    scoretext.text = score.ToString();
                    crct=Instantiate(correct, hit.point, Quaternion.identity);
                    Destroy(crct,0.2f);
                    Destroy(hit.collider.gameObject);
                }
                else if(hit.collider.tag=="d" || hit.collider.tag == "p" || hit.collider.tag == "q")
                {
                    wrng=Instantiate(wrong, hit.point, Quaternion.identity);
                    Handheld.Vibrate();
                    Destroy(wrng,0.2f);
                    numofhearts -= 1;
                }
            }
        }

        if(score >=20)
        {
            StartCoroutine(loadwin());
        }

        IEnumerator loadwin()
        {
            yield return new WaitForSeconds(1f);
            Time.timeScale = 0f;
            ongame.SetActive(false);
            winscreen.SetActive(true);

            int currentlevel = SceneManager.GetActiveScene().buildIndex;
            if (currentlevel - 4 >= PlayerPrefs.GetInt("ALPHABETSLEVELUNLOCKED"))
            {
                PlayerPrefs.SetInt("ALPHABETSLEVELUNLOCKED", (currentlevel - 4) + 1);
            }
        }

        if(numofhearts<=0)
        {
            ongame.SetActive(false);
            lossscreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
