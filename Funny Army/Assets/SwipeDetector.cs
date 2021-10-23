using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
	private Vector2 fingerDownPos;
	private Vector2 fingerUpPos;

	public bool detectSwipeAfterRelease = false;

	public float SWIPE_THRESHOLD = 20f;

	public int Counter;
	// Update is called once per frame
	void Update()
	{
        if (Counter == -1)
        {
			GameManager.instance.CameraAnim.SetBool("Left", true);
		}

		if (Counter == 0)
		{
			GameManager.instance.CameraAnim.SetBool("Left", false);
			GameManager.instance.CameraAnim.SetBool("Right", false);
		}

        if (Counter == 1)
        {
			GameManager.instance.CameraAnim.SetBool("Right", true);
		}

		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				fingerUpPos = touch.position;
				fingerDownPos = touch.position;
			}

			//Detects Swipe while finger is still moving on screen
			if (touch.phase == TouchPhase.Moved)
			{
				if (!detectSwipeAfterRelease)
				{
					fingerDownPos = touch.position;
					DetectSwipe();
				}
			}

			//Detects swipe after finger is released from screen
			if (touch.phase == TouchPhase.Ended)
			{
				fingerDownPos = touch.position;
				DetectSwipe();
			}
		}
	}

	void DetectSwipe()
	{

		if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
		{
		//	Debug.Log("Vertical Swipe Detected!");
			if (fingerDownPos.y - fingerUpPos.y > 0)
			{
				OnSwipeUp();
			}
			else if (fingerDownPos.y - fingerUpPos.y < 0)
			{
				OnSwipeDown();
			}
			fingerUpPos = fingerDownPos;

		}
		else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
		{
			//Debug.Log("Horizontal Swipe Detected!");
			if (fingerDownPos.x - fingerUpPos.x > 0)
			{
				OnSwipeRight();
			}
			else if (fingerDownPos.x - fingerUpPos.x < 0)
			{
				OnSwipeLeft();
			}
			fingerUpPos = fingerDownPos;

		}
		else
		{
		//	Debug.Log("No Swipe Detected!");
		}
	}

	float VerticalMoveValue()
	{
		return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
	}

	float HorizontalMoveValue()
	{
		return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
	}

	void OnSwipeUp()
	{
		//Do something when swiped up
	}

	void OnSwipeDown()
	{
		//Do something when swiped down
	}

	void OnSwipeLeft()
	{
		//GameManager.instance.CameraAnim.SetBool("Left", true);
        if (Counter > -1)
        {
			Counter--;
        }
	}

	void OnSwipeRight()
	{
		if (Counter < 1)
		{
			Counter++;
		}
	}
}
