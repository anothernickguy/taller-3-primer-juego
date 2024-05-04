using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAlt : MonoBehaviour
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
        // Instantiate the bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the bullet prefab
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set the velocity on the negative x-axis to move left in the 2D plane
        rb.velocity = new Vector2(-bulletSpeed, 0);

        // Start the coroutine to destroy the bullet after a set time
        StartCoroutine(DestroyBulletAfterTime(bullet));
    }

    IEnumerator DestroyBulletAfterTime(GameObject bullet)
    {
        // Wait for the bullet's lifetime
        yield return new WaitForSeconds(bulletLifetime);

        // Destroy the bullet
        Destroy(bullet);
    }
}
