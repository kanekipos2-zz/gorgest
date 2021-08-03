using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float rotationSpeed;
    ParticleSystem[] systems = new ParticleSystem[5];  // 1 left 2-4 middle 5 right

    private void Start()
    {
        systems = gameObject.GetComponentsInChildren<ParticleSystem>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public void move(Vector2 v)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, v) , Time.deltaTime * rotationSpeed);
        
        rb.AddForce( transform.up * speed );

        for (int a = 0; a < systems.Length; a++)
        {
            if (a == 0) { if (Quaternion.FromToRotation(gameObject.transform.up, v).z < 0) systems[a].Emit(10); }
            if (a > 0 && a < systems.Length-1) { systems[a].Emit(5); }
            if (a == systems.Length-1) { if (Quaternion.FromToRotation(gameObject.transform.up, v).z > 0) systems[a].Emit(10); }
        }
    }
}
