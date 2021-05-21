using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public static float distance=2.5f;
    public static int distancebomb = 1;
    [SerializeField] GameObject destroyanimation;
    [SerializeField] private List<GameObject> instantiators;
    [SerializeField] private LayerMask destructibleMask;
    [SerializeField] private LayerMask EnemyMask;
    [SerializeField] private LayerMask PLayerMask;
    [SerializeField] private LayerMask undestructibleMask;
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
                    if (checkCollision(transform.forward,destructibleMask))
                    {
                        Physics.Raycast(this.transform.position, transform.forward, out hit, destructibleMask);
                        Destroy(hit.transform.gameObject);
                    }
                    else if (checkCollision(transform.forward, EnemyMask))
                    {
                        Physics.Raycast(this.transform.position, transform.forward, out hit, destructibleMask);
                        hit.transform.GetComponent<Enemy>().StopAllCoroutines();
                        hit.transform.GetComponent<Enemy>().goingtodie = true;
                        hit.transform.GetComponent<Animator>().Play("damage");
                        Destroy(hit.transform.gameObject,1);
                    }
                    else if (checkCollision(transform.forward, PLayerMask))
                    {
                        Physics.Raycast(this.transform.position, transform.forward, out hit, destructibleMask);
                        hit.transform.GetComponent<Animator>().Play("Get hit");
                        hit.transform.GetComponent<Player>().lives--;
                        if (hit.transform.GetComponent<Player>().lives <= 0)
                        {
                            GameManager.gameover = true;
                            GameManager.win = false;
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        }
                        hit.transform.GetComponent<Player>().RespawnPlayer();
                    }
                    else if (!checkCollision(transform.forward, undestructibleMask))
                    {
                        for (float j = 2.5f; j <= distance; j += 2.5f)
                        {
                            instantiators.Add(Instantiate(destroyanimation,
                                new Vector3(this.transform.position.x, this.transform.position.y,
                                    this.transform.position.z + j), Quaternion.identity));
                        }
                    }
                    break;
                case 1:
                    if (checkCollision(-transform.forward, destructibleMask))
                    {
                        Physics.Raycast(this.transform.position, -transform.forward, out hit, destructibleMask);
                        Destroy(hit.transform.gameObject);
                    }
                    else if (checkCollision(-transform.forward, EnemyMask))
                    {
                        Physics.Raycast(this.transform.position, -transform.forward, out hit, destructibleMask);
                        hit.transform.GetComponent<Enemy>().StopAllCoroutines();
                        hit.transform.GetComponent<Enemy>().goingtodie = true;
                        hit.transform.GetComponent<Animator>().Play("damage");
                        Destroy(hit.transform.gameObject, 1);
                    }
                    else if (checkCollision(-transform.forward, PLayerMask))
                    {
                        Physics.Raycast(this.transform.position, -transform.forward, out hit, destructibleMask);
                        hit.transform.GetComponent<Animator>().Play("Get hit");
                        hit.transform.GetComponent<Player>().lives--;
                        if (hit.transform.GetComponent<Player>().lives <= 0)
                        {
                            GameManager.gameover = true;
                            GameManager.win = false;
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        }
                        hit.transform.GetComponent<Player>().RespawnPlayer();
                    }
                    else if (!checkCollision(-transform.forward, undestructibleMask))
                    {
                        for (float j = 2.5f; j <= distance; j += 2.5f)
                        {
                            instantiators.Add(Instantiate(destroyanimation,
                                new Vector3(this.transform.position.x, this.transform.position.y,
                                    this.transform.position.z - j), Quaternion.identity));
                        }
                    }
                    break;
                case 2:
                    if (checkCollision(transform.right, destructibleMask))
                    {
                        Physics.Raycast(this.transform.position, transform.right, out hit, destructibleMask);
                        Destroy(hit.transform.gameObject);
                    }
                    else if (checkCollision(transform.right, EnemyMask))
                    {
                        Physics.Raycast(this.transform.position, transform.right, out hit, destructibleMask);
                        hit.transform.GetComponent<Enemy>().StopAllCoroutines();
                        hit.transform.GetComponent<Enemy>().goingtodie = true;
                        hit.transform.GetComponent<Animator>().Play("damage");
                        Destroy(hit.transform.gameObject, 1);
                    }
                    else if (checkCollision(transform.right, PLayerMask))
                    {
                        Physics.Raycast(this.transform.position, transform.right, out hit, destructibleMask);
                        hit.transform.GetComponent<Animator>().Play("Get hit");
                        hit.transform.GetComponent<Player>().lives--;
                        if (hit.transform.GetComponent<Player>().lives <= 0)
                        {
                            GameManager.gameover = true;
                            GameManager.win = false;
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        }
                        hit.transform.GetComponent<Player>().RespawnPlayer();
                    }
                    else if (!checkCollision(transform.right, undestructibleMask))
                    {
                        for (float j = 2.5f; j <= distance; j += 2.5f)
                        {
                            instantiators.Add(Instantiate(destroyanimation,
                                new Vector3(this.transform.position.x + j, this.transform.position.y,
                                    this.transform.position.z), Quaternion.identity));
                        }
                    }
                    break;
                case 3:
                    if (checkCollision(-transform.right, destructibleMask))
                    {
                        Physics.Raycast(this.transform.position, -transform.right, out hit, destructibleMask);
                        Destroy(hit.transform.gameObject);
                    }
                    else if (checkCollision(-transform.right, EnemyMask))
                    {
                        Physics.Raycast(this.transform.position, -transform.right, out hit, destructibleMask);
                        hit.transform.GetComponent<Enemy>().StopAllCoroutines();
                        hit.transform.GetComponent<Enemy>().goingtodie = true;
                        hit.transform.GetComponent<Animator>().Play("damage");
                        Destroy(hit.transform.gameObject, 1);
                    }
                    else if (checkCollision(-transform.right, PLayerMask))
                    {
                        Physics.Raycast(this.transform.position, -transform.right, out hit, destructibleMask);
                        hit.transform.GetComponent<Animator>().Play("Get hit");
                        hit.transform.GetComponent<Player>().lives--;
                        if (hit.transform.GetComponent<Player>().lives <= 0)
                        {
                            GameManager.gameover = true;
                            GameManager.win = false;
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        }
                        hit.transform.GetComponent<Player>().RespawnPlayer();
                    }
                    else if (!checkCollision(-transform.right, undestructibleMask))
                    {
                        for (float j = 2.5f; j <= distance; j += 2.5f)
                        {
                            instantiators.Add(Instantiate(destroyanimation,
                                new Vector3(this.transform.position.x - j, this.transform.position.y,
                                    this.transform.position.z), Quaternion.identity));
                        }
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
