using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] GameObject hitEffect;

    Rigidbody2D rb;

    void Update()
    {
        Destroy(gameObject, 2.5f);
    }

    void OnCollisionEnter2D(Collision2D other) {
        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }

}
