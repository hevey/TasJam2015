using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 oldPosition = transform.position;
        transform.Translate(1 * (-Time.deltaTime), 0, 0);
    }
}
