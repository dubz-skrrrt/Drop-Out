using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    private float lastFireTime = 0;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Time.time>=lastFireTime+fireRate)
        {
            lastFireTime = Time.time;
            Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}