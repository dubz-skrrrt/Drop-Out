using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject dropguy;
    private Transform respawnPoint;

    void Start()
    {
        respawnPoint = GameObject.Find("RespawnPoint").transform;
    }

    
    void OnTriggerEnter(Collider col)
    {
        // if player collides with checkpoint
        if (col.gameObject.name == "Checkpoint")
        {
            SoundManager.PlaySound("Collision");
            Debug.Log("Check1");
            respawnPoint = GameObject.Find("RespawnPoint2").transform;
        } 
        else if (col.gameObject.name == "Checkpoint2")
        {
            SoundManager.PlaySound("Collision");
            Debug.Log("Check2");
            respawnPoint = GameObject.Find("RespawnPoint3").transform;
        }

        // if player collides with ground
        if (col.gameObject.name == "DeathCollider")
        {
            SoundManager.PlaySound("Byebye");
            Debug.Log("Dead and Respawning");
            dropguy.transform.position = respawnPoint.transform.position;
        }

    }
    
}
