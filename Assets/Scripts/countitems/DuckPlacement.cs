using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class DuckPlacement : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;

    [SerializeField]
    private GameObject detect;
    [SerializeField]
    private GameObject place;
    [SerializeField]
    private GameObject startbt;
    [SerializeField]
    private GameObject countcanvas;

    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;
    private Animator anim;
    private Eggspawn eggspawn;
    private int eggcount;

    [SerializeField]
    private int a;
    [SerializeField]
    private int b;

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
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
        place.SetActive(false);
        anim=spawnedObject.GetComponent<Animator>();
        eggspawn = spawnedObject.GetComponentInChildren<Eggspawn>();
        startbt.SetActive(true);
    }

    public void walk()
    {
        anim.SetBool("walk", true);
        eggcount= Random.Range(a,b);
        eggspawn.createeggs(eggcount);
        StartCoroutine(loadcountcanvas());
    }

    IEnumerator loadcountcanvas()
    {
        yield return new WaitForSeconds(eggcount + 2);
        countcanvas.SetActive(true);
    }

    public int passcount()
    {
        return eggcount;
    }
}
