using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckmove : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(anim.GetBool("walk"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 0.075f);
        }
    }
}
