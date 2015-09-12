﻿using UnityEngine;
using System.Collections;

public class VirtualControls : MonoBehaviour {
	private int leftTouchId = -1;
	private int rightTouchId = -1;

	private Vector2 rightTouchPosition;
	private Vector2 leftTouchPosition;

	public float speed = 10.0f;
	public float moveMagnitudeX = 0.0f;
	public float moveMagnitudeY = 0.0f;

	public float rotateMagnitude = 0.0f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var touchCount = Input.touchCount;

		for (int j= 0 ; j < touchCount ; j++ ) {
			Touch touch= Input.GetTouch(j);
			
			if(touch.phase == TouchPhase.Began)
			{
				if(touch.position.x > ScreenPercentageX(50)){
					
					rightTouchId = touch.fingerId;
					rightTouchPosition=touch.position;
					rotateMagnitude = 0;
				}
				if(touch.position.x <= ScreenPercentageX(50)){
					
					leftTouchId = touch.fingerId;
					leftTouchPosition=touch.position;
					moveMagnitudeX = 0;
					moveMagnitudeY = 0;
				}
				
				
			}
			if(touch.phase == TouchPhase.Moved)
			{
				if(touch.fingerId == leftTouchId)
				{
					Vector2 move = touch.position - leftTouchPosition;
					moveMagnitudeX = move.x / Screen.width * speed;
					
					// slide vert
					moveMagnitudeY = move.y / Screen.height * speed;
					GetComponent<Rigidbody2D> ().velocity = new Vector2(moveMagnitudeX,moveMagnitudeY);

				}
				if(touch.fingerId == rightTouchId)
				{
					Vector2 move = touch.position - rightTouchPosition;
					rotateMagnitude = move.x / Screen.width * speed;
					float h = 0.5f * touch.deltaPosition.y ;
					transform.Rotate( 0, 0, h, Space.World );
					transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z);
				}
			}
			if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
			{
				if(touch.fingerId == rightTouchId)
				{
					rightTouchId = -100;
					rotateMagnitude = 0;


				}
				if(touch.fingerId == leftTouchId)
				{
					leftTouchId = -100;
					moveMagnitudeX = 0;
					moveMagnitudeY = 0;
					GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				}
				
			}
		}
	}

	float ScreenPercentageX ( int percentage  ){
		return Screen.width / 100 * percentage;
	}
	
	float ScreenPercentageY ( int percentage  ){
		return Screen.height / 100 * percentage;
	}
}
