using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeweAnimationController : MonoBehaviour
{
    private readonly int _jumpWeweAnimationHash = Animator.StringToHash("Jump");
    private readonly int _slideWeweAnimationHash = Animator.StringToHash("Sliding");
    private readonly int _runWeweAnimationHash = Animator.StringToHash("Run");
    private readonly int _victoryWeweAnimationHash = Animator.StringToHash("Victory");

    [SerializeField] private Animator _weweAnimator;

    public void OnWeweRun()
    {
        _weweAnimator.Play(_runWeweAnimationHash);
    }
    public void OnWeweJump()
    {
        _weweAnimator.Play(_jumpWeweAnimationHash);
    }
    public void OnWeweSlide()
    {
        _weweAnimator.Play(_slideWeweAnimationHash);
    }

    public void OnWeweVictory()
    {
        _weweAnimator.Play(_victoryWeweAnimationHash);
    }
}
