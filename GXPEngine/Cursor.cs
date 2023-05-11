using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class Cursor : Sprite
    {

   
    public Cursor() : base("circle.png")
    {
        SetOrigin(this.width/2, this.height/2);
        scale = 0.1f;

       
    }

    void Update()
    {
        this.x = Input.mouseX;
        this.y = Input.mouseY;

        CheckCollision();
    }

    void CheckCollision()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is Button)
            {
                Button button = (Button)collisions[i];

                // check what the string in Tiled says, act accordingly 
                if (button.buttonType is "Start" && Input.GetMouseButton(0))
                {
                    Console.WriteLine("WHOOOO Start BUTTON");    
                }

                if (button.buttonType is "Options" && Input.GetMouseButton(0))
                {
                    Console.WriteLine("WHOOOO Options BUTTON");
                }

                if (button.buttonType is "Credit" && Input.GetMouseButton(0))
                {
                    Console.WriteLine("WHOOOO Credit BUTTON");
                }

                if (button.buttonType is "Quit" && Input.GetMouseButton(0))
                {
                    Console.WriteLine("WHOOOO Quit BUTTON");
                }
            }

        }
    }
}
// this sprite needs to return an id so that the class in questions know with
// which item the cursor is colliding
