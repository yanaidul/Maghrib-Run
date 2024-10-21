using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private float scoreMultiplier = 1.0f;
    private float score = 0f;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            score += Time.deltaTime * scoreMultiplier;
            _scoreText.SetText(Mathf.FloorToInt(score).ToString());
        }
    }

    public void StopScore()
    {
        isRunning = false;
    }

    public void ResetScore()
    {
        score = 0f;
        isRunning = true;
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }
}
