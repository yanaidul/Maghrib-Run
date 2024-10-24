using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Gold : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldText;

    private void Start()
    {
        _goldText.SetText(SaveManager.GetInstance().CurrentGold.ToString());
    }
}
