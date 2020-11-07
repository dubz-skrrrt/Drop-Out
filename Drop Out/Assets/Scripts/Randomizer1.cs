using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Randomizer1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] level;
    int n;
    private int rounds;
    private void Start() {
        RandomLevel();
        rounds = 6;
    }
    public void RandomLevel() {
        n = Random.Range(1,7);
        Debug.Log(n);
        if(n == 1)
        {
            level[0].SetActive(true);
            level[1].SetActive(false);
            level[2].SetActive(false);
            level[3].SetActive(false);
            level[4].SetActive(false);
            level[5].SetActive(false);
            Timer1();
        }
        if(n == 2)
        {
            level[0].SetActive(false);
            level[1].SetActive(true);
            level[2].SetActive(false);
            level[3].SetActive(false);
            level[4].SetActive(false);
            level[5].SetActive(false);
            Timer2();
        }
         if(n == 3)
        {
            level[0].SetActive(false);
            level[1].SetActive(false);
            level[2].SetActive(true);
            level[3].SetActive(false);
            level[4].SetActive(false);
            level[5].SetActive(false);
            Timer3();
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
}
