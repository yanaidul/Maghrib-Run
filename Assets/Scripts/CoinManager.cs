using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _coinText;
    [SerializeField] private TextMeshProUGUI _totalCoinTextPause;
    [SerializeField] private TextMeshProUGUI _totalCoinTextGameOver;
    private int _collectedCoins = 0;

    public int CollectedCoins => _collectedCoins;

    private void Start()
    {
        _totalCoinTextPause.SetText(SaveManager.GetInstance().CurrentGold.ToString());
    }

    public void OnCollectCoins()
    {
        _collectedCoins++;
        foreach (var gold in _coinText)
        {
            gold.SetText(_collectedCoins.ToString());
        }
    }

    public void UpdateCurrentGoldText()
    {
        _totalCoinTextGameOver.SetText(SaveManager.GetInstance().CurrentGold.ToString());
    }
}
