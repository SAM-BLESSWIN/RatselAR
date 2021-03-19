using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform lefttarget;
    [SerializeField]
    private Transform righttarget;

    public void left()
    {
        //  movekey.enabled = false;
        transform.position = Vector3.MoveTowards(transform.position, lefttarget.position,5f);
    }

    public void right()
    {
        // movekey.enabled = false;
        transform.position = Vector3.MoveTowards(transform.position, righttarget.position, 5f);
    }
}
