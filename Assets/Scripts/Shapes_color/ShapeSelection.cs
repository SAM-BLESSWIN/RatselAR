using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ShapeSelection : MonoBehaviour
{
    public GameObject square;

    public void sq()
    {
        Instantiate(square,transform.position,Quaternion.identity);
    }
    public void rect()
    {
        Toast.Instance.Show("rectangle");
    }
    public void tri()
    {
        Toast.Instance.Show("triangle");
    }
    public void circle()
    {
        Toast.Instance.Show("circle");
    }
}
