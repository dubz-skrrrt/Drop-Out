using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Vector3 cameraOffset;

    public Transform playerTransform;

    [Range (0.01f, 1.0f)]
    public float smoothFactor = 0.5f;
    public bool lookAtPlayer = false;

    public bool rotateAroundPlayer = true;
    public float rotateSpeed = 5.0f;
    public PlayerController playerControls;
    public Transform pivot;
    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
        pivot.transform.position = playerTransform.transform.position;
        pivot.transform.parent = playerTransform.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        Debug.Log(playerControls.cameraChangeAngle);
        if (rotateAroundPlayer)
        {
            Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);

            cameraOffset = turnAngle * cameraOffset;

            if(playerControls.cameraChangeAngle){
                Quaternion newAngle = Camera.main.transform.rotation;
                newAngle.x = -25;
                //cameraOffset = newAngle * cameraOffset;
            }
        }
       Vector3 newPos = playerTransform.position + cameraOffset;

       transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

       if (lookAtPlayer || rotateAroundPlayer)
       {
           transform.LookAt(playerTransform);
       }
    }

    // void OnTriggerEnter(Collider col){
    //     if (col.gameObject.tag == "CameraChangeCollider"){
    //         Debug.Log("camera");
    //         cam.transform.rotation *= Quaternion.Euler(-20, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);
    //         //Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x + 45, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);
    //         Debug.Log(Camera.main.transform.eulerAngles.x +"Change");
    //     }
    // }

}

