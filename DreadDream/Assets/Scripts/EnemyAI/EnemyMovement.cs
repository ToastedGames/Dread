using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyMovementState
{
    Stop,
    Neutral,
    Agressive,
    Flee
}

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Related")]
    public float speed;
    public bool useRigidbody;

    [Header("State-Related")]
    public EnemyMovementState state;

    public Transform[] waypointTransforms;
    int currentWaypointIndex;

    public Transform playerTransform;

    Rigidbody2D rb;

    Vector3 targetPos;
    Vector3 moveDirection;


    private void Start()
    {
        if (useRigidbody)
            rb = GetComponent<Rigidbody2D>();

        ChangeState(state);
    }


    public void ChangeState(EnemyMovementState state)
    {
        this.state = state;

        switch (state)
        {
            case EnemyMovementState.Stop:
                targetPos = transform.position;
                break;
            case EnemyMovementState.Neutral:
                targetPos = waypointTransforms[currentWaypointIndex].position;
                break;
        }
    }

    private void Update()
    {
        if(state == EnemyMovementState.Agressive)
        {
            targetPos = playerTransform.position;
        }

        if(state == EnemyMovementState.Neutral && Vector3.Distance(transform.position, targetPos) < .3f)
        {
            NextWaypoint();
        }

        moveDirection = (targetPos - transform.position).normalized;
    }

    private void NextWaypoint()
    {
        currentWaypointIndex++;

        if (currentWaypointIndex >= waypointTransforms.Length)
            currentWaypointIndex = 0;

        targetPos = waypointTransforms[currentWaypointIndex].position;
    }


    private void FixedUpdate()
    {
        if(useRigidbody)
        {
            MoveWithRigidbody();
        } else
        {
            MoveWithTransform();
        }
    }

    private void MoveWithRigidbody()
    {
        rb.MovePosition(transform.position + (moveDirection * speed * Time.fixedDeltaTime));
    }
    private void MoveWithTransform()
    {
        transform.Translate(moveDirection * speed * Time.fixedDeltaTime);
    }
}
