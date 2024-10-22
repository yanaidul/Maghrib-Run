using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private float swipeThreshold = 50f;
    private LaneSwitcher _laneSwitcher;
    private SlideController _slideController;
    private JumpController _jumpController;

    private void Awake()
    {
        _laneSwitcher = GetComponent<LaneSwitcher>();
        _slideController = GetComponent<SlideController>();
        _jumpController = GetComponent<JumpController>();  
    }

    void Update()
    {
        DetectSwipe();
    }

    void DetectSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                ProcessSwipe();
            }
        }
        else if (Input.GetMouseButtonDown(0)) 
        {
            startTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endTouchPosition = Input.mousePosition;
            ProcessSwipe();
        }
    }

    void ProcessSwipe()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude > swipeThreshold)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                {
                    SwipeRight();
                }
                else
                {
                    SwipeLeft();
                }
            }
            else
            {
                if (y > 0)
                {
                    SwipeUp();
                }
                else
                {
     
                    SwipeDown();
                }
            }
        }
    }

    void SwipeLeft()
    {
        Debug.Log("Swiped Left");
        _laneSwitcher.MoveLeft();

    }

    void SwipeRight()
    {
        Debug.Log("Swiped Right");
        _laneSwitcher.MoveRight();
    }

    void SwipeUp()
    {
        Debug.Log("Swiped Up");
        _jumpController.Jump();
    }

    void SwipeDown()
    {
        Debug.Log("Swiped Down");
        _slideController.Dodge();
    }
}
