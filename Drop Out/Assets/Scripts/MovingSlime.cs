﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSlime : MonoBehaviour
{
    public float speedX = 0.0f;
    public float speedY = 0.01f;
    private float curX;
    private float curY;
    public float speed;
    public float conveyorVelocity;

    // Start is called before the first frame update
    void Start()
    {
        curX = GetComponent<Renderer>().material.mainTextureOffset.x;
        curY = GetComponent<Renderer>().material.mainTextureOffset.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        curX += Time.deltaTime * speedX;
        curY += Time.deltaTime * speedY;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, curY));
    }

    void OnCollisionStay(Collision other){
        if (other.gameObject.tag == "Player"){
            //return;
            Debug.Log("moving");
            conveyorVelocity = speed * Time.deltaTime;
            other.gameObject.GetComponent<Rigidbody>().velocity = conveyorVelocity * transform.forward; 
            //rigidbody.velocity = conveyorVelocity * transform.forward;
        }
    }
}
