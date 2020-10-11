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
    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;

    }
    void LateUpdate()
    {

        if (rotateAroundPlayer)
        {
            Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);

            cameraOffset = turnAngle * cameraOffset;
        }
       Vector3 newPos = playerTransform.position + cameraOffset;

       transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

       if (lookAtPlayer || rotateAroundPlayer)
       {
           transform.LookAt(playerTransform);
       }
    }


}

