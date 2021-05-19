using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject destroyanimation;
    bool destroyLeft()
    {
        return true;
    }
    bool destroyRight()
    {
        return true;
    }
    bool destroyUp()
    {
        return true;
    }
    bool destroyDown()
    {
        return true;
    }
    void OnDestroy()
    {
        GameObject auxanimationdestroy;
        auxanimationdestroy= Instantiate(destroyanimation, this.transform.position, Quaternion.identity);
        Destroy(auxanimationdestroy,3);
    }

    void Start()
    {

    }
}
