using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private readonly int JumpAnimationHash = Animator.StringToHash("Jump");
    private readonly int RunAnimationHash = Animator.StringToHash("Run");
    [SerializeField] private Animator _playerAnimator;
    public float jumpForce = 5f; 
    private Rigidbody rb;
    private bool _isGrounded;
    private SlideController _dodgeController;


    public bool IsGrounded => _isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
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
        _playerAnimator.Play(JumpAnimationHash);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _isGrounded = false; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !_dodgeController.IsSlide)
        {
            _playerAnimator.Play(RunAnimationHash);
            _isGrounded = true;
        }
    }
}
