using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosion;

    private static int monindex = 0;

    private string[] months = { "jan", "feb", "mar", "apr", "may", "june", "july","aug", "sept", "oct", "nov", "dec" };

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag==months[monindex])
        {
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            monindex++;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 2f);
        }
    }

    
}
