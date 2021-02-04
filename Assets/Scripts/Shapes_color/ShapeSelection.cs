using System;
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

    [SerializeField]
    private GameObject placementindicator;
    [SerializeField]
    private GameObject arcamera;
    private Pose hitpose;
    private ARRaycastManager arRaycastManager;
    private bool placementposeisvalid;

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        Updateplacementpose();
        Updateplacementindicator();
    }

    private void Updateplacementpose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementposeisvalid = hits.Count > 0;
        if (placementposeisvalid)
        {
            hitpose = hits[0].pose;
        }
    }

    private void Updateplacementindicator()
    {
        if(placementposeisvalid)
        {
            placementindicator.SetActive(true);
            placementindicator.transform.SetPositionAndRotation(hitpose.position, hitpose.rotation);
        }
        else
        {
            placementindicator.SetActive(false);
        }
    }


    public void cub()
    {
        Instantiate(cube,hitpose.position,cube.transform.rotation);
    }
    public void coid()
    {
        Instantiate(cuboid, hitpose.position, cuboid.transform.rotation);
    }
    public void con()
    {
        Instantiate(cone, hitpose.position, cone.transform.rotation);
    }
    public void sp()
    {
        Instantiate(sphere, hitpose.position, sphere.transform.rotation);
    }
    public void sq()
    {
        Instantiate(square,hitpose.position,square.transform.rotation);
    }
    public void rect()
    {
        Instantiate(rectangle, hitpose.position, rectangle.transform.rotation);
    }
    public void tri()
    {
        Instantiate(triangle,hitpose.position, triangle.transform.rotation);
    }
    public void cir()
    {
        Instantiate(circle,hitpose.position, circle.transform.rotation);
    }
}
