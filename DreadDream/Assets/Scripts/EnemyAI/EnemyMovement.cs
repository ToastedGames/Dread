using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Related")]
    public float speed;
    public bool useRigidbody;


    Vector3 targetPos;

    Rigidbody2D rb;

    private void Start()
    {
        if (useRigidbody)
            rb = GetComponent<Rigidbody2D>();
    }


    public void setTargetPos(Vector3 targetPos)
    {
        this.targetPos = targetPos;
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
        Vector3 moveDirection = (targetPos - transform.position).normalized;
        rb.MovePosition(transform.position + (moveDirection * speed * Time.fixedDeltaTime));
    }
    private void MoveWithTransform()
    {
        Vector3 moveDirection = (targetPos - transform.position).normalized;
        transform.Translate(moveDirection * speed * Time.fixedDeltaTime);
    }
}
