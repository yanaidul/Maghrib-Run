using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private int currentStage;
    public int CurrentStage
    {
        get { return currentStage; }
        set
        {
            currentStage = value;
            if(currentStage > 2) currentStage = 1;
        }
    }

    [SerializeField] private int currentGold;
    public int CurrentGold
    {
        get { return currentGold; }
        set
        {
            currentGold = value;
            PlayerPrefs.SetInt("SavedGold", currentGold);
        }
    }
    [SerializeField] private int currentHighScore;
    public int CurrentHighScore
    {
        get { return currentHighScore; }
        set 
        {
            currentHighScore = value;
            PlayerPrefs.SetInt("SavedScore", currentHighScore);
        }
    }
    public bool isSFXOn;
    public bool isBGMOn;
    public bool isFromLoading = false;

    protected override void Awake()
    {
        base.Awake();

        if (!PlayerPrefs.HasKey("SavedGold"))
        {
            currentGold = 0;
        }
        else currentGold = PlayerPrefs.GetInt("SavedGold");

        if (!PlayerPrefs.HasKey("SavedScore"))
        {
            currentHighScore = 0;
        }
        else currentHighScore = PlayerPrefs.GetInt("SavedScore");
    }
}
