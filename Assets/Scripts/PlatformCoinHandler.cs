using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCoinHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _coins = new();

    public void ResetCoins()
    {
        if (_coins.Count == 0) return;
        foreach (GameObject go in _coins)
        {
            go.SetActive(true);
        }
    }

    //void FixedUpdate()
    //{
    //    if (_isStopped) return;
    //    transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);

    //    if (transform.position.x <= resetPosition)
    //    {
    //        ResetPlatform();
    //    }
    //}

    //void ResetPlatform()
    //{
    //    Vector3 newPos = transform.position;
    //    newPos.x = startPosition;
    //    transform.position = newPos;

    //    if (_coins.Count == 0) return;
    //    foreach (GameObject go in _coins)
    //    {
    //        go.SetActive(true);
    //    }
    //}

    //public void OnStopPlatform()
    //{
    //    _isStopped = true;
    //    speed = 0;
    //}
}
