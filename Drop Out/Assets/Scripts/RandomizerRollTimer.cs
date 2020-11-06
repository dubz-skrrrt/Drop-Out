using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerRollTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;
    public GameObject Panel1;


    void Start()
    {
        Timer();
    }

    // Update is called once per frame
    void Timer()
    {
        StartCoroutine (Seconds());
    }
    IEnumerator Seconds()
    {
        if(Panel != null)
        {
            yield return new WaitForSeconds (4); 
            Panel.SetActive(true);
        }    
        if(Panel1 != null)
        {
            yield return new WaitForSeconds (4); 
            Panel1.SetActive(false);
        }      
    }
}
