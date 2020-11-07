using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public Transform spawnPoint;
    private GameObject clones;
    public GameObject projectilePrefab;
    public float fireRate = 7f;
    private float lastFireTime = 0;
    public bool spawnStart = false;
    void Start()
    {
        spawnStart = false;
    }

   
    void Update()
    {
        if (spawnStart){
            if (Time.time>=lastFireTime+fireRate)
            {
                SoundManager.PlaySound("Cannonsfx");
                lastFireTime = Time.time;
                Destroy(Instantiate(projectilePrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y,spawnPoint.position.z + 1), spawnPoint.rotation), 15f);

                fireRate = Random.Range(7,10);
                
            }
        }
        
    }
}