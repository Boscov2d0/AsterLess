using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcTest : MonoBehaviour
{
    string s = "5 + 1";

    private float minus(float a, float b) 
    {
        return  a - b;
    }
    private float plus(float a, float b)
    {
        return a + b;
    }
    private float multiply(float a, float b)
    {
        return a * b;
    }
    private float devided(float a, float b)
    {
        return a / b;
    }
}
