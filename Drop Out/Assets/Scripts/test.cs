using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform dropguy;
    private Transform respawnPoint;

    void Start()
    {
        respawnPoint = dropguy.Find("RespawnPoint").transform;
    }


    void OnTriggerEnter(Collider col)
    {
        // if player collides with checkpoint
        if (col.gameObject.name == "Checkpoint")
        {
            respawnPoint = dropguy.Find("RespawnPoint2").transform;
        } 
        else if (col.gameObject.name == "Checkpoint2")
        {
            respawnPoint = dropguy.Find("RespawnPoint3").transform;
        }

        // if player collides with ground
        if (col.gameObject.name == "DeathCollider")
        {
            Debug.Log("Dead and Respawning");
            col.transform.position = respawnPoint.transform.position;
        }

    }
}
