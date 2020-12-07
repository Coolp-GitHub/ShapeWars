using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawning : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float coolDown = 0.2f;
    public float dmg;
    bool canShoot = true;

    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && canShoot)
        {
            Shoot();
            StartCoroutine(WaitCooldown());

        }
        else
        {
            return;
        }
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
        canShoot = false;
        
    }

    IEnumerator WaitCooldown()
    {
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }

}
