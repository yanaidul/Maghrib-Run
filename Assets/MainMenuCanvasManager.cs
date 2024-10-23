using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _characterSelection;
    [SerializeField] private GameObject _setting;
    [SerializeField] private GameObject _highScore;
    [SerializeField] private GameObject _mission;

    private void Start()
    {
        DisableAllCanvas();
        OpenMainMenu();
    }

    private void DisableAllCanvas()
    {
       _mainMenu.SetActive(false);
       _characterSelection.SetActive(false);
       _setting.SetActive(false);
       _highScore.SetActive(false);
       _mission.SetActive(false);
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 1;
        DisableAllCanvas();
        _mainMenu.SetActive(true);
    }

    public void OpenCharacterSelection()
    {
        _characterSelection.SetActive(true);
    }

    public void OpenSetting()
    {
        _setting.SetActive(true);
    }

    public void OpenHighScore()
    {
        _highScore.SetActive(true);
    }

    public void OpenMission()
    {
        _mission.SetActive(true);
    }
}
