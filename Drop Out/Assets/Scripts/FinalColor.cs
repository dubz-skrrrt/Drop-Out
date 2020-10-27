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
     private bool activateMe;
     public bool restart;
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
            Debug.Log(revert);
            randomFinalColor();
            //activateMe = false;
            revert = true;
        }
        Debug.Log("Activated:" + activateMe);
        if (activateMe){
            foreach(GameObject plat in platforms){
                if (CurrentColor>=plat.GetComponent<ColorChange>().minColorRange && CurrentColor<plat.GetComponent<ColorChange>().maxColorRange && plat.activeSelf){
                    //plat.GetComponent<Renderer>().material.color = randColors[finalScript.CurrentColor];
                }else{
                    
                    if (activePlat == false){
                        plat.SetActive(false);
                        revert = false;
                    } 
                    else {
                        if (!plat.activeSelf){
                            plat.SetActive(true);
                            restart = true;

                        }
                        // CurrentColor = finalColor;
                    }
                }
            }
        }
        
    }
     public void FinalAnswer()
    {
        Debug.Log(CurrentColor);
        foreach (GameObject cube in TVColor){
            cube.GetComponent<Renderer>().material.color = colorScript.randColors[CurrentColor];
        }
        colorScript.answer = false;
        activateMe = true;
       //CorrectPlatform();
        
    }

    void randomFinalColor(){
        if (activateMe){
            finalColor = Random.Range(0, colorScript.randColors.Length);
        }
        
    }
}
