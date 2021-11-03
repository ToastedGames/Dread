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

public class EnemyAIFollowAgressive : MonoBehaviour
{
    /*public void ChangeState(EnemyMovementState state)
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
    }*/
}
