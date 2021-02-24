using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggspawn : MonoBehaviour
{
    [SerializeField]
    private GameObject egg;

    private int i = 0;
    private int egglimit;

    public void createeggs()
    {
        egglimit = Random.Range(1, 11);
        StartCoroutine(layeggs());
    }

    IEnumerator layeggs()
    {
        if(i<egglimit)
        {
            Instantiate(egg, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            i++;
            StartCoroutine(layeggs());
        }
         else
        {
            StopCoroutine(layeggs());
        }
    }
   
}
