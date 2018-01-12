using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
    public Vector3 direction;
    public float speed = 10f;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(direction * speed);
    }

    void Update()
    {
        if (rb2D.velocity.magnitude <= 1f)
            Destroy(gameObject);
    }
}
