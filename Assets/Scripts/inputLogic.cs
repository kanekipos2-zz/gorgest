using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputLogic : MonoBehaviour
{
    Sprite[] joystik;   //[0] - точка в центре, [1] - ободок
    Vector2 screenSize, inputZone;
    public static event eventHandler.movement moved;
    jStick currentJStick = new jStick(-1, null, null);
    void Awake()
    {
        joystik = Resources.LoadAll<Sprite>("Sprites/GUI/joystik");
        screenSize = new Vector2(Screen.width, Screen.height);
        inputZone = new Vector2(screenSize.y / 2.2f , screenSize.y / 2.2f);
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x <= inputZone.x && touch.position.y <= inputZone.y && currentJStick.jId == -1)
            {
                Image img = new GameObject().AddComponent<Image>();
                Image img1 = new GameObject().AddComponent<Image>();
                img1.sprite = joystik[0]; 
                img.sprite = joystik[1]; 
                img.transform.position = touch.position;
                img1.transform.position = touch.position;
                img.SetNativeSize();
                img1.SetNativeSize();
                img.transform.SetParent(gameObject.transform);
                img1.transform.SetParent(gameObject.transform);
                currentJStick.jId = touch.fingerId;
                currentJStick.circle = img;
                currentJStick.dot = img1;
            }
            if (touch.phase == TouchPhase.Ended && touch.fingerId == currentJStick.jId)
            {
                Destroy(currentJStick.dot.gameObject);
                Destroy(currentJStick.circle.gameObject);
                currentJStick.jId = -1;
            }  
            if(touch.fingerId == currentJStick.jId)
            {

                currentJStick.dot.transform.position = touch.position;
                Vector3 offset = currentJStick.dot.transform.position - currentJStick.circle.transform.position;
                currentJStick.dot.transform.position = currentJStick.circle.transform.position + Vector3.ClampMagnitude(offset, 110f);
                if((currentJStick.dot.transform.position - currentJStick.circle.transform.position).magnitude > 20)
                    moved(currentJStick.dot.transform.position - currentJStick.circle.transform.position);
            }
        }
    }
}

class jStick
{
    public jStick(int jId,Image circle, Image dot)
    {
        this.jId = jId;
        this.circle = circle;
        this.dot = dot;  
    }
    public int jId;
    public Image circle;
    public Image dot;
}