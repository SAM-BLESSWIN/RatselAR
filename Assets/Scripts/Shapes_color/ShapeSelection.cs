using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ShapeSelection : MonoBehaviour
{
    public GameObject cube;
    public GameObject cuboid;
    public GameObject cone;
    public GameObject sphere;
    public GameObject square;
    public GameObject rectangle;
    public GameObject triangle;
    public GameObject circle;


    public void cub()
    {
        Instantiate(cube,transform.position, Quaternion.identity);
    }
    public void coid()
    {
        Instantiate(cuboid, transform.position, Quaternion.identity);
    }
    public void con()
    {
        Instantiate(cone, transform.position, Quaternion.identity);
    }
    public void sp()
    {
        Instantiate(sphere, transform.position, Quaternion.identity);
    }
    public void sq()
    {
        Instantiate(square,transform.position,Quaternion.identity);
    }
    public void rect()
    {
        Instantiate(rectangle, transform.position, Quaternion.identity);
    }
    public void tri()
    {
        Instantiate(triangle, transform.position, Quaternion.identity);
    }
    public void cir()
    {
        Instantiate(circle, transform.position, Quaternion.identity);
    }
}
