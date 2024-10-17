using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float speed = 10f;
    public float resetPosition = -20f; 
    public float startPosition = 20f; 

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < resetPosition)
        {
            ResetPlatform();
        }
    }

    void ResetPlatform()
    {
        Vector3 newPos = transform.position;
        newPos.x = startPosition;
        transform.position = newPos;
    }
}
