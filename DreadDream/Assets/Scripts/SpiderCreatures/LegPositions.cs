using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegPositions : MonoBehaviour
{
    public float legLength;
    public float maxStepDistance;
    [Space]
    public Transform[] legEnds;
    public Transform[] desiredLegPositions;
    public LayerMask obstacles;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < legEnds.Length; i++)
        {
            if(Vector3.Distance(legEnds[i].position, desiredLegPositions[i].position) > maxStepDistance)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, (desiredLegPositions[i].position - transform.position).normalized, legLength, obstacles);
                if (hit)
                {
                    legEnds[i].position = hit.point;
                }
                else
                {
                    legEnds[i].position = desiredLegPositions[i].position;
                }
            }
        }
    }
}
