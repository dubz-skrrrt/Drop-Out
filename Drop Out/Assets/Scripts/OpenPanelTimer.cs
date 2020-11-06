using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelTimer : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel1;
    public GameObject Panel2;

    // Update is called once per frame
    public void PlayPanel()
    {
        if(Panel != null)
        {
            //bool isActive = Panel.activeSelf;
            Timer();
            Panel.SetActive(true);
        }
        if(Panel1 != null)
        {
            //bool isActive = Panel.activeSelf;
            Timer();
            Panel1.SetActive(true);
        }
        if(Panel2 != null)
        {
            //bool isActive = Panel.activeSelf;
            Timer();
            Panel2.SetActive(true);
        }
        void Timer()
        {
            StartCoroutine (Seconds6());
        }
        IEnumerator Seconds6()
        {
            yield return new WaitForSeconds (4);
        }
        
    }
}
