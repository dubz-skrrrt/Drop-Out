﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce;
    public Transform goal;
    private Rigidbody rb;
    private Animator anim;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Running", true);
        if (agent.isOnOffMeshLink){
            Vector3 rbVel = rb.velocity;
            rbVel.y = jumpForce;
            rb.velocity = rbVel;
            anim.SetTrigger("Jump");
        }
    }
}