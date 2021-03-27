using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touchalpha : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadScene(1);
    }

    public void tryagain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
