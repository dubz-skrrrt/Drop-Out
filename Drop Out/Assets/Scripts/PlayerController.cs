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
    public bool isGrounded;
    public ConfigurableJoint cjoint;
    private bool isjumping;
    private bool onFloor = false;

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
        float fallVelocity = rb.velocity.z;
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
        // if (isGrounded){
            

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            isjumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            anim.SetTrigger("Jump");
            isGrounded = false;
                
        }
        // }
        

        //getup
        // if (Input.GetKeyDown(KeyCode.U)){
        //     anim.enabled = true;
        //     TurnOffRagdoll();
        // }
        Debug.Log(onFloor);
        rb.velocity += Vector3.down * fallVelocity;
        if (onFloor){
            if (cjoint.angularXDrive.positionSpring >= 100 && cjoint.angularYZDrive.positionSpring >= 100){
        Debug.Log("off");
        anim.enabled = true;
        TurnOffRagdoll();
        }
        }
        
    }

    private void OnCollisionEnter(Collision collision){
        isjumping = false;
        isGrounded = true;
        Debug.Log("grounded");
    }
    private void OnCollisionExit(Collision collision){
        if (isjumping == false){
            onFloor = true;
            TurnOnRagdoll();
            anim.enabled = false; 
        }
        
    }
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
