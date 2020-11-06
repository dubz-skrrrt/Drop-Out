using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningClick : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel1;
    public GameObject Panel2;

    public void PlayPanel()
    {
        if(Panel != null)
        {
            //bool isActive = Panel.activeSelf;
            Panel.SetActive(true);
        }
        if(Panel1 != null)
        {
            //bool isActive = Panel.activeSelf;
            Panel1.SetActive(true);
        }
        if(Panel2 != null)
        {
            //bool isActive = Panel.activeSelf;
            Panel2.SetActive(true);
        }
    }
}
