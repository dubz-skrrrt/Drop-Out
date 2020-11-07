using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    //private bool complete = false;
    public int qualified = 0;
    public int maxQualification;

    void OnTriggerEnter(Collider col)
    {
        // if player or enemy collides with finish line
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            col.gameObject.SetActive(false);
            qualified += 1;
            if (qualified == maxQualification)
            {
                //complete = true;
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
        SceneManager.LoadScene("RandomizerUI"); // loads next level
    }
}
