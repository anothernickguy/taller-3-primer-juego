using UnityEngine;

public class ActivarObjetosEnColision : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si la colisión es con un objeto que tenga la capa "Player" (puedes cambiarla según tus necesidades)
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Activar los dos GameObjects
            if (objeto1 != null)
                objeto1.SetActive(true);
            if (objeto2 != null)
                objeto2.SetActive(true);

            // Imprimir un mensaje en la consola
            Debug.Log("FIRE IN DA HOLE");
        }
    }
}
