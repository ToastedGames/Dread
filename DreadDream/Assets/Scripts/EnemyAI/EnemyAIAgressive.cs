using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIAgressive : EnemyAI
{
    public Transform playerTransform;

    private void Update()
    {
        movement.setTargetPos(playerTransform.position);
    }
}
