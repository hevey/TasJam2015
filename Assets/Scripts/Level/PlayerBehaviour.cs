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
}
