using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform trans;
    public float speed= 5f;
    public float range = 5f;
    private Vector3 spawnPoint;
    public GameObject canonStart;
    private Canon canonScript;
    void Start()
    {
        spawnPoint = trans.position;
        canonScript = canonStart.GetComponent<Canon>();

        
    }

    
    void Update()
    {
        if(canonScript.spawnStart){
            trans.Translate(0, 0, speed*Time.deltaTime, Space.Self);

            if (Vector3.Distance(trans.position, spawnPoint)>=range)
            {
            //Destroy(gameObject);
            }
        }
            
        
        
    }
}