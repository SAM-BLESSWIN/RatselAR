using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootbullets : MonoBehaviour
{
    [SerializeField] private Transform arcamera;
    public GameObject bullet;
    public float shootforce;
    

    public void shoot()
    {
        /*RaycastHit hit;
        if (Physics.Raycast(arcamera.transform.position, arcamera.transform.forward, out hit))
        {
            if (hit.transform.tag == months[monindex])
            {
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                monindex++;
            }
        }*/

        GameObject clone = Instantiate(bullet, arcamera.position, arcamera.rotation) as GameObject;
        clone.GetComponent<Rigidbody>().AddForce(arcamera.forward * shootforce);
    }
}
