using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _scoreText;
    [SerializeField] private float scoreMultiplier = 1.0f;
    [SerializeField] private GameEventNoParam _onIncreasePlatformSpeed;
    [SerializeField] private float _score = 0f;

    private float _targetScoreToIncreaseSpeed = 500f;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            _score += Time.deltaTime * scoreMultiplier;

            if (_score >= _targetScoreToIncreaseSpeed)
            {
                _targetScoreToIncreaseSpeed += 500;
                _onIncreasePlatformSpeed.Raise();
            }

            if (_score > 10 && (_score % 500 <= 10))
            {
                PlatformManager.GetInstance().RandomizeSelectedPlatformIndex();
            }
            foreach (var score in _scoreText)
            {
                score.SetText(Mathf.FloorToInt(_score).ToString());
            }
            
        }
    }

    public void StopScore()
    {
        isRunning = false;
    }

    public void ResetScore()
    {
        _score = 0f;
        isRunning = true;
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(_score);
    }
}
