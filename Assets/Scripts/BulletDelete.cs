using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDelete : MonoBehaviour
{
    void OnCollisionEnter (Collision ci)
    {
        Destroy(gameObject);
    }
}
