using UnityEngine;
using System.Collections;

public class TorchScript : MonoBehaviour
{

    public Transform target;
    public Transform obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 fwd = transform.TransformDirection(Vector2.up);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, obj.position,100);
        //Debug.DrawLine(transform.position, obj.position, Color.green,100);
        GameObject light = GameObject.FindGameObjectWithTag("spotlight");

	    if (light != null)
	    {
            var newVector = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
            var rotation = new Quaternion(0.0f,0.0f,180.0f,0.0f);
	        light.transform.position = newVector;
	        light.transform.rotation = rotation;
            light.transform.LookAt(obj.position);
	    }
        if (hitInfo.collider != null)
        {
            //Debug.Log("Testing");
//            Debug.Log(hitInfo.collider);
  //          Debug.DrawRay(transform.position, obj.transform.position,Color.red);
        }


    }
}
