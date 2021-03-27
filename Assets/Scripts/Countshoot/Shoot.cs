using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Camera arcamera;
    [SerializeField] private GameObject smoke;
    [SerializeField] private Count count;

    public void shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(arcamera.transform.position,arcamera.transform.forward,out hit))
        {
            if(hit.transform.tag=="ghost")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                count.shotghostcount();
            }
        }
    }
}
