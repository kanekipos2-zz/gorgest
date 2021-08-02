using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class background : MonoBehaviour
{
    Sprite bg;
    Vector2 screenSize;
    Image bgImg;
    float shipSpeed;
    void Awake()
    {
        bg = Resources.Load<Sprite>("Sprites/background");
        screenSize = new Vector2(Screen.width, Screen.height);
        shipSpeed = GameObject.Find("spaceship").GetComponent<spaceship>().speed;

        Image tempImg = new GameObject().AddComponent<Image>();
        Rigidbody2D rbd = tempImg.gameObject.AddComponent<Rigidbody2D>();
        rbd.gravityScale = 0;
        rbd.drag = 1;
        tempImg.transform.SetParent(gameObject.transform);
        tempImg.rectTransform.localScale = Vector2.one;
        tempImg.rectTransform.localPosition = Vector2.zero;
        tempImg.sprite = bg;
        tempImg.rectTransform.sizeDelta = new Vector2(screenSize.x * 3, screenSize.x * 3);

        bgImg = tempImg;
    }

    void Update()
    {
        if (bgImg.rectTransform.localPosition.x > screenSize.x)
        {
            bgImg.rectTransform.localPosition = new Vector2(-screenSize.x, bgImg.rectTransform.localPosition.y); 
            //RIGHT
        }
        if (bgImg.rectTransform.localPosition.x < -screenSize.x)
        {
            bgImg.rectTransform.localPosition = new Vector2(screenSize.x, bgImg.rectTransform.localPosition.y);
            //LEFT
        }
        if (bgImg.rectTransform.localPosition.y > screenSize.x)
        {
            bgImg.rectTransform.localPosition = new Vector2(bgImg.rectTransform.localPosition.x, -screenSize.x);
            //UP
        }
        if (bgImg.rectTransform.localPosition.y < -screenSize.x)
        {
            bgImg.rectTransform.localPosition = new Vector2(bgImg.rectTransform.localPosition.x, screenSize.x);
            //DOWN
        }
    }

    public void move(Vector2 v)
    {
        bgImg.GetComponent<Rigidbody2D>().velocity = -v * 0.5f * shipSpeed;
    }

}