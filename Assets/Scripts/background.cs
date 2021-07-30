using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class background : MonoBehaviour
{
    Sprite[] bg;
    Vector2 screenSize;
    int sRate = 25;
    void Awake()
    {
        bg = Resources.LoadAll<Sprite>("Sprites/background");
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one);
        Debug.Log(screenSize);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void move(Vector2 v)
    {
        
    }
}