using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _coinText;
    private int _collectedCoins = 0;
    
    public void OnCollectCoins()
    {
        _collectedCoins++;
        foreach (var gold in _coinText)
        {
            gold.SetText(_collectedCoins.ToString());
        }
    }
}
