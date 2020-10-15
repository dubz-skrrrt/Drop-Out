using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadRandomLevel() 
    {
        int level = Random.Range(1,4);
        SceneManager.LoadScene(level);
        Debug.Log("Scene Loaded");
    }
}
