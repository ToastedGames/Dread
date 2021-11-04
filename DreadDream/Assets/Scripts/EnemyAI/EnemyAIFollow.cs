using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIFollow : EnemyAI
{
    public Transform[] waypointTransforms;

    int currentWaypointIndex;
    Vector3 targetPos;

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPos) < .3f)
        {
            NextWaypoint();
            movement.setTargetPos(targetPos);
        }
    }

    private void NextWaypoint()
    {
        currentWaypointIndex++;

        if (currentWaypointIndex >= waypointTransforms.Length)
            currentWaypointIndex = 0;

        targetPos = waypointTransforms[currentWaypointIndex].position;
    }
}
