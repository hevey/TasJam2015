using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	public GameObject level = null;
	LevelCreation levelCreation;
	// Use this for initialization
	void Start () {
		levelCreation = level.GetComponent<LevelCreation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelCreation.startReady) {
			transform.position = levelCreation.points ["start"];
			levelCreation.startReady = false;
		}

	}
	void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log (other.collider.name);

	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Debug.Log (other.name);
	}
}
