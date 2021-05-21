using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
        }
    }
}
