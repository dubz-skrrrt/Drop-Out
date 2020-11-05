using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMesh : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] plats;
    void Start()
    {
        foreach(GameObject plat in plats){
            plat.GetComponent<Renderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
