using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class background : MonoBehaviour
{
    Vector2 screenSize;
    RectTransform rts;
    Rigidbody2D rbd;
    GameObject spaceship;
    void Awake()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
        gameObject.transform.localScale = new Vector2(screenSize.x * 3, screenSize.x * 3);
        rts = gameObject.GetComponent<RectTransform>();
        rbd = gameObject.GetComponent<Rigidbody2D>();
        spaceship = GameObject.Find("spaceship");
    }

    void Update()
    {
        if (rts.localPosition.x > screenSize.x)
        {
            rts.localPosition = new Vector2(-screenSize.x, rts.localPosition.y); 
            //RIGHT
        }
        if (rts.localPosition.x < -screenSize.x)
        {
            rts.localPosition = new Vector2(screenSize.x, rts.localPosition.y);
            //LEFT
        }
        if (rts.localPosition.y > screenSize.x)
        {
            rts.localPosition = new Vector2(rts.localPosition.x, -screenSize.x);
            //UP
        }
        if (rts.localPosition.y < -screenSize.x)
        {
            rts.localPosition = new Vector2(rts.localPosition.x, screenSize.x);
            //DOWN
        }

    }
    void FixedUpdate()
    {
        rbd.AddForce( -spaceship.GetComponent<Rigidbody2D>().velocity * spaceship.GetComponent<spaceship>().speed * 0.6f);
    }

}