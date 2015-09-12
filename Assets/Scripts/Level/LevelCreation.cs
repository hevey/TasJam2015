using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LevelCreation : MonoBehaviour
{

    public Camera Camera;
	public Color WallColour = Color.white;
	public Color FloorColour = Color.clear;
    private WallCreation wc = new WallCreation();

    // Use this for initialization
    void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		var textures = createTextures ();
       	TextAsset asset = (TextAsset)Resources.Load("test");
        List<GameObject> block = new List<GameObject>();

        if (asset != null)
        {
            XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
            xmlDoc.LoadXml(asset.text); // load the file.
            XmlNodeList rowslist = xmlDoc.GetElementsByTagName("rows"); // array of the level nodes.

            foreach (XmlNode rowinfo in rowslist)
            {
                XmlNodeList rowcontent = rowinfo.ChildNodes;
                foreach (XmlNode rowitem in rowcontent) // levels itens nodes.
                {
                    if (rowitem.Name == "row")
                    {
                        var str = rowitem.InnerText.Split(',');
						var rowNum = Int32.Parse(rowitem.Attributes["num"].Value);
						var current = -5;
                        foreach (var a in str)
                        {
							int aa = Int32.Parse(a);
							Sprite spr = Sprite.Create(textures[aa], new Rect(0, 0, textures[aa].width, textures[aa].height), new Vector2(1f, 1f), 40);
							GameObject sprGameObj = new GameObject();
							sprGameObj.name = "Floor";
							sprGameObj.AddComponent<SpriteRenderer>();
							SpriteRenderer sprRenderer = sprGameObj.GetComponent<SpriteRenderer>();
							sprRenderer.sprite = spr;
							if(aa > 0)
								sprGameObj.AddComponent<PolygonCollider2D>();

							Vector3 temp = new Vector3((current * sprGameObj.GetComponent<Renderer>().bounds.size.x), rowNum-4 * sprGameObj.GetComponent<Renderer>().bounds.size.y, 0);
							sprGameObj.transform.position = temp;
							current++;
                        }
                    }
                }
            }
        }
    }

	Texture2D[] createTextures ()
    {
		Texture2D[] texs = new Texture2D[19];
		texs [0] = wc.createBlank (WallColour, FloorColour);
		texs [1] = wc.createEdgeTop (WallColour, FloorColour);
		texs [2] = wc.createEdgeBottom (WallColour, FloorColour);
		texs [3] = wc.createEdgeLeft (WallColour, FloorColour);
		texs [4] = wc.createEdgeRight (WallColour, FloorColour);
		texs [5] = wc.createEdgeRightBottom (WallColour, FloorColour);
		texs [6] = wc.createEdgeLeftBottom (WallColour, FloorColour);
		texs [7] = wc.createEdgeLeftTop (WallColour, FloorColour);
		texs [8] = wc.createEdgeRightTop (WallColour, FloorColour);
		texs [9] = wc.createEdgeTopRightBottom (WallColour, FloorColour);
		texs [10] = wc.createEdgeRightBottomLeft (WallColour, FloorColour);
		texs [11] = wc.createEdgeBottomLeftTop (WallColour, FloorColour);
		texs [12] = wc.createEdgeLeftTopRight (WallColour, FloorColour);
		texs [13] = wc.createEdgeRightBottomInternal (WallColour, FloorColour);
		texs [14] = wc.createEdgeLeftBottomInternal (WallColour, FloorColour);
		texs [15] = wc.createEdgeRightTopInternal (WallColour, FloorColour);
		texs [16] = wc.createEdgeLeftTopInternal (WallColour, FloorColour);
		texs [17] = wc.createLeftRight (WallColour, FloorColour);
		texs [18] = wc.createTopBottom (WallColour, FloorColour);

		return texs;
    }
}