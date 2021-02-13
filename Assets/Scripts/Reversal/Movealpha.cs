using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movealpha : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 0.075f);
    }
}
