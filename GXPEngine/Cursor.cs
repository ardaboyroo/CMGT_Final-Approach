using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TiledMapParser;

public class Cursor : Sprite
    {

    MyGame  myGame;
    

    SoundChannel UISelectSound;
    public Cursor() : base("circle.png")
    {
        alpha = 0;
        SetOrigin(this.width/2, this.height/2);
        scale = 0.1f;

        myGame = (MyGame)game;
         

       
    }

    void Update()
    {
        this.x = Input.mouseX;
        this.y = Input.mouseY;

        CheckCollision();
    }

    void CheckCollision()
    {
        //check which scene is active for the correct collision data
        const int mainMenu = 0;
        const int level1 = 1;

        //Overlays
        const int credits = 20;
        const int options = 21;
        switch (myGame.CurrentLevel)
        {
        case mainMenu: 
            GameObject[] collisions = GetCollisions();
                for (int i = 0; i < collisions.Length; i++)
                {

                    if (collisions[i] is Button)
                    {
                        Button button = (Button)collisions[i];

                        //play clicky select sound
                        PlaySelectSound();

                        //highlight area
                        button.buttonAlpha = 0.1f;

                        // check what the string in Tiled says, act accordingly 
                        if (button.buttonType is "Start" && Input.GetMouseButton(0))
                        {
                            Console.WriteLine("WHOOOO Start BUTTON");
                            myGame.CurrentLevel = 1;
                            myGame.LevelManagement();
                        }

                        if (button.buttonType is "Options" && Input.GetMouseButton(0))
                        {
                            Console.WriteLine("WHOOOO Options BUTTON");
                        }

                        if (button.buttonType is "Credit" && Input.GetMouseButton(0))
                        {
                            Console.WriteLine("WHOOOO Credit BUTTON");
                            myGame.CurrentLevel = 20;
                            myGame.LevelManagement();
                        }

                        if (button.buttonType is "Quit" && Input.GetMouseButton(0))
                        {
                            Console.WriteLine("WHOOOO Quit BUTTON");
                            Environment.Exit(0);
                        }

                    }

                }   
                return;
        }
    }

    void PlaySelectSound()
    {
        UISelectSound = new Sound("xxxxxxxxxxxxxxxxxx", false, false).Play();
    }
}
// this sprite needs to return an id so that the class in questions know with
// which item the cursor is colliding
