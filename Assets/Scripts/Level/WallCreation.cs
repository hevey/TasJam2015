using UnityEngine;
using System;
using System.Collections.Generic;

public class WallCreation {


    public Texture2D createEdgeTop(Color wall, Color floor)
    {
        Texture2D texture = new Texture2D(50, 50, TextureFormat.ARGB32, false);

        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                if (j < texture.height / 10)
                {
                    texture.SetPixel(i, j, wall);
                }
                else
                {
                    texture.SetPixel(i, j, floor);
                }
            }
        }

        return texture;
    }

    public Texture2D createEdgeBottom(Color wall, Color floor)
    {
        Texture2D texture = new Texture2D(50, 50, TextureFormat.ARGB32, false);

        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height - texture.height /10; j++)
            {
                if (j < (texture.height / 10))
                {
                    texture.SetPixel(i, j, wall);
                }
                else
                {
                    texture.SetPixel(i, j, floor);
                }
            }
        }


        return texture;
    }

    public Texture2D createEdgeLeft(Color wall, Color floor)
    {
        Texture2D texture = new Texture2D(50, 50, TextureFormat.ARGB32, false);

        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                if (j < (texture.width / 10))
                {
                    texture.SetPixel(i, j, wall);
                }
                else
                {
                    texture.SetPixel(i, j, floor);
                }
            }
        }


        return texture;
    }
}
