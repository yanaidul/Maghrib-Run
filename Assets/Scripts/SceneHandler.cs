using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    //Method code yang dipanggil untuk restart game
    public void OnRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Method code yang dipanggil untuk kembali ke main menu
    public void OnMainMenu()
    {
        //BGM.GetInstance().bgm.Stop();
        SceneManager.LoadScene(0);
    }
}
