using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    //private bool complete = false;
    private int qualified = 0;
    private int maxQualification = 10;

    void OnTriggerEnter(Collider col)
    {
        // if player or enemy collides with finish line
        if ((col.gameObject.tag == "Player") || (col.gameObject.tag == "Enemy"))
        {
            qualified++;
            if (qualified == maxQualification)
            {
                //complete = true;
                Debug.Log("WIPEOUT!");
                Time.timeScale = 0;
            }
            
        }
    }
}
