﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;
    private float fForce;
    public bool moving;
    private Animator anim = null; 
    private Rigidbody rb;
    private Rigidbody[] rigBones = null;

    float inputX, inputY;
    Vector3 input, inputDir, moveAmount;
    public bool isGrounded;
    public ConfigurableJoint cjoint;
    private bool isjumping;
    Collider capsulePlayer;
    Collider[] boneColliders;
    private bool onFloor = false;
    private float angularDrive;
    public GameObject[] canons;
    public bool cameraChangeAngle;
    public Camera cam;
    private void Start()
    {
        moving = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rigBones = gameObject.GetComponentsInChildren<Rigidbody>().Where(x=> x.name.Contains("mixamorig")).ToArray();
        
        TurnOffRagdoll();

        capsulePlayer = GetComponent<Collider>();
        boneColliders = gameObject.GetComponentsInChildren<Collider>().Where(x=> x.name.Contains("mixamorig")).ToArray();

        for (int i = 0; i <boneColliders.Length; i++){
            Physics.IgnoreCollision(capsulePlayer, boneColliders[i], true);
        }
        isGrounded = true;
        Physics.IgnoreLayerCollision(10, 9, true);
        cameraChangeAngle = false;
    }

    private void Update()
    {

        //GetInput();
        if (onFloor){
            TurnOnRagdoll();
            if (angularDrive < 101){
                angularDrive += 25 * Time.deltaTime;
                //Debug.Log(angularDrive);
            }
        }else{
            if (angularDrive > 0){
                angularDrive -= 20 * Time.deltaTime;
            }
        }
        //Debug.Log("it is:" + moving);
        if (moving == true){
            if (Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * moveSpeed *Time.deltaTime);
            anim.SetBool("Running", true);
            }else{
                anim.SetBool("Running", false);
            }

            if (Input.GetKey(KeyCode.A)){
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D)){
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
            if (isGrounded){
                if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
                    SoundManager.PlaySound("Jumpsfx");
                    isjumping = true;
                    Vector3 rigidB = rb.velocity;
                    rigidB.y = jumpForce;
                    rb.velocity = rigidB;
                    //rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                    anim.SetTrigger("Jump");
                    isGrounded = false;
                }
            }
        }
        
        
//        Debug.Log(onFloor);
        if (onFloor){
            if (cjoint.angularXDrive.positionSpring >= 50 && cjoint.angularYZDrive.positionSpring >= 50){
                
                onFloor = false;
                anim.enabled = true;
                TurnOffRagdoll();   
                //anim.SetTrigger("Died");      
                moving = true;
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision){
        isjumping = false;
        isGrounded = true;
        

        if(collision.gameObject.tag == "ObstacleCourse")
        {
            rb.freezeRotation = true;
            
        }

        if (collision.gameObject.name == "Pilar" || collision.gameObject.tag =="Cannonball" || collision.gameObject.tag =="MortarProjectiles" || collision.gameObject.tag =="hitObstacles"){
            if (isjumping == false){
                onFloor = true;  
                TurnOnRagdoll();
                fForce = 5;
                var force = transform.position - collision.transform.position;
                force.Normalize();
                rb.AddForce(force *fForce, ForceMode.VelocityChange);
            }  
        }
       
    }

    void OnTriggerEnter(Collider col){
        
         if (col.gameObject.tag == "CanonStart"){
    
            foreach(GameObject Can in canons)
            {
                Canon canScript = Can.GetComponent<Canon>();
                canScript.spawnStart = true;
                rb.freezeRotation = true;
            }
    
        }
        if (col.gameObject.name == "CameraChangeCollider"){
            Debug.Log("Changed");
            cameraChangeAngle = true;
        }



    }

    private void TurnOffRagdoll()
    {
        foreach (Rigidbody r in rigBones){
            r.isKinematic = true;
            r.mass = 5;
        }
        
    }

    private void TurnOnRagdoll()
    {
         foreach (Rigidbody r in rigBones){
            r.isKinematic = false;
            r.mass = 0;
            
        }
        for (int i = 0; i <boneColliders.Length; i++){
            Physics.IgnoreCollision(capsulePlayer, boneColliders[i], false);
        }
        
        anim.enabled = false; 
        moving = false;
        JointDrive drive = new JointDrive();
        drive.positionSpring = angularDrive;
        cjoint.angularXDrive = drive;
        cjoint.angularYZDrive = drive;
    }

    

}
