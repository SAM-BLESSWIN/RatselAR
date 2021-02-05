using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lambocolor : MonoBehaviour
{
    [SerializeField]
    private Material mymaterial;
    

    private void Awake()
    {
        mymaterial.color = Color.white;
    }

    public void setred()
    {
        mymaterial.color = Color.red;
    }
    public void setgreen()
    {
        mymaterial.color = Color.green;
    }
    public void setblue()
    {
        mymaterial.color = Color.blue;
    }
    public void setyellow()
    {
        mymaterial.color = Color.yellow;
    }
    public void setorange()
    {
        Color orange = new Color(1, 0.55f, 0, 1);
        mymaterial.color = orange;
    }
    public void setviolet()
    {
        Color violet = new Color(0.65f, 0, 1, 1);
        mymaterial.color = violet;
    }
}
