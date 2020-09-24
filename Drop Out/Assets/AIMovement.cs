using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;
    public GameObject Enemy;

    CharacterController controller;
    // private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Times();
    }
  
    void Times()
	{
		StartCoroutine (Timer());
	}
	IEnumerator Timer()
	{
		yield return new WaitForSeconds (3);
        Enemy.transform.position += Enemy.transform.forward * Time.deltaTime * speed;
	}
}
 

