using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;
using TiledMapParser;

public class Driehoek : Sprite
{
    public Driehoek(TiledObject obj) : base("5_Driehoek.png")
    {

    }

    void Update()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if(collisions[i] is Cursor && Input.GetMouseButton(0)) {
                SetXY(Input.mouseX, Input.mouseY);
            }
        }
    }
}
         
  
    

