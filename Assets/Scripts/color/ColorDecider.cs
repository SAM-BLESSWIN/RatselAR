using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorDecider : MonoBehaviour
{
    private TMP_Text colorname;

    List<string> colorlist = new List<string>
    {
    "red","green","blue","yellow","orange","violet"
    };

    private void Awake()
    {
        colorname = GameObject.Find("Colorname").GetComponentInChildren<TMP_Text>();
    }

    public void namechange()
    {
        colorname.text = colorlist[Random.Range(0, 6)].ToString();
    }
}
