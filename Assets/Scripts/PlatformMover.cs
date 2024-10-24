using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private List<GameObject> _coins = new();
    public float speed = 10f;
    public float resetPosition = -20f; 
    public float startPosition = 20f;
    private bool _isStopped = false;

    void Update()
    {
        if (_isStopped) return;
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

        if (_coins.Count == 0) return;
        foreach (GameObject go in _coins)
        {
            go.SetActive(true);
        }
    }

    public void OnStopPlatform()
    {
        _isStopped = true;
        speed = 0;
    }
}
