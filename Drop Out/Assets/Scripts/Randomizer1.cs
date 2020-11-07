using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Randomizer1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] level;
    //public GameObject enemies;
    public int DropGuys = 3;
    int n;
    public bool respawn;
    public int qualifiedNumber;
    int timesScaf = 0;
    int timesWet = 0;
    int timesPit = 0;
    private int rounds = 6;
    private void Start() {
        if (n == 1 || n==5 || n==4){
            respawn = true;
        }else{
            respawn = false;
        }
        RandomLevel();

    }
    public void Update() {
        if(Input.GetKey(KeyCode.C)){
            RandomLevel();
        }
    }
    public void RandomLevel() {
        n = Random.Range(1,2);
        Debug.Log(n);
        
        if (timesScaf == 0){
            if(n == 1)
            {
                level[0].SetActive(true);
                level[1].SetActive(false);
                level[2].SetActive(false);
                level[3].SetActive(false);
                level[4].SetActive(false);
                level[5].SetActive(false);
                timesScaf = timesScaf + 1;
                Debug.Log("Times: "+timesScaf);
                Timer1();
            }
        }
        else{
            if (timesScaf == 1){
            Debug.Log("Times Random: "+timesScaf);
            level[1].SetActive(true);
            level[1].SetActive(false);
            level[2].SetActive(false);
            level[3].SetActive(false);
            level[4].SetActive(false);
            level[5].SetActive(false);
            n = Random.Range(1,3);
            }
        }

        if (timesWet == 0){
            if(n == 2)
            {
                level[0].SetActive(false);
                level[1].SetActive(true);
                level[2].SetActive(false);
                level[3].SetActive(false);
                level[4].SetActive(false);
                level[5].SetActive(false);
                timesWet = timesWet + 1;
                Debug.Log("Times: "+timesWet);
                Timer2();
            }
        } 
        else{
            if (timesWet == 1){
            level[0].SetActive(false);
            level[1].SetActive(true);
            level[2].SetActive(false);
            level[3].SetActive(false);
            level[4].SetActive(false);
            level[5].SetActive(false);
            Debug.Log("Times Random: "+timesWet);
            n = Random.Range(1,3);
            }
        }
        
        
        
        if (timesPit == 0){
            if(n == 3)
            {
                level[0].SetActive(false);
                level[1].SetActive(false);
                level[2].SetActive(true);
                level[3].SetActive(false);
                level[4].SetActive(false);
                level[5].SetActive(false);
                timesPit = timesPit + 1;
                Debug.Log("Times: "+timesPit);
                Timer3();
            }
        } 
        else{
            if (timesPit == 1){
            level[0].SetActive(false);
            level[1].SetActive(false);
            level[2].SetActive(false);
            level[3].SetActive(false);
            level[4].SetActive(false);
            level[5].SetActive(false);
            Debug.Log("Times Random: "+timesPit);
            n = Random.Range(1,3);
        }
        }
        
        if(n == 4)
        {
            level[0].SetActive(false);
            level[1].SetActive(false);
            level[2].SetActive(false);
            level[3].SetActive(true);
            level[4].SetActive(false);
            level[5].SetActive(false);
            Timer4();
        }
        if(n == 5)
        {
            level[0].SetActive(false);
            level[1].SetActive(false);
            level[2].SetActive(false);
            level[3].SetActive(false);
            level[4].SetActive(true);
            level[5].SetActive(false);
            Timer5();
        }
        if(n == 6)
        {
            level[0].SetActive(false);
            level[1].SetActive(false);
            level[2].SetActive(false);
            level[3].SetActive(false);
            level[4].SetActive(false);
            level[5].SetActive(true);
            Timer6();
        }
        GameRound();
    }
        
        
    void Timer1()
    {
        rounds -= 1;
        StartCoroutine (Seconds1());
    }
    IEnumerator Seconds1()
    {
        yield return new WaitForSeconds (6);
        SceneManager.LoadScene("Sca-fall-ding");
    }
    void Timer2()
    {
        rounds -= 1;
        StartCoroutine (Seconds2());
    }
    IEnumerator Seconds2()
    {
        yield return new WaitForSeconds (6);
        SceneManager.LoadScene("Wet Concrete");
        
    }
    void Timer3()
    {
        rounds -= 1;
        StartCoroutine (Seconds3());
    }
    IEnumerator Seconds3()
    {
        yield return new WaitForSeconds (6);
        SceneManager.LoadScene("The Pithole");
    }
    void Timer4()
    {
        rounds -= 1;
        StartCoroutine (Seconds4());
    }
    IEnumerator Seconds4()
    {
        yield return new WaitForSeconds (6);
        SceneManager.LoadScene("Mortar Enemy");

    }
    void Timer5()
    {
        rounds -= 1;
        StartCoroutine (Seconds5());
    }
    IEnumerator Seconds5()
    {
        yield return new WaitForSeconds (6);
        SceneManager.LoadScene("Crash Course");
        
        
    }
    void Timer6()
    {
        rounds -= 1;
        StartCoroutine (Seconds6());
    }
    IEnumerator Seconds6()
    {
        yield return new WaitForSeconds (6);
        SceneManager.LoadScene("Sky Scraper");
       
        
    }

    public void GameRound(){

        if (rounds > 1){
            Debug.Log(rounds + " >");
            qualifiedNumber = 2;
        }else{
            Debug.Log(rounds + " <");
            qualifiedNumber = 1;
        }
    }

    public void respawnBool(){
        if (n == 1 || n==5 || n==4){
            respawn = true;
        }
    }
}
