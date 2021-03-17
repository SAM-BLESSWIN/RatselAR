using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageTester : MonoBehaviour
{
    private ARTrackedImageManager aRTrackedImageManager;

    private void Awake()
    {
        aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }


}
