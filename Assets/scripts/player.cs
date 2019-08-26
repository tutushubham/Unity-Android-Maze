using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	private bool tap, swipeleft, swiperight, swipeup, swipedown , isDraging;
	private Vector2 startTouch, swipeDelta;

	public Vector2 SwipeDelta{ get { return swipeDelta; }}
	public bool SwipeLeft  { get { return swipeleft; }}
	public bool SwipeRight  { get { return swiperight; }}
	public bool SwipeUp  { get { return swipeup; }}
	public bool SwipeDown  { get { return swipedown; }}

	private void Update(){
		tap = swipeleft = swiperight = swipeup = swipedown = false;

		if (Input.GetMouseButtonDown (0)) {
			tap = true;
			isDraging = true;
			startTouch = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp (0)) {
			isDraging = false;
			Reset ();
		}

		if(Input.touches.Length > 0){
			if(Input.touches[0].phase ==TouchPhase.Began ){
				tap = true;
				isDraging = true;
				startTouch = Input.touches[0].position;
			}
			else if(Input.touches[0].phase ==TouchPhase.Ended || Input.touches[0].phase ==TouchPhase.Canceled){
				isDraging = false;
				Reset();
			}
		}

		swipeDelta = Vector2.zero;
		if(isDraging){
			if(Input.touches.Length > 0){
				swipeDelta = Input.touches[0].position - startTouch;
				swipeDelta = swipeDelta *10;
			}
			else if(Input.GetMouseButton(0)){
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
				swipeDelta = swipeDelta *2;
			}

		}

		if(swipeDelta.magnitude > 100){

			float x =swipeDelta.x;
			float y =swipeDelta.y;

			if(Mathf.Abs(x) > Mathf.Abs(y)){
				if(x < 0){
					swipeleft = true;
				}
				else{
					swiperight = true;
				}
			}
			else{
				if(y < 0){
					swipedown = true;
				}
				else{
					swipeup = true;
				}
			}

			Reset();
		}


	}
	private void Reset(){
		startTouch = swipeDelta = Vector2.zero;
		isDraging = false;
	}

}
