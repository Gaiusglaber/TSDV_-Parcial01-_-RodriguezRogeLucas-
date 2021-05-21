using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLife : MonoBehaviour
{
    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collisioninfo.transform.GetComponent<Player>().lives++;
            Destroy(this.gameObject);
        }
    }
}
