using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private Animator myAnimator;
    private float distance;
    public Transform target;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
        if (distance >5)
        {
            myAgent.enabled = false;
            myAnimator.Play("Idle");
        }
        if (distance < 5 & distance>0.5 )
        {
            myAgent.enabled = true;
            myAgent.SetDestination(target.position);
            myAnimator.Play("Run");
        }
        if(distance<=0.5)
        {
            myAgent.enabled = false;
            myAnimator.Play("Attack");
        }
    }
}