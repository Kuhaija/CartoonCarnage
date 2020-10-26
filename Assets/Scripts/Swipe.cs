using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap,swipeLeft,swipeRight;
    private bool IsDragging =false;
    private Vector2 startTouch, swipeDelta;
    //private Vector2 charPoint = 

    private void Update() {
        tap = swipeLeft = swipeRight = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0)){
            tap = true;
            IsDragging = true;
            startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0)){
            IsDragging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length != 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                IsDragging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                IsDragging = false;
                Reset();
            }
        }
        #endregion
    
        // Calculate the distance
        swipeDelta = Vector2.zero; //charPoint;
        if(IsDragging)
        {
            if(Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // Did we cross the deadzone?
        if(swipeDelta.magnitude > 125 )
        {
            // Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or right
                if(x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }  

            Reset();
        }
    }

    private void Reset() {
        startTouch = swipeDelta = Vector2.zero;
        IsDragging = false;
    }

    public bool Tap {get {return tap;}}
    public Vector2 SwipeDelta {get{ return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }

    
}
