using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{ 
    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void tryagain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void next()
    {
        int currentlevel = SceneManager.GetActiveScene().buildIndex;
        if (currentlevel >= PlayerPrefs.GetInt("levelsunlocked"))
        {
            PlayerPrefs.SetInt("levelsunlocked", currentlevel + 1);
        }
        SceneManager.LoadScene(currentlevel + 1);
    }

}
