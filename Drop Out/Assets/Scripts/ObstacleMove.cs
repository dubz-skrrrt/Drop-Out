using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public GameObject cubes;
    private float interval;
    private bool dirRight;
    public float speed;
    public float max;
    // void Start(){
    //     StartCoroutine(Back_Forth());
    // }

    void Update(){
        if (!dirRight){
            cubes.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }else{
            cubes.transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }

        if (cubes.transform.position.x >= -8){
            dirRight = false;
        }
        
        if (cubes.transform.position.x <= -14.5f){
            Debug.Log(max);
            dirRight = true;
        }
    }

}
