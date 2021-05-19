using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float distance=2;
    [SerializeField] GameObject destroyanimation;
    [SerializeField] private List<GameObject> instantiators;
    [SerializeField] private RaycastHit[] raycasts = new RaycastHit[4];
    bool destroyLeft()
    {
        Physics.Raycast(this.transform.position, -this.transform.right, out raycasts[0], distance);
        if (raycasts[0].transform != null)
        {
            if (raycasts[0].transform.tag == "Box")
            {
                Destroy(raycasts[0].transform.gameObject);
                return true;
            }else if (raycasts[0].transform.tag == "Wall")
            {
                return false;
            }
        }
        return true;
    }
    bool destroyRight()
    {
        Physics.Raycast(this.transform.position, this.transform.right, out raycasts[1], distance);
        if (raycasts[1].transform != null)
        {
            if (raycasts[1].transform.tag == "Box")
            {
                Destroy(raycasts[1].transform.gameObject);
                return true;
            }
            else if (raycasts[1].transform.tag == "Wall")
            {
                return false;
            }
        }
        return true;
    }
    bool destroyForward()
    {
        Physics.Raycast(this.transform.position, this.transform.forward, out raycasts[2], distance);
        if (raycasts[2].transform != null)
        {
            if (raycasts[2].transform.tag == "Box")
            {
                Destroy(raycasts[2].transform.gameObject);
                return true;
            }
            else if (raycasts[2].transform.tag == "Wall")
            {
                return false;
            }
        }
        return true;
    }
    bool destroyBack()
    {
        Physics.Raycast(this.transform.position, -this.transform.forward, out raycasts[3], distance);
        if (raycasts[3].transform != null)
        {
            if (raycasts[3].transform.tag == "Box")
            {
                Destroy(raycasts[3].transform.gameObject);
                return true;
            }
            else if (raycasts[3].transform.tag == "Wall")
            {
                return false;
            }
        }
        return true;
    }
    void OnDestroy()
    {
        instantiators.Add(Instantiate(destroyanimation, this.transform.position, Quaternion.identity));
        if (destroyLeft())
        {
            instantiators.Add(Instantiate(destroyanimation,
                new Vector3(this.transform.position.x-2.5f, this.transform.position.y, this.transform.position.z),
                Quaternion.identity));
        }
        if (destroyRight())
        {
            instantiators.Add(Instantiate(destroyanimation,
                new Vector3(this.transform.position.x + 2.5f, this.transform.position.y, this.transform.position.z),
                Quaternion.identity));
        }
        if (destroyForward())
        {
            instantiators.Add(Instantiate(destroyanimation,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+2.5f),
                Quaternion.identity));
        }
        if (destroyBack())
        {
            instantiators.Add(Instantiate(destroyanimation,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 2.5f),
                Quaternion.identity));
        }
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
