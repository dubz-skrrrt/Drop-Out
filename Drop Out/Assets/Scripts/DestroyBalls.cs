using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBalls : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObject, gameObject1, gameObject2;
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        //var gone = gameObject + gameObject1 + gameObject2;
        if (gameObject != null)
        {    
            // Do something  
            Destroy(gameObject);
        }
        if (gameObject1 != null)
        {    
            // Do something  
            Destroy(gameObject1);
        }
        if (gameObject2 != null)
        {    
            // Do something  
            Destroy(gameObject2);
        }
        
    }
}
