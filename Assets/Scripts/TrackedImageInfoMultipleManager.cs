﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImageInfoMultipleManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text alphabets;
    [SerializeField]
    private TMP_Text debugcount;
    [SerializeField]
    private TMP_Text debugimg;
    [SerializeField]
    private GameObject crct;
    [SerializeField]
    private GameObject wrong;
    [SerializeField]
    private GameObject change;
    [SerializeField]
    private Transform spawnpoint;
    [SerializeField]
    private GameObject[] arObjectsToPlace;
    [SerializeField]
    private string[] alpha;

    private bool run = false;
    private string curralpha;
    private static int count;
    private GameObject goARObject;
    private ARTrackedImage trackedimg;

    private ARTrackedImageManager m_TrackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();


    private void Start()
    {
        count = 0;
        curralpha = alpha[count];
        alphabets.text = curralpha;
        debugcount.text = count.ToString();
        count++;
    }

    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        
        foreach(GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, spawnpoint.position, Quaternion.identity);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
        }
    }

    private void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
          m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
             UpdateARImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateARobject(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
           arObjects[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateARobject(ARTrackedImage trackedImage)
    {
            if (trackedImage.referenceImage.name == curralpha)
            {
                if (arObjectsToPlace != null)
                {
                    goARObject = arObjects[trackedImage.referenceImage.name];
                    goARObject.SetActive(true);
                    goARObject.transform.position = trackedImage.transform.position;
                    foreach (GameObject go in arObjects.Values)
                    {
                        Debug.Log($"Go in arObjects.Values: {go.name}");
                        if (go.name != trackedImage.referenceImage.name)
                        {
                            go.SetActive(false);
                        }
                    }
                }
            }

    }

    private void UpdateARImage(ARTrackedImage trackedImage)
    {
       debugimg.text = trackedImage.referenceImage.name;
       AssignGameObject(trackedImage.referenceImage.name, trackedImage.transform.position);
    }

    void AssignGameObject(string name, Vector3 newPosition)
    {
        if (name == curralpha)
        {
            if (arObjectsToPlace != null)
            {
                run = true;
                crct.SetActive(true);
                StartCoroutine(timer());
            }
        }
        else
        {
             wrong.SetActive(true);
             StartCoroutine(wtimer());
        }
    }

    IEnumerator wtimer()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(2f);

        if(run)
        {
            Destroy(goARObject);
            crct.SetActive(false);
            arObjects.Remove(curralpha);
          //  change.SetActive(true);

            debugcount.text = count.ToString();

            curralpha = alpha[count];

            if (count < alpha.Length)
            {
                alphabets.text = curralpha;
                count++;
            }
            else
            {
                //gameover
            }
          //  StartCoroutine(changer());
        }
    }

   /* IEnumerator changer()
    {
        yield return new WaitForSeconds(5f);
        run = false;
        change.SetActive(false);
    }*/
}
