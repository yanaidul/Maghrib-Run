using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSwitcher : MonoBehaviour
{
    private readonly int _dodgeLeftAnimationHash = Animator.StringToHash("Dodge Left");
    private readonly int _dodgeRightAnimationHash = Animator.StringToHash("Dodge Right");
    private readonly int _runAnimationHash = Animator.StringToHash("Run");

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Wewe _wewe;
    [SerializeField] private float _laneDistance = 2f;
    [SerializeField] private float _switchSpeed = 10f;
    private int _currentLane = 1;
    private Vector3 _targetPosition;
    private JumpController _jumpController;
    private bool _isCrashed = false;

    public int CurrentLane => _currentLane;

    private void Awake()
    {
        _jumpController = GetComponent<JumpController>();
    }

    void Start()
    {
        _isCrashed = false;
        _targetPosition = transform.position;
    }

    void Update()
    {
        if (!_jumpController.IsGrounded || _isCrashed) return;
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

    public void MoveRight()
    {
        if (!_jumpController.IsGrounded || _isCrashed) return;
        if (GetComponent<DeathHandler>().isDead) return;

        if (_currentLane > 0) 
        {
            _wewe.MoveWeweRight();
            SFXHandler.GetInstance().PlayDodgeSFX();
            _playerAnimator.Play(_dodgeRightAnimationHash);
            _currentLane--;
            _targetPosition = new Vector3(transform.position.x, transform.position.y, _currentLane * _laneDistance - _laneDistance);
        }

        if (_currentLane == 2) transform.eulerAngles = new Vector3(0.73f, 105, 0);
        else if (_currentLane == 1) transform.eulerAngles = new Vector3(0.73f, 90, 0);
        else transform.eulerAngles = new Vector3(0.73f, 75, 0);
    }

    public void MoveLeft()
    {
        if (!_jumpController.IsGrounded || _isCrashed) return;
        if (GetComponent<DeathHandler>().isDead) return;
        if (_currentLane < 2)
        {
            _wewe.MoveWeweLeft();
            SFXHandler.GetInstance().PlayDodgeSFX();
            _playerAnimator.Play(_dodgeLeftAnimationHash);
            _currentLane++;
            _targetPosition = new Vector3(transform.position.x, transform.position.y, _currentLane * _laneDistance - _laneDistance);
        }

        if (_currentLane == 2) transform.eulerAngles = new Vector3(0.73f, 105, 0);
        else if (_currentLane == 1) transform.eulerAngles = new Vector3(0.73f, 90, 0);
        else transform.eulerAngles = new Vector3(0.73f, 75, 0);
    }

    public void ReturnToRunStateFromDodge()
    {
        _playerAnimator.Play(_runAnimationHash);
    }

    public void OnObstacleCrash()
    {
        _isCrashed = true;
    }
}
