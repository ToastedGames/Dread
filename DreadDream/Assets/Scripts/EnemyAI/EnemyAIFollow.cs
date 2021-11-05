using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIFollow : EnemyAI
{
    public Transform[] waypointTransforms;
    //Make Debug lines for the Path Visible;
    public bool showPath = true;

    int currentWaypointIndex;
    Vector3 targetPos;

    private void Start()
    {
        UpdateTargetPos();
    }

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

    public void UpdateTargetPos()
    {
        targetPos = waypointTransforms[currentWaypointIndex].position;
        movement.setTargetPos(targetPos);
    }

    //Draw Graph Gizmos in Sceneview
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < waypointTransforms.Length; i++)
        {
            Vector3 nextPos = waypointTransforms.Length - 1 > i ? waypointTransforms[i + 1].position : waypointTransforms[0].position;
            Gizmos.DrawLine(waypointTransforms[i].position, nextPos);
            Gizmos.DrawSphere(waypointTransforms[i].position, .2f);
        }
    }
}
