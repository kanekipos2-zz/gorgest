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
    }
    void Start()
    {
        for (float x = 0; x < screenSize.x; x+=sRate) for (float y = 0; y < screenSize.y; y+=sRate)
        {
                if (Random.value < 0.01f)
                {
                    Image t = new GameObject().AddComponent<Image>();
                    t.transform.SetParent(gameObject.transform);
                    t.transform.position = new Vector2(x, y);
                    t.sprite = bg[Random.Range(0, bg.Length)];
                    t.SetNativeSize();
                    t.transform.localScale *= 3;
                }
        }
    }
    void Update()
    {
        
    }

    public void move(Vector2 v)
    {
        
    }
}