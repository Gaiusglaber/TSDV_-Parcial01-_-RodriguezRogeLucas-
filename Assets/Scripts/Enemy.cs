using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        Idle, //0
        GoingToTarget, //1
        Dead, //2
    }
    
    [SerializeField] private RaycastHit hitforward;
    [SerializeField] public static int cantdead = 0;
    [SerializeField] public static int cantscore = 0;
    [SerializeField] private EnemyState state;
    [SerializeField] public bool goingtodie = false;

    private float t;
    bool rayCastForward()
    {

        Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hitforward, 3f);
        if (hitforward.transform == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Update()
    {
        if (!goingtodie&&!GameManager.gameover)
        {
            t += Time.deltaTime;
            switch (state)
            {
                case EnemyState.Idle:
                    StartCoroutine("IdleAnimation");
                    if (t > 1)
                    {
                        NextState();
                    }

                    break;
                case EnemyState.GoingToTarget:
                    StartCoroutine("WalkAnimation");
                    if (rayCastForward())
                    {
                        transform.position += transform.forward * Time.deltaTime;
                    }
                    if (t > 2)
                    {
                        if (!rayCastForward())
                        {
                            int randomrotation = Random.Range(0, 1);
                            if (randomrotation == 0)
                            {
                                transform.forward = -transform.right;
                            }
                            else
                            {
                                transform.forward = transform.right;
                            }
                        }
                        NextState();
                    }
                    break;
            }
        }
    }

    private void OnDestroy()
    {
        cantdead++;
        cantscore += 150;
    }

    private void NextState()
    {
        t = 0;
        int intState = (int)state;
        intState++;
        intState = intState % ((int)EnemyState.Dead);
        SetState((EnemyState)intState);
    }

    private void SetState(EnemyState es)
    {
        state = es;
    }

    IEnumerator IdleAnimation()
    {
        GetComponent<Animator>().Play("idle");
        yield return new WaitForSeconds(2);
        yield return null;
    }
    IEnumerator WalkAnimation()
    {
        GetComponent<Animator>().Play("walk");
        yield return new WaitForSeconds(2);
        yield return null;
    }
}
