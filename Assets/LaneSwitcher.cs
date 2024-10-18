using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSwitcher : MonoBehaviour
{
    public float laneDistance = 2f; 
    public float switchSpeed = 10f; 
    private int currentLane = 1; 
    private Vector3 targetPosition;
    private JumpController _jumpController;

    private void Awake()
    {
        _jumpController = GetComponent<JumpController>();
    }

    void Start()
    {
        targetPosition = transform.position;
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

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * switchSpeed);
    }

    void MoveRight()
    {
        if (currentLane > 0) 
        {
            currentLane--;
            targetPosition = new Vector3(transform.position.x, transform.position.y, currentLane * laneDistance - laneDistance);
        }
    }

    void MoveLeft()
    {
        if (currentLane < 2)
        {
            currentLane++;
            targetPosition = new Vector3(transform.position.x, transform.position.y, currentLane * laneDistance - laneDistance);
        }
    }
}
