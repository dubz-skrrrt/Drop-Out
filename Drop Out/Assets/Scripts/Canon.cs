using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    private float lastFireTime = 0;
    public bool spawnStart = false;
    void Start()
    {
        spawnStart = false;
    }

   
    void Update()
    {
        Debug.Log(spawnStart);
        if (spawnStart){
            if (Time.time>=lastFireTime+fireRate)
            {
                lastFireTime = Time.time;
                Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
                fireRate = Random.Range(5,10);
            }
        }
        
    }
}