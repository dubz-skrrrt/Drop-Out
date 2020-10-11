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
    public bool isGrounded = true;
    private bool isjumping;
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
    }

    private void Update()
    {
        Debug.Log(isGrounded);
        // float hor = Input.GetAxis("Horizontal");
        // float ver = Input.GetAxis("Vertical");
        //  Vector3 move = (hor * moveSpeed * Time.deltaTime) + (ver * moveSpeed * Time.deltaTime);
        //  transform.Translate(move);
        float fallVelocity = rb.velocity.z;
        if (Input.GetKey(KeyCode.W)){
            //rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
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
        // if (isGrounded){
            

        if (Input.GetKeyDown(KeyCode.Space)){
            isjumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            anim.SetTrigger("Jump");
                
        }
        // }
        

        //getup
        if (Input.GetKeyDown(KeyCode.U)){
            anim.enabled = true;
            TurnOffRagdoll();
        }

        rb.velocity += Vector3.down * fallVelocity;
    }

    private void OnCollisionEnter(Collision collision){
        isjumping = false;
    }
    // private void OnCollisionExit(Collision collision){
    //     if (isjumping == false){
    //         anim.enabled = false;
    //         TurnOnRagdoll();
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
    }
}
