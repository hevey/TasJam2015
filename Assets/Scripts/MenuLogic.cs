using UnityEngine;
using System.Collections;

public class MenuLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        var touchCount = Input.touchCount;
        if (touchCount > 0)
	    {
            print("Got Here");
	        Application.LoadLevel("Level1");
	    }
	}
}
