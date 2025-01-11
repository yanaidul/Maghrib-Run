using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wewe : MonoBehaviour
{
    [SerializeField] private float _laneDistance = 2f;
    [SerializeField] private float _switchSpeed = 10f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameEventNoParam _onObstacleCrash;
    private int _currentLane = 1;
    private Rigidbody _rb;
    private Vector3 _targetPosition;
    private bool _isGrounded;
    private float _distance;
    private WeweAnimationController _animationController;

    void Start()
    {
        _targetPosition = transform.position;
        _rb = GetComponent<Rigidbody>();
        _animationController = GetComponent<WeweAnimationController>();
        StartCoroutine(IncreaseSpeed());
    }

    private void Update()
    {
        if (!_isGrounded) return;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _switchSpeed);


        _distance = Vector3.Distance(transform.position, _playerTransform.position);

        Debug.Log(_distance);
    }


    public void MoveWeweRight()
    {
        StartCoroutine(DelayMoveRight());
    }

    public void MoveWeweLeft()
    {
        StartCoroutine(DelayMoveLeft());
    }

    public void WeweJump()
    {
        StartCoroutine(DelayJump());
    }

    IEnumerator DelayMoveLeft()
    {
        yield return new WaitForSeconds(0.2F);
        if (_currentLane < 2)
        {
            _animationController.OnDodgeLeft();
            _currentLane++;
            _targetPosition = new Vector3(transform.position.x, transform.position.y, _currentLane * _laneDistance - _laneDistance);
        }
    }

    IEnumerator DelayMoveRight()
    {
        yield return new WaitForSeconds(0.2F);
        if (_currentLane > 0)
        {
            _animationController.OnDodgeRight();
            _currentLane--;
            _targetPosition = new Vector3(transform.position.x, transform.position.y, _currentLane * _laneDistance - _laneDistance);
        }
    }

    IEnumerator DelayJump()
    {
        yield return new WaitForSeconds(0.2F);
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }

    }

    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(0.25F);
        if (_distance > 0.4f)
        {
            _targetPosition += Vector3.right * 0.1f;
            StartCoroutine(IncreaseSpeed());
        }
        else
        {
            _onObstacleCrash.Raise();
        }

    }

    public void DecreaseSpeed()
    {
        if (_distance < 4f)
        {
            _targetPosition += Vector3.left * 0.2f;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

}
