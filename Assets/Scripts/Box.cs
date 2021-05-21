using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] static public int cantdestroyed = 0;
    [SerializeField] static public int cantscore = 0;
    [SerializeField] private static bool doorspawn = false;
    public GameObject PowerUpLife;
    public GameObject PowerUpBomb;
    public GameObject PowerUpCross;
    public GameObject door;

    void OnDestroy()
    {
        if (!GameManager.gameover)
        {
            int randomnumber = Random.Range(0, 4);
            cantdestroyed++;
            cantscore += 50;
            if (!doorspawn)
            {
                if (randomnumber == 1 || cantdestroyed == EntitiesInstantiator.randomBoxGenerator)
                {

                    GameObject doorinstantiator = Instantiate(door,
                        new Vector3(this.transform.position.x, this.transform.position.y - 1f,
                            this.transform.position.z),
                        new Quaternion(this.transform.rotation.x - 0.9f, this.transform.rotation.y,
                            this.transform.rotation.z, (float) Space.Self));
                    doorinstantiator.AddComponent<Rigidbody>();
                    doorinstantiator.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    doorspawn = true;
                }
            }

            if (randomnumber == 0)
            {
                Instantiate(PowerUpCross, transform.position, Quaternion.identity);
            }
            if (randomnumber == 2)
            {
                Instantiate(PowerUpLife, transform.position, Quaternion.identity);
            }

            if (randomnumber == 3)
            {
                Instantiate(PowerUpBomb, transform.position, Quaternion.identity);
            }
        }
    }
}
