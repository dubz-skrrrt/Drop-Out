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
     public bool revert;
     public int finalColor;
     public bool activateMe;
     public bool restart;
     public bool allActive;
    void Start()
    {
        //colorScript = gameObject.GetComponent<ColorChange>();
        TVColor = GameObject.FindGameObjectsWithTag("cubeColor");
        platforms = GameObject.FindGameObjectsWithTag("colorPlatforms");
        finalColor = Random.Range(0, colorScript.randColors.Length);
        CurrentColor = finalColor;
        // int finalColor = 9;
        revert = true;
        activateMe = false;
        restart = false;
    }

    void Update(){
        if (revert == false){
            randomFinalColor();
            revert = true;
        }
        if (restart == true){
            activateMe = false;
            restart = false;
            allActive = false;
            
        }
        Debug.Log("Activated:" + activateMe);
        if (activateMe){
            foreach(GameObject plat in platforms){
                if (allActive == true){
                    //Debug.Log(plat.name);
                    restart = true;
                    CurrentColor = finalColor;
                    foreach (GameObject tvScreen in TVColor){
                        tvScreen.GetComponent<Renderer>().material.color = colorScript.original;
                    }
                }
                if (CurrentColor>=plat.GetComponent<ColorChange>().minColorRange && CurrentColor<plat.GetComponent<ColorChange>().maxColorRange && plat.activeSelf){
                    //plat.GetComponent<Renderer>().material.color = randColors[finalScript.CurrentColor];
                }else{
                    plat.GetComponent<ColorChange>().timer = 0.0f;
                    if (activePlat == false){
                        revert = false;
                        plat.SetActive(false);
                    } 
                    else {
                        if (!plat.activeSelf){
                            plat.SetActive(true);
                            allActive =true;
                            plat.GetComponent<ColorChange>().startTimer = true;
                        }
                        
                    }
                }
            }
        }
        
    }
     public void FinalAnswer()
    {
        foreach (GameObject cube in TVColor){
            cube.GetComponent<Renderer>().material.color = colorScript.randColors[CurrentColor];
        }
        // colorScript.answer = false;
        activateMe = true;
       //CorrectPlatform();
        
    }

    void randomFinalColor(){
        if (activateMe){
            finalColor = Random.Range(0, colorScript.randColors.Length);
        }
        
    }
}
