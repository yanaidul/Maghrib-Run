using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UI_Loading : MonoBehaviour
{
    public GameObject _uiLoading;
    public GameObject _uiVideo;
    public VideoPlayer _videoPlayer;
    public Image loadingBarImage;  
    public float fillDuration = 5f; 
    private float targetFill = 1f; 

    private void Start()
    {
        loadingBarImage.fillAmount = 0f;
        StartCoroutine(FillBarAfterDelay(0.1f));
    }

    private IEnumerator FillBarAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0f;

        while (elapsedTime < fillDuration)
        {
            elapsedTime += Time.deltaTime;
            loadingBarImage.fillAmount = Mathf.Lerp(0f, targetFill, elapsedTime / fillDuration);
            yield return null;
        }

        loadingBarImage.fillAmount = targetFill;
        _uiLoading.SetActive(false);
        _uiVideo.SetActive(true);
        _videoPlayer.Play();
        SFXHandler.GetInstance().SetBGMBoolValue(false);
        SaveManager.GetInstance().isFromLoading = false;
    }
}
