using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickExit : MonoBehaviour
{
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        SoundManager.PlaySound("Byebye");
        Application.Quit();
    }

}
