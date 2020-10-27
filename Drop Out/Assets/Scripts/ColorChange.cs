using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    
    public float activeTimer = 0f;
    private float timeSinceChange = 0f;
    private Color original;
    public GameObject objChangeColor;
    public Color[] randColors = new Color[12];
    public float timeToChange = 0.1f;
    public int minColorRange;
    public int maxColorRange;
    public bool answer;
    public bool startTimer;
    public float timer = 0f;
    public FinalColor finalScript;
    void Start()
    {
        original = Color.gray;
        randColors[0] = Color.cyan;
        randColors[1] = Color.red;
        randColors[2] = Color.green;
        randColors[3] = Color.white;
        randColors[4] = Color.yellow;
        randColors[5] = Color.magenta;   
        randColors[6] = Color.blue;
        randColors[7] = new Color32(204,102, 0, 255);
        randColors[8] = new Color32(102, 0, 102, 255);
        randColors[9] = new Color32(79, 33, 4, 255);
        randColors[10] = new Color32(0, 51, 102, 255);
        randColors[11] = Color.black;
        answer = false;
        timer = 0.0f;
        activeTimer = 0.0f;
        startTimer = true;
        finalScript.activePlat = true;
        
    }

    void Update(){
        //Debug.Log(timer);
        timer += Time.deltaTime;
        
        if (startTimer){
            if (timer > 10f){
            answer = true;
            startTimer = false;
            }
        }
        //Debug.Log(activeTimer);
        //Debug.Log("it is: " + activePlat);
        
        // if (activeTimer < 12f){         
        //     activeTimer += 0.05f;
        //     finalScript.activePlat = false;
        // }else{
        //     finalScript.activePlat = true;
        //     activeTimer = 0.0f;
        // }
        // if (activeTimer > 15f){
        //     activeTimer = 0.0f;
        //     timer = 0.0f;
        // }
        
        
        if (answer == true){
            finalScript.FinalAnswer();
            objChangeColor.GetComponent<Renderer>().material.color = original;
            // finalScript.CorrectPlatform();
            
        }else{
            timeSinceChange += Time.deltaTime;
            if (timeSinceChange >= timeToChange && startTimer == true){
                randomColorChange();

            }
        }
        
        
    }
    void randomColorChange(){

        int newColor = Random.Range(minColorRange, maxColorRange);
        objChangeColor.GetComponent<Renderer>().material.color = randColors[newColor];

        timeSinceChange = 0f;
    }


    
}
