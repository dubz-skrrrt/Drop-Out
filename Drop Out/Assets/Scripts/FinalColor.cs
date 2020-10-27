using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalColor : MonoBehaviour
{
    public GameObject[] TVColor;
    public ColorChange colorScript;
    public int CurrentColor;
    public GameObject[] platforms;
     public bool activePlat;
    void Start()
    {
        //colorScript = gameObject.GetComponent<ColorChange>();
        TVColor = GameObject.FindGameObjectsWithTag("cubeColor");
        platforms = GameObject.FindGameObjectsWithTag("colorPlatforms");
        int finalColor = Random.Range(0, colorScript.randColors.Length);
        // int finalColor = 9;
        CurrentColor = finalColor;
        activePlat = true;
    }
     public void FinalAnswer()
    {
        Debug.Log(CurrentColor);
        foreach (GameObject cube in TVColor){
            cube.GetComponent<Renderer>().material.color = colorScript.randColors[CurrentColor];
        }
        
        colorScript.answer = false;
       
        
    }

    public void CorrectPlatform(){
        
        foreach(GameObject plat in platforms){
        if (CurrentColor>=plat.GetComponent<ColorChange>().minColorRange && CurrentColor<plat.GetComponent<ColorChange>().maxColorRange){
            //plat.GetComponent<Renderer>().material.color = randColors[finalScript.CurrentColor];
            
        }else{
            if (activePlat == false){
                plat.SetActive(false);
            } 
            else {
                plat.SetActive(true);
                colorScript.activeTimer = 0.0f;
                colorScript.timer = 0.0f;
                colorScript.startTimer = true;
            }
        }
        }
    }
}
