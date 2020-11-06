using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneRotate : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0.3f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0);
    }
}
