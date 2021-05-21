using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] static public int cantdestroyed = 0;
    [SerializeField] static public int cantscore = 0;
    [SerializeField] private static bool doorspawn = false;
    public GameObject door;

    void OnDestroy()
    {
        cantdestroyed++;
        cantscore += 50;
        if (!doorspawn)
        {
            int randomnumberdoor = Random.Range(0, 4);
            if (randomnumberdoor==1 ||cantdestroyed==EntitiesInstantiator.randomBoxGenerator)
            {
                Instantiate(door, new Vector3(this.transform.position.x,this.transform.position.y-1f,this.transform.position.z),
                    new Quaternion(this.transform.rotation.x-0.9f, this.transform.rotation.y,
                        this.transform.rotation.z, (float) Space.Self));
                doorspawn = true;
            }
        }
    }
}
