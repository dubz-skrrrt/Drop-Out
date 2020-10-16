using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;
    private Animator anim = null; 
    private Rigidbody rb = null;
    private Rigidbody[] rigBones = null;

    float inputX, inputY;
    Vector3 input, inputDir, moveAmount;
    public bool isGrounded;
    public ConfigurableJoint cjoint;
    private bool isjumping;
    private bool onFloor = false;
    private float angularDrive;
    public GameObject[] canons;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
        rigBones = gameObject.GetComponentsInChildren<Rigidbody>().Where(x=> x.name.Contains("mixamorig")).ToArray();
        
        TurnOffRagdoll();

        Collider capsulePlayer = GetComponent<Collider>();
        Collider[] boneColliders = gameObject.GetComponentsInChildren<Collider>().Where(x=> x.name.Contains("mixamorig")).ToArray();

        for (int i = 0; i <boneColliders.Length; i++){
            Physics.IgnoreCollision(capsulePlayer, boneColliders[i]);
        }
        isGrounded = true;
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
        }
        
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
                isjumping = true;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                anim.SetTrigger("Jump");
                isGrounded = false;
                
                    
            }
        }
        
//        Debug.Log(onFloor);
        if (onFloor){
            if (cjoint.angularXDrive.positionSpring >= 50 && cjoint.angularYZDrive.positionSpring >= 50){
                Debug.Log("off");
                onFloor = false;
                anim.enabled = true;
                TurnOffRagdoll();   
                anim.SetTrigger("Died");      
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision){
        isjumping = false;
        isGrounded = true;
        Debug.Log("grounded");

        if(collision.gameObject.tag == "ObstacleCourse")
        {
            rb.freezeRotation = true;
            
        }

        if(collision.gameObject.name == "deathCollider"){
            Debug.Log("dead");
        }
        if (collision.gameObject.tag == "hitObstacles"){
            if (isjumping == false){
            onFloor = true;  
            Debug.Log("hit");
            }  
        }
       
    }

    void OnTriggerEnter(Collider col){
        
         if (col.gameObject.tag == "CanonStart"){
             Debug.Log("start");
            foreach(GameObject Can in canons)
            {
                
                Canon canScript = Can.GetComponent<Canon>();
                canScript.spawnStart = true;
                rb.freezeRotation = true;
            }
    
        }
        if(col.gameObject.name == "ColliderTest")
        {
           Debug.Log("HIT!");
        }
    }
    // private void OnCollisionExit(Collision collision){
        
        
    // }

    //Joshel Test

    // private void OnControllerColliderHit(ControllerColliderHit col)
    // {
    //     if(col.gameObject.name == "ColliderTest")
    //     {
    //        Debug.Log("HIT!");
    //     }
    // }


    private void TurnOffRagdoll()
    {
        foreach (Rigidbody r in rigBones){
            r.isKinematic = true;
        }
    }

    private void TurnOnRagdoll()
    {

         foreach (Rigidbody r in rigBones){
            r.isKinematic = false;
        }
        anim.enabled = false; 

        JointDrive drive = new JointDrive();
        drive.positionSpring = angularDrive;
        cjoint.angularXDrive = drive;
        cjoint.angularYZDrive = drive;
    }

    

}
