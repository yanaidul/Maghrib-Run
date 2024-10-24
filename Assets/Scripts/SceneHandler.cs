using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    //Method code yang dipanggil untuk ke scene game
    public void OnStartGame()
    {
        SaveManager.GetInstance().CurrentStage++;
        SceneManager.LoadScene(SaveManager.GetInstance().CurrentStage);
    }

    //Method code yang dipanggil untuk restart game
    public void OnRestartGame()
    {
        SaveManager.GetInstance().CurrentStage++;
        SceneManager.LoadScene(SaveManager.GetInstance().CurrentStage);
    }

    //Method code yang dipanggil untuk kembali ke main menu
    public void OnMainMenu()
    {
        //BGM.GetInstance().bgm.Stop();
        SaveManager.GetInstance().isFromLoading = false;
        SceneManager.LoadScene(0);
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}
