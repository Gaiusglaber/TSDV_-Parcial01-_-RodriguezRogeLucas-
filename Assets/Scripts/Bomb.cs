using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float distance=10f;
    [SerializeField] GameObject destroyanimation;
    [SerializeField] private List<GameObject> instantiators;
    [SerializeField] private LayerMask destructibleMask;
    [SerializeField] private LayerMask EnemyMask;
    [SerializeField] public Player player;

    bool checkCollision(Vector3 direction,LayerMask mask)
    {
        return (Physics.Raycast(transform.position, direction, distance, mask));
    }
    void OnDestroy()
    {
        for (short i = 0; i < 4; i++)
        {
            RaycastHit hit;
            switch (i)
            {
                case 0:
                    if (checkCollision(transform.forward,destructibleMask)|| checkCollision(transform.forward, EnemyMask))
                    {
                        Physics.Raycast(this.transform.position, transform.forward, out hit, destructibleMask);
                        Destroy(hit.transform.gameObject);
                    }
                    break;
                case 1:
                    if (checkCollision(-transform.forward, destructibleMask) || checkCollision(-transform.forward, EnemyMask))
                    {
                        Physics.Raycast(this.transform.position, -transform.forward, out hit, destructibleMask);
                        Destroy(hit.transform.gameObject);
                    }
                    break;
                case 2:
                    if (checkCollision(transform.right, destructibleMask) || checkCollision(transform.right, EnemyMask))
                    {
                        Physics.Raycast(this.transform.position, transform.right, out hit, destructibleMask);
                        Destroy(hit.transform.gameObject);
                    }
                    break;
                case 3:
                    if (checkCollision(-transform.right, destructibleMask) || checkCollision(-transform.right, EnemyMask))
                    {
                      
                        Physics.Raycast(this.transform.position, -transform.right, out hit, destructibleMask);
                        Destroy(hit.transform.gameObject);
                    }
                    break;
            }
        }
        instantiators.Add(Instantiate(destroyanimation, this.transform.position, Quaternion.identity));
        
        foreach (GameObject bomb in instantiators)
        {
            Destroy(bomb,3);
        }
        instantiators.Clear();
    }

    void Start()
    {

    }
}
