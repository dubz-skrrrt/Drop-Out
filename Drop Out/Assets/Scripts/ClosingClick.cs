using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingClick : MonoBehaviour
{
    public GameObject Text;
    public GameObject Text1;
    public GameObject StartButton;    
    public void Start() {
        PlayPanel();
    }
    public void PlayPanel()
    {
        if(Text != null)
        {
            Text.SetActive(false);
        }
        if(Text1 != null)
        {
            Text1.SetActive(false);
        }
        if(StartButton != null)
        {
            StartButton.SetActive(false);
        }
    }
}
