using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class PathPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject detect;
    [SerializeField]
    private GameObject place;
    [SerializeField]
    private GameObject Gamecanvas1;

    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;

    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;
    private JumpandMove jumpandmove;


    private void Awake()
    {
        detect.SetActive(true);
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
            detect.SetActive(false);
            placementIndicator.SetActive(true);
            place.SetActive(true);
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
        place.SetActive(false);
        Gamecanvas1.SetActive(true);
        jumpandmove =spawnedObject.GetComponentInChildren<JumpandMove>();  
    }  

    public void jump()
    {
        jumpandmove.jump();
    }


}
