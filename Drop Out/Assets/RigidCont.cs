using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidCont : MonoBehaviour
{
    public float WalkSpeed;
    public float JumpForce;
    public bool Jumps;
    public float CurrentSpeed;

    private float xAxis;
    private float zAxis;
    private Rigidbody rb;
    private RaycastHit hit;
    private Vector3 groundLocation;
    private bool capsPressed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        CurrentSpeed = capsPressed ? WalkSpeed : WalkSpeed;
        Jumps = Input.GetButton("Jump");
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 10f, Color.blue);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 
        Mathf.Infinity));
        {
            if (string.Compare(hit.collider.tag, "ground", System.StringComparison.Ordinal) == 0)
            {
                groundLocation = hit.point;
            }
            var distanceFromPlayertoFround = Vector3.Distance(transform.position, groundLocation);
            if (distanceFromPlayertoFround > 1f)
            {
                Jumps = false;
            }
                
            
        }
    }
    private void FixedUpdate() {
        rb.MovePosition(transform.position + Time.deltaTime * CurrentSpeed *
        transform.TransformDirection(xAxis, 0f, zAxis));
        
        
    }
    private void OnGUI() {
        capsPressed = Event.current.capsLock;
    }
    private void PlayerJump(float jumpForce, ForceMode forceMode)
    {
        rb.AddForce(jumpForce * rb.mass * Time.deltaTime * Vector3.up, forceMode);
        if(Jumps)
        {
            PlayerJump(JumpForce, forceMode);
        }
    }
}
