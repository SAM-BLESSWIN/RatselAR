using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totalscore : MonoBehaviour
{
    //private int overallscore=0;

    private void Start()
    {
      //  DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.SetInt("OVERALLSCORE", 0);
    }
}
