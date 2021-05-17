using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private const float MINX = -12f;
    private const float MAXX = 19f;
    private const float MINZ = -14f;
    private const float MAXZ = 21f;
    [SerializeField] public GameObject player;
    [SerializeField] [Range(-10, 10)] public float camerax;
    [SerializeField] [Range(-10, 10)] public float cameray;
    [SerializeField] [Range(-10, 10)] public float cameraz;
    void Start()
    {
        
    }

    // Update is called once per frame
    bool isInWidthScenario()
    {
        return player.transform.position.x > MINX && player.transform.position.x<MAXX;
    }

    bool isInHeightScenario()
    {
        return player.transform.position.z < MAXZ && player.transform.position.z > MINZ;
    }
    void LateUpdate()
    {
        Vector3 pos = player.transform.position;
        pos.x += camerax;
        pos.y += cameray;
        pos.z += cameraz;
        if (isInWidthScenario() && isInHeightScenario())
        {
            transform.position = pos;
        }
        else if (!isInWidthScenario() && !isInHeightScenario())
        {
            transform.position = new Vector3(this.transform.position.x,pos.y, this.transform.position.z);
        }
        else if (!isInWidthScenario())
        {
            transform.position = new Vector3(this.transform.position.x,pos.y,pos.z);
        }else if (!isInHeightScenario())
        {
            transform.position = new Vector3(pos.x, pos.y, this.transform.position.z);
        }
        
    }
}
