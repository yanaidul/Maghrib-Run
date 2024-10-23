using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private readonly int _deathAnimationHash = Animator.StringToHash("Death");
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private GameEventNoParam _onGameOver;
    [SerializeField] private GameEventNoParam _onWeweVictory;
    public void OnPlayDeathAnimation()
    {
        SFXHandler.GetInstance().PlayDeathSFX();
        _playerAnimator.Play(_deathAnimationHash);
        _onWeweVictory.Raise();

        if(_scoreManager.GetScore() > SaveManager.GetInstance().CurrentHighScore) SaveManager.GetInstance().CurrentHighScore = _scoreManager.GetScore();
        SaveManager.GetInstance().CurrentGold += _coinManager.CollectedCoins;
        _coinManager.UpdateCurrentGoldText();
        StartCoroutine(OnDelayGameOverCanvas());
    }

    IEnumerator OnDelayGameOverCanvas()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        _onGameOver.Raise();
    }
}
