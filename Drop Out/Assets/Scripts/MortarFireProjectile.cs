using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarFireProjectile : MonoBehaviour
{
    public Rigidbody projectilePrefab;
    public Transform cannonTip;
    public float delaySeconds;

    void Start()
    {
        StartCoroutine("waitForSpawn");
    }

    IEnumerator waitForSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds (delaySeconds);

            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectilePrefab, cannonTip.position, cannonTip.rotation) as Rigidbody;
            projectileInstance.AddForce(cannonTip.forward * 1000);
            
        }
    }
}
