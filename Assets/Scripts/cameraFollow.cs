using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    Transform spaceship;

    void Start()
    {
        spaceship = GameObject.Find("spaceship").transform;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, spaceship.position, Time.deltaTime * 5f);
        //transform.position = Vector2.one;
    }
}
