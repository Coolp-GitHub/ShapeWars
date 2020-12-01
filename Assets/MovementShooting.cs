using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShooting : MonoBehaviour
{
    public float speed = 5f;

    public Camera cam;
    public Rigidbody2D rb;

    Vector2 move;
    Vector2 mousePos;

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.position = (rb.position + move * speed * Time.deltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle; 
    }
}
