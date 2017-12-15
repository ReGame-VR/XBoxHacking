using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequence : MonoBehaviour
{
    public static int[] sequence_1 = new int[100];
    void generateArray()
    {

        for (int i = 0; i < 100; i++)
        {
            sequence_1[i] = Random.Range(1, 5);
            while (i > 0 && sequence_1[i] == sequence_1[i - 1])
                sequence_1[i] = Random.Range(1, 6);
        }
    }
    // Use this for initialization
    void Start()
    {
        generateArray();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
