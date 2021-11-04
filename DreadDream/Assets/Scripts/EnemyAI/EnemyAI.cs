using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class EnemyAI : MonoBehaviour
{
    protected EnemyMovement movement;

    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
    }
}
