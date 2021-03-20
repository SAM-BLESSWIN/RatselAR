using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpandMove : MonoBehaviour
{
    private Joystick joystick;
    private Rigidbody rb;

    public float speed;
    public float jumpvelocity;
    private bool isgrounded;

    private void Awake()
    {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * Time.deltaTime *speed, 
                                        rb.velocity.y,
                                        joystick.Vertical * Time.deltaTime*speed);
    }

    public void jump()
    {
        if(isgrounded)
        rb.AddForce(0, jumpvelocity, 0, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            isgrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isgrounded = false;
        }
    }
}
