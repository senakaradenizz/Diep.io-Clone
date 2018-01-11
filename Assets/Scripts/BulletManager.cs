using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {


    public Rigidbody2D rb2D;
    public Vector3 direction;
    public float speed = 10f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(direction * speed);
    }

    void Update()
    {
        Debug.Log(rb2D.velocity.magnitude);
        if (rb2D.velocity.magnitude <= 1f)
            Destroy(gameObject);
    }


}
