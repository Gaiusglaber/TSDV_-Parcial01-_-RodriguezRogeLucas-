using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntitiesInstantiator : MonoBehaviour
{
    [SerializeField] private float[] posX = new float[10];
    [SerializeField] private float[] posZ = new float[10];
    [SerializeField] public static int randomBoxGenerator;
    [SerializeField] private const float startingPointX = -18.5f;
    [SerializeField] private const float endingPointX = 26.5f;
    [SerializeField] private const float startingPointZ = 27.5f;
    [SerializeField] private const float endingPointZ = -17.5f;
    [SerializeField] private const float distance = 5f;
    [SerializeField] private GameObject box;
    [SerializeField] private List<float> posXRandom;
    [SerializeField] private List<float> posZRandom;

    private bool isDupX(int tmp)
    {
        foreach (var item in posXRandom)
        {
            if (item == tmp)
            {
                return true;
            }
        }
        return false;
    }
    private bool isDupZ(int tmp)
    {
        foreach (var item in posZRandom)
        {
            if (item == tmp)
            {
                return true;
            }
        }
        return false;
    }
    void Start()
    {
        randomBoxGenerator = Random.Range(10, 15);
        int auxitx = 0;
        for (float i = startingPointX; i < endingPointX; i += distance)
        {
            posX[auxitx] = i;
            auxitx++;
        }
        int auxitz = 0;
        for (float i = startingPointZ; i > endingPointZ; i -= distance)
        {
            posZ[auxitz] = i;
            auxitz++;
        }
        for (short i = 0; i < randomBoxGenerator; i++)
        {
            int randomNumberX = Random.Range(0, 9);
            int randomNumberZ = Random.Range(0, 9);
            int tmp = randomNumberX;
            while (isDupX(tmp))
            {
                Debug.Log("estoy adentro de x");
                tmp = Random.Range(0, 9);
            }
            posXRandom.Add(posX[tmp]);
            tmp = randomNumberZ;
            while (isDupZ(tmp))
            {
                Debug.Log("estoy adentro de z");
                tmp = Random.Range(0, 9);
            }
            posZRandom.Add(posZ[tmp]);
            GameObject instantiateBox = Instantiate(box,
                new Vector3(posXRandom[i], 4.5f, posZRandom[i]), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
