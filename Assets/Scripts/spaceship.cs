using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 0.05f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public void move(Vector2 v)
    {
        rb.velocity = v * speed;
        gameObject.transform.up = v;
    }
}
