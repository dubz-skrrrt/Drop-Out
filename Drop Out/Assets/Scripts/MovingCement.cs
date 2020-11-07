﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCement : MonoBehaviour
{
    public float speedX = 0.01f;
    public float speedY = 0.01f;
    
    private float curX;
    private float curY;
    public float movingY;
    // Start is called before the first frame update
    void Start()
    {
        curX = GetComponent<Renderer>().material.mainTextureOffset.x;
        curY = GetComponent<Renderer>().material.mainTextureOffset.y;
        movingY = 0.05f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        curX += Time.deltaTime * speedX;
        curY += Time.deltaTime * speedY;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(curX, curY));
        transform.Translate((Vector3.up * movingY *Time.deltaTime));
    }
}