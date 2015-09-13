using System;
using System.Collections.Generic;
using System.Collections;
using System.Xml;
using UnityEngine;

public class LevelCreation : MonoBehaviour
{

    public Camera Camera;
	public Color WallColour = Color.white;
	public Color FloorColour = Color.clear;
    private WallCreation wc = new WallCreation();
	public bool startReady = false;
	public bool gendReady = false;
	public bool bendReady = false;
	public Material mat;
	public PhysicsMaterial2D pm2;
	//List<Vector3> startPoints = new List<Vector3>();
	//List<Vector3> goodEndPoints = new List<Vector3>();
	//List<Vector3> badEndPoints = new List<Vector3>();
    // Use this for initialization
	public Dictionary<string,Vector3> points = new Dictionary<string,Vector3>();
    void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		var textures = createTextures ();
       	TextAsset asset = (TextAsset)Resources.Load("test");
        List<GameObject> block = new List<GameObject>();
		List<Point> start = new List<Point> ();
		List<Point> gend = new List<Point> ();
		List<Point> bend = new List<Point> ();

        if (asset != null)
        {
            XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
            xmlDoc.LoadXml(asset.text); // load the file.
            XmlNodeList rowslist = xmlDoc.GetElementsByTagName("rows"); // array of the level nodes.
			XmlNodeList pointslist = xmlDoc.GetElementsByTagName("points");

			foreach (XmlNode pointinfo in pointslist)
			{
				XmlNodeList pointcontent = pointinfo.ChildNodes;
				foreach (XmlNode pointitem in pointcontent) // levels itens nodes.
				{

						var str = pointitem.InnerText.Split(',');
						foreach (var a in str)
						{
							var po = a.Split('-');							
							var p = (Point) ScriptableObject.CreateInstance("Point");
							p.row = Int32.Parse(po[0]);
							p.pos = Int32.Parse(po[1]);
							if (pointitem.Name == "start")
							{
								start.Add(p);
							}
							else if (pointitem.Name == "gend")
							{
								gend.Add(p);
								
							}
							else if (pointitem.Name == "bend")
							{
								bend.Add (p);
								
							}
						}

				}
			
			}

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
							sprRenderer.material = mat;

							if(aa > 0)
							{
								var p = sprGameObj.AddComponent<PolygonCollider2D>();
								p.sharedMaterial = null;
							}
							Vector3 temp = new Vector3((current * sprGameObj.GetComponent<Renderer>().bounds.size.x), rowNum-4 * sprGameObj.GetComponent<Renderer>().bounds.size.y, 0);
							
							foreach (var st in start)
							{
								if(st.row == rowNum && st.pos-5 == current && !points.ContainsKey("start"))
								{
									points.Add("start", temp);
								}
							}
							foreach (var st in gend)
							{
								if(st.row == rowNum && st.pos-5 == current && !points.ContainsKey("gend"))
								{
									//points.Add("gend", temp);
									var ge = sprGameObj.AddComponent<BoxCollider2D>();
									ge.name = "gend";
									sprGameObj.name = "gend";

									ge.isTrigger = true;
								}
							}
							foreach (var st in bend)
							{
								if(st.row == rowNum && st.pos-5 == current && !points.ContainsKey("bend"))
								{
									//points.Add("bend", temp);
									var be = sprGameObj.AddComponent<BoxCollider2D>();
									sprGameObj.name = "bend";
									be.name = "bend";
									be.isTrigger = true;
								}
							}

							sprGameObj.transform.position = temp;
							current++;
                        }
                    }
                }
            }
        }
		startReady = true;



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