using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarFireProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform cannonTip;
    public float delaySeconds;

    void Start()
    {
        StartCoroutine("waitForSpawn");
        projectilePrefab.GetComponent<Renderer>().enabled = false;
    }

    IEnumerator waitForSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds (delaySeconds);
            float randomfireRange = Random.Range(40000, 60000);
            // Rigidbody projectileInstance;
            GameObject projectileInstance;
            projectilePrefab.GetComponent<Renderer>().enabled = true;
            SoundManager.PlaySound("Cannonsfx");
            projectileInstance = Instantiate(projectilePrefab, cannonTip.position, cannonTip.rotation);
            projectileInstance.GetComponent<Rigidbody>().AddForce(cannonTip.forward * randomfireRange);
            // projectileInstance.AddForce(cannonTip.forward * 50000);

            
        }
    }

}
