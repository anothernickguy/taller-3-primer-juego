using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientacion : MonoBehaviour
{
    public Vector3 velocidad;
    Vector3 posAnterior;

    private void Start()
    {
        posAnterior = transform.position;
    }

    private void FixedUpdate()
    {
        velocidad = (transform.position - posAnterior) / Time.deltaTime;
        posAnterior = transform.position;

        if(velocidad.x > 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
}
