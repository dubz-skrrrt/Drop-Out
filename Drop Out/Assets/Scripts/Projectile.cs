using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform trans;
    public float speed= 5f;
    public float range = 5f;
    private Vector3 spawnPoint;

    private GameObject canonCollider;
    void Start()
    {
        spawnPoint = trans.position;
        canonCollider = GameObject.FindGameObjectWithTag("CanonStart");
        
    }

    
    void Update()
    {
        trans.Translate(0, 0, speed*Time.deltaTime, Space.Self);

        if (Vector3.Distance(trans.position, spawnPoint)>=range)
        {
          //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "AnyPlayer");
    }
}