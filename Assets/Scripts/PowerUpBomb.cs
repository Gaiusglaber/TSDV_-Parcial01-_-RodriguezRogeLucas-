using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBomb : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collisioninfo.transform.GetComponent<Player>().PowerBombs();
            Destroy(this.gameObject);
        }
    }
}
