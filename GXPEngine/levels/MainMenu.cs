using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class MainMenu : Sprite
{
    public MainMenu() : base("Circle.png")
    {
        //change to background image or make the whole menu a tiled map

    }

    void Update()
    {
        ButtonChecker();
    }

    void ButtonChecker()
    {
        //check for button

        //if start button
        if (1 == 2)
        {
            MyGame.CurrentLevel = 1;
        }

        //if quit button
        if (1 == 2)
        {
            Console.WriteLine("Exiting game");
            Environment.Exit(0);
        }

    }
}

    


