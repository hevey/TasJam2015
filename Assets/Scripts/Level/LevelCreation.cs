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
	private PlayVoices pv;
	public List<pway> pwaylistman = new List<pway>();
	
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

		/*int ran = 0;

		if (ran == 0) {
		
		} else {
		}*/

        if (asset != null)
        {
            XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
            xmlDoc.LoadXml(asset.text); // load the file.
            XmlNodeList rowslist = xmlDoc.GetElementsByTagName("rows"); // array of the level nodes.
			XmlNodeList pointslist = xmlDoc.GetElementsByTagName("points");
			XmlNodeList waypointslist = xmlDoc.GetElementsByTagName("waypoints");
			foreach (XmlNode waypointinfo in waypointslist) 
			{
				XmlNodeList pointcontent = waypointinfo.ChildNodes;
				foreach (XmlNode pointitem in pointcontent) // levels itens nodes.
				{
					var str = pointitem.InnerText.Split(',');
					foreach (var a in str)
					{
						var inner = a.Split(':');
						pway pw = (pway) ScriptableObject.CreateInstance("pway");
						var po = inner[1].Split('-');
						pw.type = inner[0];
						pw.row = Int32.Parse(po[0]);
						pw.pos = Int32.Parse(po[1]);
						pw.audio = inner[2];
						pw.nametouse = a;
						pwaylistman.Add(pw);
					}
					Debug.Log (pwaylistman.Count);
				}
			}
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
								sprGameObj = getCollider(sprGameObj, aa);
							}
							Vector3 temp = new Vector3((current * sprGameObj.GetComponent<Renderer>().bounds.size.x), rowNum * sprGameObj.GetComponent<Renderer>().bounds.size.y, 0);
							
							foreach (var st in start)
							{
								if(st.row == rowNum && st.pos == current && !points.ContainsKey("start"))
								{
									points.Add("start", temp);
								}
							}
							foreach (var st in gend)
							{
								if(st.row == rowNum && st.pos == current && !points.ContainsKey("gend"))
								{
									points.Add("gend", temp);
									var ge = sprGameObj.AddComponent<BoxCollider2D>();
									ge.name = "gend";
									sprGameObj.name = "gend";

									ge.isTrigger = true;
								}
							}
							foreach (var st in bend)
							{
								if(st.row == rowNum && st.pos == current && !points.ContainsKey("bend"))
								{
									points.Add("bend", temp);
									var be = sprGameObj.AddComponent<BoxCollider2D>();
									sprGameObj.name = "bend";
									be.name = "bend";
									be.isTrigger = true;
								}
							}
							foreach ( var ppp in pwaylistman)
							{
								if(ppp.row == rowNum && ppp.pos == current)
								{
									var be = sprGameObj.AddComponent<BoxCollider2D>();
									sprGameObj.name = ppp.nametouse;
									be.name = ppp.nametouse;
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

	GameObject getCollider(GameObject go, int element)
	{
		switch (element) {
		case 0:
			return createBlankTrigger(go);
			break;
		case 1:
			return createEdgeTopTrigger(go);
			break;
		case 2:
			return createEdgeBottomTrigger(go);
			break;
		case 3:
			return createEdgeLeftTrigger(go);
			break;
		case 4:
			return createEdgeRightTrigger(go);
			break;
		case 5:
			return createEdgeRightBottomTrigger(go);
			break;
		case 6:
			return createEdgeLeftBottomTrigger(go);
			break;
		case 7:
			return createEdgeLeftTopTrigger(go);
			break;
		case 8:
			return createEdgeRightTopTrigger(go);
			break;
		case 9:
			return createEdgeTopRightBottomTrigger(go);
			break;
		case 10:
			return createEdgeRightBottomLeftTrigger(go);
			break;
		case 11:
			return createEdgeBottomLeftTopTrigger(go);
			break;
		case 12:
			return createEdgeLeftTopRightTrigger(go);
			break;
		case 13:
			return createEdgeRightBottomInternalTrigger(go);
			break;
		case 14:
			return createEdgeLeftBottomInternalTrigger(go);
			break;
		case 15:
			return createEdgeRightTopInternalTrigger(go);
			break;
		case 16:
			return createEdgeLeftTopInternalTrigger(go);
			break;
		case 17:
			return createLeftRightTrigger(go);
			break;
		case 18:
			return createTopBottomTrigger(go);
			break;
		default:
			throw new Exception("No collider defined");
		}
	}

	GameObject createBlankTrigger(GameObject go) {
		return go;
	}
	GameObject createEdgeTopTrigger(GameObject go) {
		var box = go.AddComponent<BoxCollider2D> ();
		var size = go.GetComponent<Renderer> ().bounds.size;
		size.y /= 10;
		box.size = size;
		box.offset = new Vector2 (-(box.size.x / 2), -(box.size.y / 2));
		return go;
	}
	GameObject createEdgeBottomTrigger(GameObject go) {
		var box = go.AddComponent<BoxCollider2D> ();
		var size = go.GetComponent<Renderer> ().bounds.size;
		var normalsize = go.GetComponent<Renderer> ().bounds.size;
		size.y /= 10;
		box.size = size;

		box.offset = new Vector2 (-(box.size.x / 2),-normalsize.y+((box.size.y / 2)));
		return go;
	}
	GameObject createEdgeLeftTrigger(GameObject go) {
		var box = go.AddComponent<BoxCollider2D> ();
		var size = go.GetComponent<Renderer> ().bounds.size;
		var normalsize = go.GetComponent<Renderer> ().bounds.size;
		size.x /= 10;
		box.size = size;
		box.offset = new Vector2 (-normalsize.x+(box.size.x / 2), -(box.size.y / 2));
		return go;
	}
	GameObject createEdgeRightTrigger(GameObject go) {
		var box = go.AddComponent<BoxCollider2D> ();
		var size = go.GetComponent<Renderer> ().bounds.size;
		size.x /= 10;
		box.size = size;
		box.offset = new Vector2 (-(box.size.x / 2), -(box.size.y / 2));
		return go;
	}
	GameObject createEdgeRightBottomTrigger(GameObject go) {
		go = createEdgeRightTrigger (go);
		go = createEdgeBottomTrigger (go);
		return go;
	}
	GameObject createEdgeLeftBottomTrigger(GameObject go) {
		go = createEdgeLeftTrigger (go);
		go = createEdgeBottomTrigger (go);
		return go;
	}
	GameObject createEdgeLeftTopTrigger(GameObject go) {
		go = createEdgeLeftTrigger (go);
		go = createEdgeTopTrigger (go);
		return go;
	}
	GameObject createEdgeRightTopTrigger(GameObject go) {
		go = createEdgeRightTrigger (go);
		go = createEdgeTopTrigger (go);
		return go;
	}
	GameObject createEdgeTopRightBottomTrigger(GameObject go) {
		go = createEdgeRightTrigger (go);
		go = createEdgeTopTrigger (go);
		go = createEdgeBottomTrigger (go);
		return go;
	}
	GameObject createEdgeRightBottomLeftTrigger(GameObject go) {
		go = createEdgeRightTrigger (go);
		go = createEdgeLeftTrigger (go);
		go = createEdgeBottomTrigger (go);
		return go;
	}
	GameObject createEdgeBottomLeftTopTrigger(GameObject go) {
		go = createEdgeLeftTrigger (go);
		go = createEdgeTopTrigger (go);
		go = createEdgeBottomTrigger (go);
		return go;
	}
	GameObject createEdgeLeftTopRightTrigger(GameObject go) {
		go = createEdgeRightTrigger (go);
		go = createEdgeTopTrigger (go);
		go = createEdgeLeftTrigger (go);
		return go;
	}
	GameObject createEdgeRightBottomInternalTrigger(GameObject go) {
		go = createEdgeRightTrigger (go);
		go = createEdgeBottomTrigger (go);
		return go;
	}
	GameObject createEdgeLeftBottomInternalTrigger(GameObject go) {
		go = createEdgeLeftTrigger (go);
		go = createEdgeBottomTrigger (go);
		return go;
	}
	GameObject createEdgeRightTopInternalTrigger(GameObject go) {
		go = createEdgeRightTrigger (go);
		go = createEdgeTopTrigger (go);
		return go;
	}
	GameObject createEdgeLeftTopInternalTrigger(GameObject go) {
		go = createEdgeTopTrigger (go);
		go = createEdgeLeftTrigger (go);
		return go;
	}
	GameObject createLeftRightTrigger(GameObject go) {
		go = createEdgeRightTrigger (go);
		go = createEdgeLeftTrigger (go);
		return go;
	}
	GameObject createTopBottomTrigger(GameObject go) {
		go = createEdgeTopTrigger (go);
		go = createEdgeBottomTrigger (go);
		return go;
	}


}