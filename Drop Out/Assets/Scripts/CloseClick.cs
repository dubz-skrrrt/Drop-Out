﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseClick : MonoBehaviour
{
    public GameObject Panel;


    public void PlayPanel()
    {
        if(Panel != null)
        {
            //bool isActive = Panel.activeSelf;
            
            Panel.SetActive(false);
        }
    }
}