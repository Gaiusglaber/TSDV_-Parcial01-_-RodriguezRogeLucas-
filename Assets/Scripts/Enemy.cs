using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        Idle, //0
        GoingToTarget, //1
        GoAway, //2
        Last,
    }

    [SerializeField] public static int cantdead = 0;
    [SerializeField] private EnemyState state;

    public float speed = 10;
    public float distanceToStop = 5;
    public float distanceToRestart = 10;

    public Transform target;

    private float t;

    private void Update()
    {
        t += Time.deltaTime;
        switch (state)
        {
            case EnemyState.Idle:
                if (t > 1)
                {
                    NextState();
                }
                break;
            case EnemyState.GoingToTarget:
                Vector3 dir = target.position - transform.position;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //, Space.World);
                if (Vector3.Distance(transform.position, target.position) < distanceToStop)
                    NextState();
                break;
            case EnemyState.GoAway:
                Vector3 dir02 = transform.position - target.position;
                transform.Translate(dir02.normalized * speed * Time.deltaTime, Space.World);
                if (Vector3.Distance(transform.position, target.position) > distanceToRestart)
                    NextState();
                break;
        }
    }

    private void OnDestroy()
    {
        cantdead++;
    }

    private void NextState()
    {
        t = 0;
        int intState = (int)state;
        intState++;
        intState = intState % ((int)EnemyState.Last);
        SetState((EnemyState)intState);
    }

    private void SetState(EnemyState es)
    {
        state = es;
    }
}
