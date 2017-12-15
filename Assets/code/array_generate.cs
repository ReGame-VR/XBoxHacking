using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class array_generate : MonoBehaviour {
    public static int[] sequence=new int[100];
    
    // Use this for initialization
    void Start () {
        generateArray();

    }

    // Update is called once per frame
    void Update () {
    }
    void generateArray()
    {

        for (int i = 0; i < 100; i++)
        {
            sequence[i] = Random.Range(1, 5);
            while (i > 0 && sequence[i] == sequence[i - 1])
                sequence[i] = Random.Range(1, 5);
        }
    }
}
