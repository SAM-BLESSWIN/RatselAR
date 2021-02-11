using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnghost : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnpoints;
    [SerializeField]
    private GameObject[] ghost;
    private GameObject spawnedghost;
    private Transform spawnedpoint;

    void Start()
    {
        StartCoroutine(createghost());
    }

    IEnumerator createghost()
    {
        yield return new WaitForSeconds(Random.Range(2f,5f));

        spawnedghost = ghost[Random.Range(0, ghost.Length)];
        spawnedpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
        spawnedghost =Instantiate(spawnedghost, spawnedpoint.position, spawnedpoint.rotation);

        StartCoroutine(createghost());
    }
  
    
}
