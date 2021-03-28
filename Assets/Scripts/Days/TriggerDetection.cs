using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDetection : MonoBehaviour
{
    private int totalscore;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="fakegnd")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(other.gameObject.tag=="end")
        {
            int currentlevel = SceneManager.GetActiveScene().buildIndex;
            if (currentlevel - 20 >= PlayerPrefs.GetInt("GENERALLEVELUNLOCKED"))
            {
                PlayerPrefs.SetInt("GENERALLEVELUNLOCKED", (currentlevel - 20) + 1);
                totalscore = PlayerPrefs.GetInt("TOTALSCORE") + 100;
                PlayerPrefs.SetInt("TOTALSCORE", totalscore);
            }
            SceneManager.LoadScene(1);
        }
    }

    private void Update()
    {
        if(gameObject.transform.position.y<-20f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
