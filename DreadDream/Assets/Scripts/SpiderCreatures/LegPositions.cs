using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegPositions : MonoBehaviour
{
    public float speed;
    public float legLength;
    public float maxStepDistance;
    [Space]
    public Transform desiredPosition;
    public Transform[] legEnds;
    public Transform[] desiredLegPositions;
    public LayerMask obstacles;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < legEnds.Length; i++)
        {
            
            if(Vector3.Distance(legEnds[i].position, desiredLegPositions[i].position) > maxStepDistance || Vector3.Distance(legEnds[i].position,transform.position) > legLength)
            {              

                legEnds[i].position = desiredLegPositions[i].position;

            }
                RaycastHit2D hit = Physics2D.Raycast(transform.position, (legEnds[i].position - transform.position).normalized, legLength, obstacles);
            if(hit)
            {
                legEnds[i].position = hit.point;
            }

            
        }
        rb.position = Vector3.Lerp(transform.position, desiredPosition.position, speed * Time.deltaTime);
        
    }
}
