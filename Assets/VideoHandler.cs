using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoHandler : MonoBehaviour
{
    [SerializeField] private GameObject _uiVideo;
    private double time;
    private double currentTime;
    // Use this for initialization
    void Start()
    {
        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }


    // Update is called once per frame
    void Update()
    {
        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (Mathf.FloorToInt((float)currentTime) >= Mathf.FloorToInt((float)time))
        {
            Debug.Log("Video ends");
            SFXHandler.GetInstance().SetBGMBoolValue(true);
            _uiVideo.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
