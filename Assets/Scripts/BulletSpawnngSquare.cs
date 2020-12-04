using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnngSquare : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPrefab;
    public Transform firepoint2;

    public float bulletForce = 20f;
    public float coolDown = 0.2f;
    bool canShoot = true;

    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && canShoot)
        {
            Shoot();
            StartCoroutine(WaitCooldown());

        }
        

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firepoint2.up * bulletForce, ForceMode2D.Impulse);
        canShoot = false;

    }

    IEnumerator WaitCooldown()
    {
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}
