using UnityEngine;
using System.Collections;

public class VirtualControls : MonoBehaviour {
	private int leftTouchId = -1;
	private int rightTouchId = -1;

	private Vector2 rightTouchPosition;
	private Vector2 leftTouchPosition;

	public float speed = 10.0f;
	public float slideMagnitudeX = 0.0f;
	public float slideMagnitudeY = 0.0f;
	// Use this for initialization
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
				}
				if(touch.position.x <= ScreenPercentageX(50)){
					
					leftTouchId = touch.fingerId;
					leftTouchPosition=touch.position;
					slideMagnitudeX = 0;
					slideMagnitudeY = 0;
				}
				
				
			}
			if(touch.phase == TouchPhase.Moved)
			{
				if(touch.fingerId == leftTouchId)
				{
					Debug.Log("Left Moved");
					Vector2 move = touch.position - leftTouchPosition;
					slideMagnitudeX = move.x / Screen.width * speed;
					
					// slide vert
					slideMagnitudeY = move.y / Screen.height * speed;
					GetComponent<Rigidbody2D> ().velocity = new Vector2(slideMagnitudeX,slideMagnitudeY);

				}
				if(touch.fingerId == rightTouchId)
				{
					Debug.Log("Right Moved");
				}
			}
			if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
			{
				if(touch.fingerId == rightTouchId)
				{
					rightTouchId = -100;
				}
				if(touch.fingerId == leftTouchId)
				{
					leftTouchId = -100;
					slideMagnitudeX = 0;
					slideMagnitudeY = 0;
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
