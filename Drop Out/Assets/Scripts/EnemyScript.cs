using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    public bool isJumping;
    private Rigidbody rb;
    private Animator anim;
    private NavMeshAgent agent;
    public PlayerController playerScript;
    void Start()
    {
        goal = GameObject.Find("FinishLine").GetComponent<Transform>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isJumping){
            anim.SetBool("Running", true);
        }
        else{
            anim.SetBool("Running", false);
        }

        if (agent.isOnOffMeshLink && !isJumping){
            anim.SetTrigger("Jump");
            isJumping = true;
        }
        else{
            isJumping = false;
        }
    }
    void OnTriggerEnter(Collider col){
        
         if (col.gameObject.tag == "CanonStart"){
    
            foreach(GameObject Can in playerScript.canons)
            {
                Canon canScript = Can.GetComponent<Canon>();
                canScript.spawnStart = true;
                rb.freezeRotation = true;
            }
    
        }
    }

    void UpdateWaypoint(){
        
    }
}
