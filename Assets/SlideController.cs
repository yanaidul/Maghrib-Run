using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    private readonly int SlideAnimationHash = Animator.StringToHash("Slide");
    private readonly int RunAnimationHash = Animator.StringToHash("Run");
    [SerializeField] private Animator _playerAnimator;
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
        _playerAnimator.Play(SlideAnimationHash);
        StartCoroutine(ReturnToRunState());
    }

    IEnumerator ReturnToRunState()
    {
        yield return new WaitForSeconds(1f);
        _isSlide = false;
        _playerAnimator.Play(RunAnimationHash);
    }
}
