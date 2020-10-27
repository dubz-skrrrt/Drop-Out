using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    Color[] randColors = new Color[9];
    public GameObject objChangeColor;
    public float timeToChange = 0.1f;
    private float timeSinceChange = 0f;

    void Start()
    {
        randColors[0] = Color.cyan;
        randColors[1] = Color.red;
        randColors[2] = Color.green;
        randColors[3] = new Color(255, 165, 0);
        randColors[4] = Color.yellow;
        randColors[5] = Color.magenta;   
        randColors[6] = Color.blue;
        randColors[7] = new Color(204, 0 ,204);
        randColors[8] = new Color(255, 153, 255);
        randColors[9] = new Color(201, 118, 11);
    }

    void Update(){

        timeSinceChange += Time.deltaTime;
        if (timeSinceChange >= timeToChange){
            randomColorChange();
        }
        
    }
    void randomColorChange(){
        objChangeColor.GetComponent<Renderer>().material.color = randColors[Random.Range(0, randColors.Length)];
        timeSinceChange = 0f;
    }
    
}
