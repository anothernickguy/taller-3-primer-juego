using UnityEngine;
using UnityEngine.UI;

public class ParallaxController : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public RawImage layer;
        public float speed = 1.0f;
        public bool freezeWidth = false; // Booleano para congelar el ancho (width) del uvRect
        public bool freezeHeight = false; // Booleano para congelar la altura (height) del uvRect
        [Header("MOVIMIENTO CONSTANTE")]
        public bool constantMovement = false; // Booleano para determinar si el movimiento es constante
        public float constantSpeed = 1.0f; // Velocidad para el movimiento constante
    }

    public ParallaxLayer[] parallaxLayers;

    Vector3 cameraPreviousPosition;

    void Start()
    {
        cameraPreviousPosition = Camera.main.transform.position;
    }

    void Update()
    {
        Vector3 cameraDelta = Camera.main.transform.position - cameraPreviousPosition;

        foreach (var layer in parallaxLayers)
        {
            if (layer.constantMovement)
            {
                ConstantParallaxMovement(layer.layer, layer.constantSpeed);
            }
            else
            {
                UpdateParallaxLayer(layer.layer, cameraDelta, layer.speed, layer.freezeWidth, layer.freezeHeight);
            }
        }

        // Actualizar la posición anterior de la cámara
        cameraPreviousPosition = Camera.main.transform.position;
    }

    void UpdateParallaxLayer(RawImage layer, Vector3 cameraDelta, float parallaxSpeed, bool freezeWidth, bool freezeHeight)
    {
        // Obtener los valores actuales de uvRect
        Rect uvRect = layer.uvRect;

        // Aplicar el desplazamiento parallax a los valores de uvRect
        if (!freezeWidth)
        {
            uvRect.x += cameraDelta.x * parallaxSpeed * Time.deltaTime;
        }
        if (!freezeHeight)
        {
            uvRect.y += cameraDelta.y * parallaxSpeed * Time.deltaTime;
        }

        // Aplicar los nuevos valores de uvRect
        layer.uvRect = uvRect;
    }

    void ConstantParallaxMovement(RawImage layer, float constantSpeed)
    {
        // Obtener los valores actuales de uvRect
        Rect uvRect = layer.uvRect;

        // Aplicar el movimiento parallax constante a los valores de uvRect
        uvRect.x += constantSpeed * Time.deltaTime;

        // Aplicar los nuevos valores de uvRect
        layer.uvRect = uvRect;
    }
}
