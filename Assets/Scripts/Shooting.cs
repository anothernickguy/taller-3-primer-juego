using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootInterval = 5f;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 3f;

    private bool canShoot = true;

    private void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            if (canShoot)
            {
                ShootBullet();
                canShoot = false;
                yield return new WaitForSeconds(shootInterval);
                canShoot = true;
            }
            yield return null;
        }
    }

    void ShootBullet()
    {
        // Instancia el prefab de bala
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.Euler(0, 0, 180));

        // Obtiene el Rigidbody2D del prefab de bala
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Establece la velocidad en el eje Y para moverse en el eje Z del plano 2D
        rb.velocity = new Vector2(0, bulletSpeed);

        // Inicia la corrutina para destruir la bala después de un tiempo
        StartCoroutine(DestroyBulletAfterTime(bullet));
    }

    IEnumerator DestroyBulletAfterTime(GameObject bullet)
    {
        // Espera el tiempo de vida de la bala
        yield return new WaitForSeconds(bulletLifetime);

        // Destruye la bala
        Destroy(bullet);
    }
}