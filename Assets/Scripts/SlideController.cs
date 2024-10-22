using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    private readonly int _slideAnimationHash = Animator.StringToHash("Slide");
    private readonly int _runAnimationHash = Animator.StringToHash("Run");

    [SerializeField] private GameEventNoParam _onWeweRun;
    [SerializeField] private GameEventNoParam _onWeweSlide;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private CapsuleCollider _dodgeCapsuleCollider;
    [SerializeField] private CapsuleCollider _normalCapsuleCollider;
    private bool _isSlide;

    public bool IsSlide => _isSlide;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Dodge();
        }
    }

    public void Dodge()
    {
        _isSlide = true;
        _dodgeCapsuleCollider.enabled = true;
        _normalCapsuleCollider.enabled = false;
        _playerAnimator.Play(_slideAnimationHash);
        //StartCoroutine(OnDelayWeweSlideAnimation());
        _onWeweSlide.Raise();
        StartCoroutine(ReturnToRunStateFromSlide());
    }

    IEnumerator ReturnToRunStateFromSlide()
    {
        yield return new WaitForSeconds(1f);
        _dodgeCapsuleCollider.enabled = false;
        _normalCapsuleCollider.enabled = true;
        _isSlide = false;
        _playerAnimator.Play(_runAnimationHash);
        //StartCoroutine(OnDelayWeweRunAnimation());
        _onWeweRun.Raise();
    }

    IEnumerator OnDelayWeweSlideAnimation()
    {
        yield return new WaitForSeconds(0.25f);
        _onWeweSlide.Raise();
    }

    IEnumerator OnDelayWeweRunAnimation()
    {
        yield return new WaitForSeconds(0.25f);
        _onWeweRun.Raise();
    }
}
