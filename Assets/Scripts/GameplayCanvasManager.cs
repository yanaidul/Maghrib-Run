using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameplay;
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _setting;

    private void Start()
    {
        DisableAllCanvas();
        OpenGameplay();
    }

    private void DisableAllCanvas()
    {
        _gameplay.SetActive(false);
        _pause.SetActive(false);
        _setting.SetActive(false);
        _gameOver.SetActive(false);
    }

    public void OpenGameplay()
    {
        Time.timeScale = 1;
        DisableAllCanvas();
        _gameplay.SetActive(true);
    }

    public void OpenPause()
    {
        Time.timeScale = 0;
        DisableAllCanvas();
        _pause.SetActive(true);
    }

    public void OpenSetting()
    {
        DisableAllCanvas();
        _setting.SetActive(true);
    }

    public void OpenGameOver()
    {
        DisableAllCanvas();
        _gameOver.SetActive(true);
    }
}
