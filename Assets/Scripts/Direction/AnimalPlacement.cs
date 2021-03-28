using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class AnimalPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject detect;
    [SerializeField]
    private GameObject place;
    [SerializeField]
    private GameObject gamecanvas;

    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;

    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    private MonkeyMovement monkeymove;

    [SerializeField]
    private Direct drtext;

    [SerializeField]
    private GameObject movekey;

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        detect.SetActive(true);
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
        gamecanvas.SetActive(true);
        place.SetActive(false);
        monkeymove = spawnedObject.GetComponentInChildren<MonkeyMovement>();
        movekey.SetActive(true);
        drtext.enabled=true;
    }

    public void left()
    {
        monkeymove.left();
    }

    public void right()
    {
        monkeymove.right();
    }

    public void center()
    {
        monkeymove.center();
    }
}
