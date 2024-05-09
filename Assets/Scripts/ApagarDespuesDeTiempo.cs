using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarDespuesDeTiempo : MonoBehaviour
{
    public float tiempoParaApagar = 3f; // Tiempo en segundos antes de apagar el objeto

    private float tiempoTranscurrido = 0f;
    private bool apagado = false;

    void Update()
    {
        if (!apagado)
        {
            tiempoTranscurrido += Time.deltaTime;

            if (tiempoTranscurrido >= tiempoParaApagar)
            {
                ApagarObjeto();
            }
        }
    }

    void ApagarObjeto()
    {
        apagado = true;
        gameObject.SetActive(false);
    }
}
