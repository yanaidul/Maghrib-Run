using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wewe : MonoBehaviour
{
    [SerializeField] private float _laneDistance = 2f;
    [SerializeField] private float _switchSpeed = 10f;
    [SerializeField] private float _jumpForce = 5f;
    private int _currentLane = 1;
    private Rigidbody _rb;
    private Vector3 _targetPosition;
    private bool _isGrounded;
    private WeweAnimationController _animationController;

    void Start()
    {
        _targetPosition = transform.position;
        _rb = GetComponent<Rigidbody>();
        _animationController = GetComponent<WeweAnimationController>();
    }

    private void Update()
    {
        if (!_isGrounded) return;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _switchSpeed);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

}
