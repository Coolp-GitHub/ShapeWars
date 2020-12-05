using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    public float speed = 5f;
    public float dashForce = 20f;
    public float coolDown = 0.5f;
    bool canDash = true;

    public Camera cam;
    public Rigidbody2D rb;
    public Transform Diamond;

    Vector2 move;
    Vector2 mousePos;

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && canDash)
        {
            rb.AddForce(dashForce * Diamond.up, ForceMode2D.Impulse);
            canDash = false;
            StartCoroutine(WaitCooldown());
        }

    }

    void FixedUpdate()
    {
        rb.position = (rb.position + move * speed * Time.deltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    IEnumerator WaitCooldown()
    {
        yield return new WaitForSeconds(coolDown);
        canDash = true;
    }
}
