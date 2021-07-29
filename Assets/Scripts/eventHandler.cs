using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventHandler : MonoBehaviour
{
    public delegate void movement(Vector2 move);
    public spaceship ss;
    void Awake()
    {
        inputLogic.moved += ss.move;
    }
}
