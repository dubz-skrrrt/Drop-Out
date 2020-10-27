using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClick2 : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel1;

    public void PlayPanel()
    {
        if(Panel != null)
        {
            //bool isActive = Panel.activeSelf;
            Panel.SetActive(true);
        }
    }
    public void PlayPanel1()
    {
        if(Panel1 != null)
        {
            //bool isActive = Panel.activeSelf;
            Panel1.SetActive(true);
        }
    }
}
