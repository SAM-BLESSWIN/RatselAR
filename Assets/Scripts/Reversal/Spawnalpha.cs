using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnalpha : MonoBehaviour
{
    [SerializeField]
    private GameObject[] alpha;

    private void Start()
    {
        StartCoroutine(spawnletters());
    }
    void Update()
    {
        
    }

    IEnumerator spawnletters()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(alpha[Random.Range(0, alpha.Length)], this.transform.position, Quaternion.identity);
        StartCoroutine(spawnletters());
    }
}
