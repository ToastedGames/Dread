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
    public float[] stepSizes;
    public LayerMask obstacles;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets the new targets of the legs if the legEnd is too far from the desiredLegPosition or an obsacle cuts of a leg
        for (int i = 0; i < legEnds.Length; i++)
        {
            
            if(Vector3.Distance(legEnds[i].position, desiredLegPositions[i].position) > stepSizes[i] || Vector3.Distance(legEnds[i].position,transform.position) > legLength)
            {              

                legEnds[i].position = desiredLegPositions[i].position;

            }
                RaycastHit2D hit = Physics2D.Raycast(transform.position, (legEnds[i].position - transform.position).normalized, legLength, obstacles);
            if(hit)
            {
                legEnds[i].position = hit.point;
            }

            
        }
        Vector2 dir = -(transform.position - desiredPosition.position).normalized;
        rb.rotation = Quaternion.Slerp(Quaternion.Euler(0,0,rb.rotation), Quaternion.Euler(0,0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90), 10 * Time.deltaTime).eulerAngles.z;
        rb.position = Vector3.Lerp(transform.position, desiredPosition.position, speed * Time.deltaTime);
        
    }

}
