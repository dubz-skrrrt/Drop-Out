using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitholeFinish : MonoBehaviour
{
    private int remaining = 2;
    private int maxQualification = 1;
    
    void OnTriggerEnter(Collider col)
    {
        // if player or enemy collides with pithole
        if (col.gameObject.tag == "Player")
        {
            remaining--;
            if (remaining == maxQualification)
            {
                SoundManager.PlaySound("Yipee");
                Debug.Log("WIPEOUT!");
                Cursor.lockState = CursorLockMode.None;
                StartCoroutine(DelayNextLevel());
            }
            
        }
    }

    IEnumerator DelayNextLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("RandomizerUI"); // loads mainmenu [next level if build is completed]
    }
}
