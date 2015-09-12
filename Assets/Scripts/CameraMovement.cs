using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float height = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Camera main = Camera.main;
		var newVector = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 10);
		main.transform.position = newVector;
		
	}
}
