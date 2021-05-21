using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossPowerUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Bomb.distance += 2.5f;
            Bomb.distancebomb++;
            Destroy(this.gameObject);
        }
    }
}
