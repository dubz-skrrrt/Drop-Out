using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    //private bool complete = false;
    private int qualified = 0;
    private int maxQualification = 1;

    void OnTriggerEnter(Collider col)
    {
        // if player or enemy collides with finish line
        if (col.gameObject.tag == "Player")
        {
            qualified++;
            if (qualified == maxQualification)
            {
                //complete = true;
                Debug.Log("WIPEOUT!");
                SceneManager.LoadScene("UI2"); // loads game
                Cursor.lockState = CursorLockMode.None;
            }
            
        }
    }
}
