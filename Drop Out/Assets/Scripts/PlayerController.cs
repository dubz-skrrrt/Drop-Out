using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public GameObject player;
    public float speed;
    public float strafeSpeed;
    public float sprintSpeed;
    public Rigidbody hips;

    public float JumpForce;

    public bool isGrounded;

    void Update ()
    {

        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            //Debug.Log("Running");
            
            player.GetComponent<Animation>().Play("Running");
            player.transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            
        }else if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("ruuuun");
            player.GetComponent<Animation>().Play("Walking");

            player.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }else{
            player.GetComponent<Animation>().Play("Warrior_Idle");
        }

            
    }
}
