using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBalls : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObjectt, gameObject1, gameObject2;
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        //var gone = gameObject + gameObject1 + gameObject2;
        if (gameObjectt != null)
        {    
            // Do something  
            Destroy(gameObjectt);
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
