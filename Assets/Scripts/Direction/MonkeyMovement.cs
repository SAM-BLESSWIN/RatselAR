using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform lefttarget;
    [SerializeField]
    private Transform righttarget;
    [SerializeField]
    private Transform centertarget;

    public void left()
    {
        transform.position = Vector3.MoveTowards(transform.position, lefttarget.position,5f);
    }

    public void right()
    {
        transform.position = Vector3.MoveTowards(transform.position, righttarget.position, 5f);
    }

    public void center()
    {
        transform.position = Vector3.MoveTowards(transform.position, centertarget.position, 5f);
    }
}
