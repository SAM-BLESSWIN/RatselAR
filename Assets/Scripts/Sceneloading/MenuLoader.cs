using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    public void shapesload()
    {
        SceneManager.LoadScene(1);
    }
    public void colorsload()
    {
        SceneManager.LoadScene(2);
    }

}
