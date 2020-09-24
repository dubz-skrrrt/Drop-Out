using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushFan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        this.GetComponent<Rigidbody>().AddForce(Vector3.left * 100f);
    }
}
