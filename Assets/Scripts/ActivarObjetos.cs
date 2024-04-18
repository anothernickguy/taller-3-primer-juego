using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjetos : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el otro objeto tiene la etiqueta "Player" (o cualquier otra etiqueta que desees)
        if (other.CompareTag("Player"))
        {
            // Activar los GameObjects
            objeto1.SetActive(true);
            objeto2.SetActive(true);

            // Mostrar mensaje en consola
            Debug.Log("FIRE IN DA HOLE");
        }
    }
}
