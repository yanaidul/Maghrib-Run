using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXHandler : Singleton<SFXHandler>
{
    [SerializeField] private AudioClip _dodgeSFX, _slideSFX, _jumpSFX, _deathSFX, _collectibleSFX;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _bgmAudioSource;

    public void PlayDodgeSFX()
    {
        if (!SaveManager.GetInstance().isSFXOn) return;
        _audioSource.PlayOneShot(_dodgeSFX);
    }

    public void PlaySlideSFX()
    {
        if (!SaveManager.GetInstance().isSFXOn) return;
        _audioSource.PlayOneShot(_slideSFX);
    }

    public void PlayJumpSFX()
    {
        if (!SaveManager.GetInstance().isSFXOn) return;
        _audioSource.PlayOneShot(_jumpSFX);
    }

    public void PlayDeathSFX()
    {
        if (!SaveManager.GetInstance().isSFXOn) return;
        _audioSource.PlayOneShot(_deathSFX);
    }

    public void PlayCollectbleSFX()
    {
        if (!SaveManager.GetInstance().isSFXOn) return;
        _audioSource.PlayOneShot(_collectibleSFX);
    }

    public void SetBGMBoolValue(bool newValue)
    {
        SaveManager.GetInstance().isBGMOn = newValue;

        if (newValue) _bgmAudioSource.Play();
        else _bgmAudioSource.Stop();
    }

    public void SetSFXBoolValue(bool newValue)
    {
        SaveManager.GetInstance().isSFXOn = newValue;
    }
}
