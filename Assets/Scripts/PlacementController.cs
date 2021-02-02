using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{
    public GameObject placedprefab;
    private GameObject spawnedobject;
    private ARRaycastManager arRaycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private bool GetTouchInput(out Vector2 touchposition)
    {
        if(Input.touchCount > 0)
        {
            touchposition = Input.GetTouch(0).position;
            return true;
        }
        touchposition = default;
        return false;
    }

    void Update()
    {
        if(!GetTouchInput(out Vector2 touchposition))
        {
            return;
        }
        if(arRaycastManager.Raycast(touchposition,hits,TrackableType.PlaneWithinPolygon))
        {
            var hitpose = hits[0].pose;

            if(spawnedobject==null)
            {
                spawnedobject = Instantiate(placedprefab, hitpose.position, hitpose.rotation);
            }
            else
            {
                spawnedobject.transform.position = hitpose.position;
            }
        }
    }
}
