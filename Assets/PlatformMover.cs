using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float speed = 10f;
    public float resetPosition = -30f;
    public float startPosition = 300f;
    private bool _isStopped = false;

    [SerializeField] private List<PlatformCoinHandler> _platformCoinHandler = new();

    private void Start()
    {
        foreach (var platform in _platformCoinHandler)
        {
            platform.gameObject.SetActive(false);
        }
        _platformCoinHandler[PlatformManager.GetInstance().selectedPlatformIndex].gameObject.SetActive(true);
    }

    void FixedUpdate()
    {
        if (_isStopped) return;
        transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);

        if (transform.position.x <= resetPosition)
        {
            ResetPlatform();
        }
    }

    void ResetPlatform()
    {
        Vector3 newPos = transform.position;
        newPos.x = startPosition;
        transform.position = newPos;
        foreach (var platform in _platformCoinHandler)
        {
            platform.gameObject.SetActive(false);
        }
        _platformCoinHandler[PlatformManager.GetInstance().selectedPlatformIndex].gameObject.SetActive(true);
        foreach (var platform in _platformCoinHandler)
        {
            platform.ResetCoins();
        }
    }

    public void OnStopPlatform()
    {
        _isStopped = true;
        speed = 0;
    }

    public void OnIncreasePlatformSpeed()
    {
        speed++;
    }
}
