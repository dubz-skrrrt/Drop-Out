using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    //private bool complete = false;
    public int qualified = 0;
    public int maxQualification;
    public Randomizer1 qualifyingRounds;
    void Start(){
        qualifyingRounds.GameRound();
        maxQualification = qualifyingRounds.qualifiedNumber;
    }
    void OnTriggerEnter(Collider col)
    {
        // if player or enemy collides with finish line
        if (col.gameObject.tag == "Player")
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
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.SetActive(false);
            qualified += 1;
            if (qualified == maxQualification)
            {
                //complete = true;
                //SoundManager.PlaySound("Yipee");
                Debug.Log("WIPEOUT!");
                Cursor.lockState = CursorLockMode.None;
                StartCoroutine(ReturnToMenu());
            }
            
        }
    }

    IEnumerator DelayNextLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("RandomizerUI"); // loads next level
    }
     IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu"); // loads next level
    }
}
