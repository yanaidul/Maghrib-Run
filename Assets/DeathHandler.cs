using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private readonly int _deathAnimationHash = Animator.StringToHash("Death");
    [SerializeField] private Animator _playerAnimator;
    public void OnPlayDeathAnimation()
    {
        _playerAnimator.Play(_deathAnimationHash);
    }
}
