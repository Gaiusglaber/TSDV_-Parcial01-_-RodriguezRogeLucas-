using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntitiesInstantiator : MonoBehaviour
{
    [SerializeField] private float[] posX = new float[10];
    [SerializeField] private float[] posZ = new float[10];
    [SerializeField] private const float startingPointX = -18.5f;
    [SerializeField] private const float endingPointX = 26.5f;
    [SerializeField] private const float startingPointZ = 27.5f;
    [SerializeField] private const float endingPointZ = -17.5f;
    [SerializeField] private const float distance = 5f;
    [SerializeField] private GameObject box;
    void Start()
    {
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
        for (short i = 0; i < Random.Range(10, 20); i++)
        {
            GameObject instantiateBox = Instantiate(box,
                new Vector3(posX[Random.Range(0, 9)], 4.5f, posZ[Random.Range(0, 9)]), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
