using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckDust : MonoBehaviour
{
    public GameObject dustCloud;

   void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.tag.Equals("ObstacleCourse")){
           Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
       }
   }
}
