using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    protected EnemyMovement movement;

    private void Start()
    {
        movement = GetComponent<EnemyMovement>();
    }
}
