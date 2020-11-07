using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitholeFinish : MonoBehaviour
{
    private int remaining = 2;
    public int maxQualification;
    public Randomizer1 qualifyingRounds;
    private int DropGuys;
    void Start(){
        qualifyingRounds.GameRound();
        maxQualification = qualifyingRounds.qualifiedNumber;
    }
    void OnTriggerEnter(Collider col)
    {
        // if player or enemy collides with pithole
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SetActive(false);
            StartCoroutine(ReturnToMenu());
            Cursor.lockState = CursorLockMode.None;
            
            
        }
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.SetActive(false);
            remaining -= 1;
            if (remaining == maxQualification)
            {
                //complete = true;
                //SoundManager.PlaySound("Yipee");
                Debug.Log("WIPEOUT!");
                Cursor.lockState = CursorLockMode.None;
                StartCoroutine(DelayNextLevel());
            }
            
        }
    }

    IEnumerator DelayNextLevel()
    {
        SoundManager.PlaySound("Yipee");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("RandomizerUI"); // loads mainmenu [next level if build is completed]
        DropGuys = remaining - 1;
    }
    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu"); // loads next level
    }
}
