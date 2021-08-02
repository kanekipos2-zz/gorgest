using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    Transform target;

    Vector3 offset;

    void Awake() { target = GameObject.Find("spaceship").transform; }

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, 100 * Time.deltaTime);
    }
}