using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color[] randColors = new Color[12];
    Color original;
    public GameObject objChangeColor;

    public float timeToChange = 0.1f;
    private float timeSinceChange = 0f;
    public int minColorRange;
    public int maxColorRange;
    private bool answer;
    private bool startTimer;
    public float timer = 0f;
    private GameObject[] TVColor;
    private GameObject[] platforms;
    private int finalColor;

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

        TVColor = GameObject.FindGameObjectsWithTag("cubeColor");
        answer = false;
        timer = 0.0f;
        startTimer = true;
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
        
        if (answer == true){
            FinalAnswer();
        }
        timeSinceChange += Time.deltaTime;
        if (timeSinceChange >= timeToChange && startTimer == true){
            randomColorChange();
        }
        
    }
    void randomColorChange(){
        int newColor = Random.Range(minColorRange, maxColorRange);
        objChangeColor.GetComponent<Renderer>().material.color = randColors[newColor];

        timeSinceChange = 0f;
    }

    public void FinalAnswer()
    {
        finalColor = Random.Range(0, randColors.Length);
        foreach (GameObject cube in TVColor){
            cube.GetComponent<Renderer>().material.color = randColors[finalColor];
        }

        objChangeColor.GetComponent<Renderer>().material.color = original;
        
        answer = false;
        CorrectPlatform();
        
    }

    void CorrectPlatform(){
        platforms = GameObject.FindGameObjectsWithTag("colorPlatforms");
        foreach(GameObject plat in platforms)
        if (finalColor>plat.GetComponent<ColorChange>().minColorRange && finalColor<plat.GetComponent<ColorChange>().maxColorRange){
            Debug.Log(plat.GetComponent<ColorChange>().minColorRange);
            Debug.Log(plat.GetComponent<ColorChange>().maxColorRange);
            Debug.Log(plat.name);
            //plat.SetActive(false);
        }else{
            
        }
        
    }
    
}
