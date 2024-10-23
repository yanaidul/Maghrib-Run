using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameEventNoParam _onCollectCoins;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SFXHandler.GetInstance().PlayCollectbleSFX();
            _onCollectCoins.Raise();
            gameObject.SetActive(false);
        }
    }
}
