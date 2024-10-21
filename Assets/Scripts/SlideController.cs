using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    private readonly int _slideAnimationHash = Animator.StringToHash("Slide");
    private readonly int _runAnimationHash = Animator.StringToHash("Run");

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private CapsuleCollider _dodgeCapsuleCollider;
    [SerializeField] private CapsuleCollider _normalCapsuleCollider;
    private bool _isSlide;

    public bool IsSlide => _isSlide;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _isSlide = true;
            Dodge();
        }
    }

    void Dodge()
    {
        _dodgeCapsuleCollider.enabled = true;
        _normalCapsuleCollider.enabled = false;
        _playerAnimator.Play(_slideAnimationHash);
        StartCoroutine(ReturnToRunStateFromSlide());
    }

    IEnumerator ReturnToRunStateFromSlide()
    {
        yield return new WaitForSeconds(1f);
        _dodgeCapsuleCollider.enabled = false;
        _normalCapsuleCollider.enabled = true;
        _isSlide = false;
        _playerAnimator.Play(_runAnimationHash);
    }
}
