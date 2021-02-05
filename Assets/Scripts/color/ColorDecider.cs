using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorDecider : MonoBehaviour
{
    public TMP_Text color;

    List<string> colorlist = new List<string>
    {
    "red","green","blue","yellow","orange","violet"
    };

    private void Awake()
    {
       // color = gameObject.GetComponentInChildren<Canvas>();
    }

    private void Start()
    {
        color.text = "white";
    }

    public void namechange()
    {
       color.text = colorlist[Random.Range(0, 6)].ToString();
        Debug.Log(color.text);
    }
}
