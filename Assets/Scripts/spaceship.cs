using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 0.1f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public void move(Vector2 v)
    {
        rb.AddForce( v * speed );
        gameObject.transform.up = v;
    }
}
