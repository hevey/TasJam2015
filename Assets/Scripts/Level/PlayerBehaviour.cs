using UnityEngine;
using System.Collections;
using System;

public class PlayerBehaviour : MonoBehaviour {
	public GameObject level = null;
	LevelCreation levelCreation;
	PlayVoices pv;
	// Use this for initialization
	void Start () {
		levelCreation = level.GetComponent<LevelCreation> ();
		pv = levelCreation.GetComponent<PlayVoices> ();
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
		Debug.Log (other.name);
		if(other.name.Contains(":") ){
			var inner = other.name.Split(':');
			pway pw = (pway) ScriptableObject.CreateInstance("pway");
			var po = inner[1].Split('-');


			var type = inner[0];
			var row = Int32.Parse(po[0]);
			var pos = Int32.Parse(po[1]);
			var audio = inner[2];
			if(type == "B")
			{
				switch(audio) {
				case "HaHaHa":
					pv.PlayBadHaha();
					break;
				case "GoBack":
					pv.PlayBadGoBack();
					break;
				case "YouAreAlmostThere":
					pv.PlayBadKeepGoing();
					break;
					
				case "GoLeft":
					pv.PlayBadGoLeft();
					break;
					
				case "NoNoNo":
					pv.PlayBadNoNoNo();
					break;
					
				case "StopStopStop":
				
					pv.PlayBadStopStopStop();
					break;
				default:
					break;
				}
			}
			else 
			{
				switch(audio)
				{
				case "YouAreAlmostThere":
					pv.PlayGoodKeepGoing();
					break;
					
				case "KeepGoing":
					pv.PlayGoodKeepGoing();
					
					break;
					
				case "NoNoNo":
					pv.PlayGoodNoNoNo();
					break;
					
				case "GoRight":
					pv.PlayGoodGoRight();
					break;
				case "StopStopStop":
					
					pv.PlayGoodStopStopStop();
					break;
				default:
					break;
				}
			}



		} else if (other.name == "gend") {
			Application.LoadLevel ("Win");
		} else if (other.name == "bend") {
			Application.LoadLevel ("Lose");
		} 
		 
	}
}
