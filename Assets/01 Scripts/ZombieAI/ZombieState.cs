using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieState : MonoBehaviour
{
    [SerializeField]
    private float attackDistance = 1f;
    [SerializeField]
    private float runDistance = 1.5f;
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float runSpeed = 1f;
    [SerializeField]
    private Transform playerTransform;

    private State currentState = State.Walking;
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    public enum State
    {
        Walking,
        Running,
        Attacking,
        fallingDown,
        StandUp
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = moveSpeed;
    }

    private void Update()
    {
        if (playerTransform == null) return;

        switch (currentState)
        {
            case State.Walking:
                Walking();
                break;
            case State.Running:
                Running();
                break;
            case State.Attacking:
                Attacking();
                break;
        }
    }

    void Walking()
    {
         float transformDifference = Vector3.Distance(transform.position, playerTransform.position);
        if (transformDifference <= runDistance)
        {
            currentState = State.Running;
            animator.SetBool("IsTracking", true);
        }
        else
        {
            navMeshAgent.SetDestination(playerTransform.position);
            animator.SetBool("IsTracking", false);

        }
    }

    void Running()
    {
        float transformDifference = Vector3.Distance(transform.position, playerTransform.position);
        if (transformDifference <= attackDistance)
        {
            currentState = State.Attacking;
            transform.LookAt(playerTransform);
            animator.SetTrigger("Attack");
            
        }
        else if (transformDifference <= runDistance) 
        { 
            transform.LookAt(playerTransform);
        }
        else 
        {
            navMeshAgent.SetDestination(playerTransform.position);
            transform.LookAt(playerTransform);
            animator.SetBool("IsTracking", false);
        }
    }

    void Attacking()
    {
        float transformDifference = Vector3.Distance(transform.position, playerTransform.position);
        if (transformDifference <= attackDistance)
        {
            currentState = State.Attacking;
            transform.LookAt(playerTransform);
            animator.SetTrigger("Attack");
        }
    }
}
