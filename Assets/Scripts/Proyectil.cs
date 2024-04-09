using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int damage;
    public GameObject impactPrefab;
    public float velocidadBala;
    RaycastHit2D hit;
    public Rigidbody2D rb2d;

    Vector3 posicionAnterior;
    SonidosGameObject sonidosGO;
    ComboSystem comboSystem; // Referencia al sistema de combos

    private void Awake()
    {
        sonidosGO = GetComponent<SonidosGameObject>();
        comboSystem = FindObjectOfType<ComboSystem>(); // Encontrar el ComboSystem en la escena
    }

    IEnumerator Start()
    {
        posicionAnterior = transform.position;
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }

    private void Update()
    {
        Vector2 direccion = (transform.position - posicionAnterior);
        posicionAnterior = transform.position;

        hit = Physics2D.Raycast(transform.position, direccion.normalized, direccion.magnitude);

        if (hit.collider != null)
        {
            if (hit.transform.GetComponent<Damagable>() != null)
            {
                hit.transform.GetComponent<Damagable>().TakeDamage(damage);
                if (comboSystem != null)
                    comboSystem.IncreaseCombo(); // Incrementar el combo solo cuando golpea un enemigo
            }

            if (impactPrefab)
                Instantiate(impactPrefab, hit.point, Quaternion.identity);

            sonidosGO.ReproducirSonido();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = transform.right * velocidadBala;
    }
}
