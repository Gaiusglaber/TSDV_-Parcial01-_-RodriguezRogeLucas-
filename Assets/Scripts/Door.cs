using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text info;

    public void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            info.gameObject.SetActive(true);
            if (Enemy.cantdead < 4&&info.color.a>0)
            {
                info.color = new Color(info.color.r,info.color.g,info.color.b,info.color.a*Time.deltaTime);
            }
            else
            {
                info.gameObject.SetActive(false);
            }
        }
    }
}