using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modetransistion : MonoBehaviour
{
    [SerializeField]
    private GameObject color;
    [SerializeField]
    private GameObject rotatecanvas;
    private GameObject leantouch;

    private void Awake()
    {
        leantouch = GameObject.Find("LeanTouch");
    }
    public void play()
    {
        color.SetActive(true);
        rotatecanvas.SetActive(false);
        leantouch.SetActive(false);
    }
}
