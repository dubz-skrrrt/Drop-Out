using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public GameObject player;
    // public float speed;
    // public float strafeSpeed;
    // //public RigidBody hips;

    // public force JumpForce;

    void start()
    {
        

    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Running");
            player.GetComponent<Animation>().Play("Run");

        }
    }
}
