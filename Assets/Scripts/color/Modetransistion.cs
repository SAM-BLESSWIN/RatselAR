using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modetransistion : MonoBehaviour
{
    [SerializeField]
    private GameObject color;
    [SerializeField]
    private GameObject rotatecanvas;

    public void play()
    {
        color.SetActive(true);
        rotatecanvas.SetActive(false);
    }
}
