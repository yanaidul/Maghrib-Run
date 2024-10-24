using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_HighScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highscoreText;

    private void Start()
    {
        _highscoreText.SetText(SaveManager.GetInstance().CurrentHighScore.ToString());
    }
}
