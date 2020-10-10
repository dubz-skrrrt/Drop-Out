using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObs : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 RotateAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(RotateAmount * Time.deltaTime);
    }
}
