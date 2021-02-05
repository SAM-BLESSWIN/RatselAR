using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colorsload : MonoBehaviour
{
    public void Resetscene()
    {
        SceneManager.LoadScene(2);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
