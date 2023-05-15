﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Box : Sprite
{
    public Box(TiledObject obj) : base("5_Square.png")
    {

    }

    void Update()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is Cursor && Input.GetMouseButton(0))
            {
                SetXY(Input.mouseX, Input.mouseY);
            }
        }
    }
}

