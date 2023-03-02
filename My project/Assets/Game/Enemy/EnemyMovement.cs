using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Set on Inspector")]
    public Transform playerPos;
    public Transform[] waypoints;

    [Header("EnemyStatics")]
    public float speed;

    [Header("States")]

    private NavMeshAgent enemyAI;

    private void Start()
    {
        enemyAI = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        EnemyPetrol();
    }
    void EnemyPetrol()
    {
        if (GameManager.Instance.enemyState == EnemyGameState.Petrol)
        {
            for(int i = 0; i<5;i++)
            {
                enemyAI.destination = waypoints[i].position;
            }
        }
    }
}
