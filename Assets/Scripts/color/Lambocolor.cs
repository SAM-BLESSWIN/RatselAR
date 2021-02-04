using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lambocolor : MonoBehaviour
{

    public Material mymaterial;


    private void Awake()
    {
        mymaterial.color = Color.white;
    }

    public void red()
    {
        mymaterial.color = Color.red;
    }

    public void green()
    {
        mymaterial.color = Color.green;
    }
    public void blue()
    {
        mymaterial.color = Color.blue;
    }
    public void yellow()
    {
        mymaterial.color = Color.yellow;
    }
    public void orange()
    {
        Color orange = new Color(1, 0.55f, 0, 1);
        mymaterial.color = orange;
    }
    public void violet()
    {
        Color violet = new Color(0.65f, 0, 1,1);
        mymaterial.color = violet;
    }
}
