using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyStateChange : MonoBehaviour
{
    public EnemyAIFollowAgressive enemy;
    public EnemyMovementState defaultState;
    public EnemyMovementState triggerState;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            enemy.ChangeState(triggerState);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            enemy.ChangeState(defaultState);
        }
    }
}
