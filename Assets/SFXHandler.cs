using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXHandler : Singleton<SFXHandler>
{
    [SerializeField] private AudioClip _dodgeSFX, _slideSFX, _jumpSFX, _deathSFX, _collectibleSFX;
    [SerializeField] private AudioSource _audioSource;

    public void PlayDodgeSFX()
    {
        _audioSource.PlayOneShot(_dodgeSFX);
    }

    public void PlaySlideSFX()
    {
        _audioSource.PlayOneShot(_slideSFX);
    }

    public void PlayJumpSFX()
    {
        _audioSource.PlayOneShot(_jumpSFX);
    }

    public void PlayDeathSFX()
    {
        _audioSource.PlayOneShot(_deathSFX);
    }

    public void PlayCollectbleSFX()
    {
        _audioSource.PlayOneShot(_collectibleSFX);
    }
}
