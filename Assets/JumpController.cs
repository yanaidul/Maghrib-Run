using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private readonly int _jumpAnimationHash = Animator.StringToHash("Jump");
    private readonly int _runAnimationHash = Animator.StringToHash("Run");

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private float _jumpForce = 5f; 
    private Rigidbody _rb;
    private bool _isGrounded;
    private SlideController _dodgeController;


    public bool IsGrounded => _isGrounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody>(); 
        _dodgeController = GetComponent<SlideController>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        _playerAnimator.Play(_jumpAnimationHash);
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isGrounded = false; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !_dodgeController.IsSlide)
        {
            _playerAnimator.Play(_runAnimationHash);
            _isGrounded = true;
        }
    }
}
