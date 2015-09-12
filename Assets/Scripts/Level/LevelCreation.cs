using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LevelCreation : MonoBehaviour
{

    public Camera Camera;

    private WallCreation wc = new WallCreation();

    // Use this for initialization
    void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        //var texture = wc.createEdgeTop(Color.green, Color.clear);
        var texture = wc.createEdgeBottom(Color.green, Color.clear);

        texture.Apply();
        Sprite spr = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(1f, 1f), 40);
        GameObject sprGameObj = new GameObject();
        for (int iy = 0; iy < 10; iy++)
        {
            for (int ix = 0; ix < 10; ix++)
            {

                sprGameObj.name = "Floor";
                sprGameObj.AddComponent<SpriteRenderer>();
                SpriteRenderer sprRenderer = sprGameObj.GetComponent<SpriteRenderer>();
                sprRenderer.sprite = spr;

                Vector3 temp = new Vector3((ix * sprGameObj.GetComponent<Renderer>().bounds.size.x), iy * sprGameObj.GetComponent<Renderer>().bounds.size.y, 0);
                Instantiate(sprGameObj);
                sprGameObj.transform.position = temp;
      
            }
        }
        

       /* TextAsset asset = (TextAsset)Resources.Load("test");
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
                        UnityEngine.GameObject[] str = rowitem.InnerText.Split(',');
                        foreach (var a in str)
                        {
                            block.Add(a);
                        }
                    }
                }
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }


    void createTextures ()
    {
        // Create a new 2x2 texture ARGB32 (32 bit with alpha) and no mipmaps
        
        Texture2D edgeRight = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        Texture2D edgeLeft = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        Texture2D cornerTopLeft = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        Texture2D cornerTopRight = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        Texture2D cornerBottomRight = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        Texture2D cornerBottomLeft = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        Texture2D corridorHorizontal = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        Texture2D corridorVertical = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        Texture2D corridorTopRight = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        Texture2D corridorBottomRight = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        Texture2D corridorBottomLeft = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        Texture2D CorridorTopLeft = new Texture2D(100, 100, TextureFormat.ARGB32, false);


        

        // Apply all SetP;
    }
}