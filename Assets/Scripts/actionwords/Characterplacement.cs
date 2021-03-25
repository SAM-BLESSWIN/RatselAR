using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class Characterplacement : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;

    [SerializeField]
    private GameObject voicecanvas;

    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    private Animator anim;

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();

    }


    void Update()
    {
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();


    }
    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, arObjectToSpawn.transform.rotation);
        voicecanvas.SetActive(true);
        anim = spawnedObject.GetComponent<Animator>();
    }

    public void sit()
    {
        anim.Play("Stand To Sit");
    }
    public void stand()
    {
        anim.Play("Sit To Stand");
    }
    public void walk()
    {
        anim.Play("Walking");
    }
    public void run()
    {
        anim.Play("Running");
    }
    public void jump()
    {
        anim.Play("Jumping");
    }
    public void clap()
    {
        anim.Play("Clapping");
    }
    public void push()
    {
        anim.Play("Pushing");
    }
    public void pull()
    {
        anim.Play("Pulling A Rope");
    }
    public void left()
    {
        anim.Play("Left Turn");
    }
    public void right()
    {
        anim.Play("Right Turn");
    }
    public void fight()
    {
        anim.Play("Fist Fight A");
    }
    public void dance()
    {
        anim.Play("Chicken Dance");
    }
}

