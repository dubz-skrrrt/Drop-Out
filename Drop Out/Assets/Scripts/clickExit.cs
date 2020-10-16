using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickExit : MonoBehaviour
{
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
