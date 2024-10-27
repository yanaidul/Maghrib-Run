using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeweAnimationController : MonoBehaviour
{
    private readonly int _jumpWeweAnimationHash = Animator.StringToHash("Jump");
    private readonly int _slideWeweAnimationHash = Animator.StringToHash("Sliding");
    private readonly int _runWeweAnimationHash = Animator.StringToHash("Run");
    private readonly int _victoryWeweAnimationHash = Animator.StringToHash("Victory");
    private readonly int _dodgeLeftWeweAnimationHash = Animator.StringToHash("Dodge Left");
    private readonly int _dodgeRightWeweAnimationHash = Animator.StringToHash("Dodge Right");

    [SerializeField] private Animator _weweAnimator;

    public void OnWeweRun()
    {
        _weweAnimator.Play(_runWeweAnimationHash);
    }
    public void OnWeweJump()
    {
        _weweAnimator.Play(_jumpWeweAnimationHash);
    }
    public void OnDodgeLeft()
    {
        _weweAnimator.Play(_dodgeLeftWeweAnimationHash);
        StartCoroutine(DelayRun());
    }
    public void OnDodgeRight()
    {
        _weweAnimator.Play(_dodgeRightWeweAnimationHash);
        StartCoroutine(DelayRun());
    }
    public void OnWeweSlide()
    {
        StartCoroutine(DelaySlide());
    }

    public void OnWeweVictory()
    {
        _weweAnimator.Play(_victoryWeweAnimationHash);
    }

    IEnumerator DelaySlide()
    {
        yield return new WaitForSeconds(0.2F);
        _weweAnimator.Play(_slideWeweAnimationHash);

    }

    IEnumerator DelayRun()
    {
        yield return new WaitForSeconds(0.5F);
        _weweAnimator.Play(_runWeweAnimationHash);

    }
}
