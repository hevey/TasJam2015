using UnityEngine;
using System.Collections;

public class FogOfWar : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        
        var texture = new Texture2D(100, 100, TextureFormat.ARGB32, false);

        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                texture.SetPixel(i, j, Color.black);
            }
        }
        texture.Apply();

	    plane.GetComponent<Renderer>().material.mainTexture = texture;

        plane.transform.Translate(Vector3.back * 1.0f);
	    plane.transform.Rotate(Vector3.forward*90.0f);
	    plane.transform.Rotate(Vector3.left*90.0f);
        print(plane.transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
	    if (hit.collider != null)
	    {
            print("HIT");
	        hit.collider.gameObject.GetComponent<Renderer>().material.color += new Color(0,0,0,0);
	    }

        

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
