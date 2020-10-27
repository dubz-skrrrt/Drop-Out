using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalColor : MonoBehaviour
{
    public GameObject[] TVColor;
    public ColorChange colorScript;
    public int CurrentColor;
    public GameObject[] platforms;

    public GameObject parentObj;
    public GameObject[] hiddenChildren;
     public bool activePlat;
     public bool revert;
     public int finalColor;
     private bool activateMe;
    void Start()
    {
        //colorScript = gameObject.GetComponent<ColorChange>();
        TVColor = GameObject.FindGameObjectsWithTag("cubeColor");
        platforms = GameObject.FindGameObjectsWithTag("colorPlatforms");
        finalColor = Random.Range(0, colorScript.randColors.Length);
        CurrentColor = finalColor;
        hiddenChildren = parentObj.GetComponentsInChildren<GameObject>(true);
        // int finalColor = 9;
        revert = true;
        activateMe = false;
    }

    void Update(){
        if (revert == false){
            Debug.Log(revert);
            Start();
            activateMe = false;
            revert = true;
        }
        Debug.Log("Activated:" + activateMe);
        if (activateMe){
            foreach(GameObject plat in platforms){
                if (CurrentColor>=plat.GetComponent<ColorChange>().minColorRange && CurrentColor<plat.GetComponent<ColorChange>().maxColorRange){
                    //plat.GetComponent<Renderer>().material.color = randColors[finalScript.CurrentColor];
                    Debug.Log("henlo");
                }else{
                    Debug.Log("henlo");
                    if (activePlat == false){
                        plat.SetActive(false);
                        revert = false;
                    } 
                    else {
                        foreach(GameObject colorPlat in hiddenChildren){
                            Debug.Log(colorPlat.name);
                            colorPlat.SetActive(true);
                        }
                        
                        Debug.Log("it is:" + activePlat);
                        colorScript.startTimer = true;  
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
}
