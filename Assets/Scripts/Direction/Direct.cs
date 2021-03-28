using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Direct : MonoBehaviour
{
    private int totalscore;
    [SerializeField]
    private TMP_Text direction;
    [SerializeField]
    private TMP_Text score;
    [SerializeField]
    private GameObject winscreen;
    [SerializeField]
    private GameObject lossscreen;
    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private GameObject correct;
    [SerializeField]
    private GameObject wrong;

    private int numofhearts = 3;
    private string[] dr = new string[] { "Left", "Right"};
    private static int point=0;

    [SerializeField]
    private AnimalPlacement animalplacement;

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

        if (point >= 20)
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


    private void OnEnable()
    {
        direction.text = dr[Random.Range(0, 2)]; 
    }

    public void left()
    {
        if(direction.text=="Left")
        {
            correct.SetActive(true);
            point++;
            score.text = point.ToString();
            StartCoroutine(crct());
        }
        else
        {
            wrong.SetActive(true);
            Handheld.Vibrate();
            numofhearts -= 1;
            StartCoroutine(wrng());
        }    
    }

    public void right()
    {
        if (direction.text == "Right")
        {
            correct.SetActive(true);
            point++;
            score.text = point.ToString();
            StartCoroutine(crct());
        }
        else
        {
            wrong.SetActive(true);
            Handheld.Vibrate();
            numofhearts -= 1;
            StartCoroutine(wrng());
        }
    }

    IEnumerator crct()
    {
        yield return new WaitForSeconds(1f);
        correct.SetActive(false);
        nextdir();
    }

    IEnumerator wrng()
    {
        yield return new WaitForSeconds(1f);
        wrong.SetActive(false);
        nextdir();
    }

    private void nextdir()
    {
        animalplacement.center();
        direction.text = dr[Random.Range(0, 2)];
    }
}
