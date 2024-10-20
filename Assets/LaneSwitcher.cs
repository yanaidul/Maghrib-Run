using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSwitcher : MonoBehaviour
{
    private readonly int _dodgeLeftAnimationHash = Animator.StringToHash("Dodge Left");
    private readonly int _dodgeRightAnimationHash = Animator.StringToHash("Dodge Right");
    private readonly int _runAnimationHash = Animator.StringToHash("Run");

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private float _laneDistance = 2f; 
    [SerializeField] private float _switchSpeed = 10f; 
    private int _currentLane = 1; 
    private Vector3 _targetPosition;
    private JumpController _jumpController;

    private void Awake()
    {
        _jumpController = GetComponent<JumpController>();
    }

    void Start()
    {

        _targetPosition = transform.position;
    }

    void Update()
    {
        if (!_jumpController.IsGrounded) return;
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }

        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _switchSpeed);
    }

    void MoveRight()
    {
        if (_currentLane > 0) 
        {
            _playerAnimator.Play(_dodgeRightAnimationHash);
            _currentLane--;
            _targetPosition = new Vector3(transform.position.x, transform.position.y, _currentLane * _laneDistance - _laneDistance);
        }
    }

    void MoveLeft()
    {
        if (_currentLane < 2)
        {
            _playerAnimator.Play(_dodgeLeftAnimationHash);
            _currentLane++;
            _targetPosition = new Vector3(transform.position.x, transform.position.y, _currentLane * _laneDistance - _laneDistance);
        }
    }

    public void ReturnToRunStateFromDodge()
    {
        _playerAnimator.Play(_runAnimationHash);
    }
}
