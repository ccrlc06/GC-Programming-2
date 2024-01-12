using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Review : MonoBehaviour
{
    void Start()
    {
        Debug.Log("hello world!");
        bool yes = true;
        bool no = false;
        char a = (char)65;  // same as 'A', see https://www.asciitable.com/
        string b = "b";
        int integer = 1 / 2;
        float fraction = 1.0f / 2.0f;
        Debug.Log(a);
        Debug.Log(integer);
        Debug.Log(fraction);

        // float doesn't have enough precision to store this number, so error makes it 1
        int i = (int)0.999999999999f;
        int j = (int)0.999999999999;
        Debug.Log(i);
        Debug.Log(j);

        Debug.Log("Bytes in a boolean: " + sizeof(bool));   // stores values 0 & 1
        Debug.Log("Bytes in a byte: " + sizeof(byte));      // stores values 0-255
        Debug.Log("Bytes in a character: " + sizeof(char));
        Debug.Log("Bytes in an integer: " + sizeof(int));
        Debug.Log("Bytes in a single-precision decimal: " + sizeof(float));
        Debug.Log("Bytes in a double-precision decimal: " + sizeof(double));
    }

    void Update()
    {
    }
}
