using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnsound : MonoBehaviour
{
    public AudioSource buttonFX;
    public AudioClip hover;
    public AudioClip click;

    public void HoverSound(){
        buttonFX.PlayOneShot(hover);
    }
    public void ClickSound(){
        buttonFX.PlayOneShot(click);
    }
}
