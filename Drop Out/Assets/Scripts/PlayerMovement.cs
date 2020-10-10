using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   

    public CharacterController controller;
    public float speed = 15f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    Vector3 moveDir = Vector3.zero;
    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (controller.isGrounded) 
		{
            if(Input.GetKey(KeyCode.Space))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                Stop();
            }
            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveDir = new Vector3 (0, 0, 20); 
                moveDir *= speed;
                moveDir = transform.TransformDirection (moveDir);
            }

        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }
   
    void Stop()
	{
		StartCoroutine (Slowstop());
        
	}
	IEnumerator Slowstop()
	{
		moveDir = new Vector3 (0, 0, 11);
		moveDir *= speed;
		moveDir = transform.TransformDirection (moveDir);  
		yield return new WaitForSeconds (1);
		moveDir = new Vector3 (0, 0, 6);
		moveDir *= speed;
		moveDir = transform.TransformDirection (moveDir);  
		yield return new WaitForSeconds (1);
		moveDir = new Vector3 (0, 0, 0);
		moveDir *= speed;
		moveDir = transform.TransformDirection (moveDir);  
		
	}
}
