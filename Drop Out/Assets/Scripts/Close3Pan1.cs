﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close3Pan1 : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;   
    public void ClosePanel()
    {
        if(Panel1 != null)
        {
            //bool isActive = Panel.activeSelf;
            Panel1.SetActive(false);
        }
        
    }
    public void ClosePanel1()
    {
        if(Panel2 != null)
        {
            //bool isActive = Panel.activeSelf;
            Panel2.SetActive(false);
        }
        
    }
    public void ClosePanel2()
    {
        if(Panel3 != null)
        {
            //bool isActive = Panel.activeSelf;
            Panel3.SetActive(false);
        }
        
    }
}
