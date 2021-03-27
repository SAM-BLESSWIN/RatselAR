using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Voiceload : MonoBehaviour
{
    public void Resetscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        SceneManager.LoadScene(0);
    }

    public void next()
    {
        int currentlevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentlevel + 1);
    }
}
