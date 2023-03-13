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
    [SerializeField]
    private float stoppingDistance = 0.5f; 

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
        navMeshAgent.stoppingDistance = stoppingDistance;
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
        if (Vector3.Distance(transform.position, playerTransform.position) <= runDistance)
        {
            currentState = State.Running;
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsWalking", false);
        }
        else
        {
            navMeshAgent.SetDestination(playerTransform.position);
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", false);
        }
    }

    void Running()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) >= attackDistance)
        {
            currentState = State.Attacking;
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsAttacking", true);
        }
        else if (Vector3.Distance(transform.position, playerTransform.position) >= runDistance)
        {
            currentState = State.Walking;
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            navMeshAgent.SetDestination(playerTransform.position);
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsWalking", false);
        }
    }

    void Attacking()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) >= attackDistance)
        {
            currentState = State.Running;
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsAttacking", false);
            animator.SetTrigger("StopAttack");
        }
    }
}
