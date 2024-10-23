using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private readonly int _deathAnimationHash = Animator.StringToHash("Death");
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private GameEventNoParam _onGameOver;
    [SerializeField] private GameEventNoParam _onWeweVictory;
    public void OnPlayDeathAnimation()
    {
        SFXHandler.GetInstance().PlayDeathSFX();
        _playerAnimator.Play(_deathAnimationHash);
        _onWeweVictory.Raise();
        StartCoroutine(OnDelayGameOverCanvas());
    }

    IEnumerator OnDelayGameOverCanvas()
    {
        yield return new WaitForSeconds(0.5f);
        _onGameOver.Raise();
    }
}
