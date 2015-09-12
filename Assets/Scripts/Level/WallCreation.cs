using UnityEngine;
using System;
using System.Collections.Generic;

public class WallCreation {

	private int blockSize = 50;
	 
	public Texture2D createBlank(Color wall, Color floor) {

		var	texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		for (int i = 0; i < texture.width; i++)
		{
			for (int j = 0; j < texture.height; j++)
			{
				texture.SetPixel(i, j, floor);
			}
		}
		texture.Apply ();
		return texture;
	}
    public Texture2D createEdgeBottom(Color wall, Color floor, Texture2D texture = null)
    {
		bool createFloor = false;
		if (texture == null) {
			texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
			createFloor = true;
		}

        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                if (j < texture.height / 10)
                {
                    texture.SetPixel(i, j, wall);
                }
				else if(createFloor)
                {
                    texture.SetPixel(i, j, floor);
                }
            }
        }
		texture.Apply ();
        return texture;
    }

	public Texture2D createEdgeTop(Color wall, Color floor, Texture2D texture = null)
    {
		bool createFloor = false;
		if (texture == null) {
			texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
			createFloor = true;
		}

        for (int i = 0; i < texture.width; i++)
        {
			for (int j = 0; j < texture.height; j++)
            {
                if (j > texture.height / 10 * 9)
                {
                    texture.SetPixel(i, j, wall);
                }
				else if(createFloor)
                {
                    texture.SetPixel(i, j, floor);
                }
            }
        }
		texture.Apply ();


        return texture;
    }

	public Texture2D createEdgeLeft(Color wall, Color floor, Texture2D texture = null)
    {
		bool createFloor = false;
		if (texture == null) {
			texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
			createFloor = true;
		}
        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                if (i < (texture.width / 10))
                {
                    texture.SetPixel(i, j, wall);
                }
				else if(createFloor)
                {
                    texture.SetPixel(i, j, floor);
                }
            }
        }

		texture.Apply ();
        return texture;
    }

	public Texture2D createEdgeRight(Color wall, Color floor, Texture2D texture = null)
	{
		bool createFloor = false;
		if (texture == null) {
			texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
			createFloor = true;
		}
		
		for (int i = 0; i < texture.width; i++)
		{
			for (int j = 0; j < texture.height; j++)
			{
				if (i > (texture.width / 10 * 9))
				{
					texture.SetPixel(i, j, wall);
				}
				else if(createFloor)
				{
					texture.SetPixel(i, j, floor);
				}
			}
		}
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createBottomLeftConnector(Color wall, Color floor, Texture2D texture = null)
	{
		bool createFloor = false;
		if (texture == null) {
			texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
			createFloor = true;
		}
		for (int i = 0; i < texture.width; i++)
		{
			for (int j = 0; j < texture.height; j++)
			{
				if (i < (texture.width / 10) && j < (texture.height / 10))
				{
					texture.SetPixel(i, j, wall);
				}
				else if(createFloor)
				{
					texture.SetPixel(i, j, floor);
				}
			}
		}
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createTopLeftConnector(Color wall, Color floor, Texture2D texture = null)
	{
		bool createFloor = false;
		if (texture == null) {
			texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
			createFloor = true;
		}
		for (int i = 0; i < texture.width; i++)
		{
			for (int j = 0; j < texture.height; j++)
			{
				if (i < (texture.width / 10) && j > (texture.height / 10 * 9))
				{
					texture.SetPixel(i, j, wall);
				}
				else if(createFloor)
				{
					texture.SetPixel(i, j, floor);
				}
			}
		}
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createTopRightConnector(Color wall, Color floor, Texture2D texture = null)
	{
		bool createFloor = false;
		if (texture == null) {
			texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
			createFloor = true;
		}
		for (int i = 0; i < texture.width; i++)
		{
			for (int j = 0; j < texture.height; j++)
			{
				if (i > (texture.width / 10 * 9) && j > (texture.height / 10 * 9))
				{
					texture.SetPixel(i, j, wall);
				}
				else if(createFloor)
				{
					texture.SetPixel(i, j, floor);
				}
			}
		}
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createBottomRightConnector(Color wall, Color floor, Texture2D texture = null)
	{
		bool createFloor = false;
		if (texture == null) {
			texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
			createFloor = true;
		}
		for (int i = 0; i < texture.width; i++)
		{
			for (int j = 0; j < texture.height; j++)
			{
				if (i > (texture.width / 10 * 9) && j < (texture.height / 10))
				{
					texture.SetPixel(i, j, wall);
				}
				else if(createFloor)
				{
					texture.SetPixel(i, j, floor);
				}
			}
		}
		
		texture.Apply ();
		return texture;
	}



	public Texture2D createEdgeRightBottom(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeRight (wall, floor);
		texture = createEdgeBottom (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createEdgeLeftBottom(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeLeft (wall, floor);
		texture = createEdgeBottom (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createEdgeRightTop(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeRight (wall, floor);
		texture = createEdgeTop (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}
	
	public Texture2D createEdgeLeftTop(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeLeft (wall, floor);
		texture = createEdgeTop (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createEdgeTopRightBottom(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeTop (wall, floor);
		texture = createEdgeRight (wall, floor, texture);
		texture = createEdgeBottom (wall, floor, texture);

		
		texture.Apply ();
		return texture;
	}

	public Texture2D createEdgeRightBottomLeft(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeRight (wall, floor);
		texture = createEdgeBottom (wall, floor, texture);
		texture = createEdgeLeft (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createEdgeBottomLeftTop(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeBottom (wall, floor);
		texture = createEdgeLeft (wall, floor, texture);
		texture = createEdgeTop (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createEdgeLeftTopRight(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeLeft (wall, floor);
		texture = createEdgeTop (wall, floor, texture);
		texture = createEdgeRight (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createEdgeRightBottomInternal(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeRight (wall, floor);
		texture = createEdgeBottom (wall, floor, texture);
		texture = createTopLeftConnector (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}
	
	public Texture2D createEdgeLeftBottomInternal(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeLeft (wall, floor);
		texture = createEdgeBottom (wall, floor, texture);
		texture = createTopRightConnector (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}
	
	public Texture2D createEdgeRightTopInternal(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D(blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeRight (wall, floor);
		texture = createEdgeTop (wall, floor, texture);
		texture = createBottomLeftConnector (wall, floor, texture);
		texture.Apply ();
		return texture;
	}
	
	public Texture2D createEdgeLeftTopInternal(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D (blockSize, blockSize, TextureFormat.ARGB32, false);
		
		texture = createEdgeLeft (wall, floor);
		texture = createEdgeTop (wall, floor, texture);
		texture = createBottomRightConnector (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createLeftRight(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D (blockSize, blockSize, TextureFormat.ARGB32, false);
		texture = createEdgeLeft (wall, floor);
		texture = createEdgeRight (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}

	public Texture2D createTopBottom(Color wall, Color floor)
	{
		Texture2D texture = new Texture2D (blockSize, blockSize, TextureFormat.ARGB32, false);
		texture = createEdgeTop (wall, floor);
		texture = createEdgeBottom (wall, floor, texture);
		
		texture.Apply ();
		return texture;
	}
}
