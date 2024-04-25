using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject objetoActivar;

    // Método llamado cuando se presiona la tecla
    void Update()
    {
        // Si se presiona la tecla "O"
        if (Input.GetKey(KeyCode.O))
        {
            // Activa el objeto
            objetoActivar.SetActive(true);
        }
        else
        {
            // Si no se está presionando la tecla "O", desactiva el objeto
            objetoActivar.SetActive(false);
        }
    }
}
