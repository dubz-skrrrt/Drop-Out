using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;

    public Rigidbody hips;
    public bool isGrounded;

    void start()
    {
        hips = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            hips.AddForce(hips.transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            hips.AddForce(-hips.transform.right * strafeSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            hips.AddForce(-hips.transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            hips.AddForce(hips.transform.right * strafeSpeed);
        }

        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                hips.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }
    }
}
