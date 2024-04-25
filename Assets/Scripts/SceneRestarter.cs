using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestarter : MonoBehaviour
{
    // Método llamado cuando se presiona una tecla
    void Update()
    {
        // Si se presiona la tecla "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reinicia la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
