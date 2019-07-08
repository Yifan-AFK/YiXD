using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    float Prueba;
    // Use this for initialization
    void Start()
    {
        Prueba = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Prueba += 0.01f;
        Debug.Log(Prueba); 
    }
}