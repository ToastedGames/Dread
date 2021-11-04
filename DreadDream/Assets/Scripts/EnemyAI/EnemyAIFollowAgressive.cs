using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyMovementState
{
    Stop,
    Neutral,
    Agressive
}

[RequireComponent(typeof(EnemyAIAgressive), typeof(EnemyAIFollow))]
public class EnemyAIFollowAgressive : EnemyAI
{
    public EnemyMovementState state;

    EnemyAIAgressive agressiveAI;
    EnemyAIFollow followAI;

    private void Start()
    {
        agressiveAI = GetComponent<EnemyAIAgressive>();
        followAI = GetComponent<EnemyAIFollow>();

        ChangeState(state);
    }


    public void ChangeState(EnemyMovementState state)
    {
        this.state = state;

        switch (state)
        {
            case EnemyMovementState.Stop:
                followAI.enabled = false;
                agressiveAI.enabled = false;

                movement.setTargetPos(transform.position);
                break;

            case EnemyMovementState.Neutral:
                followAI.enabled = true;
                agressiveAI.enabled = false;

                followAI.UpdateTargetPos();
                break;

            case EnemyMovementState.Agressive:
                agressiveAI.enabled = true;
                followAI.enabled = false;
                break;
        }
    }
}
