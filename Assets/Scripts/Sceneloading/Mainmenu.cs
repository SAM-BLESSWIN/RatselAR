using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void learn()
    {
        SceneManager.LoadScene(2);
    }

    public void game()
    {
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        Application.Quit();
    }
}
