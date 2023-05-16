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
       
            GameObject[] collisions = GetCollisions();
                for (int i = 0; i < collisions.Length; i++)
                {
                    //Console.WriteLine(collisions[i]);
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
                           // Console.WriteLine("WHOOOO Start BUTTON");
                            myGame.CurrentLevel = 1;
                            myGame.LevelManagement();
                        }

                        if (button.buttonType is "Options" && Input.GetMouseButton(0))
                        {
                            //Console.WriteLine("WHOOOO Options BUTTON");
                        }

                        if (button.buttonType is "Credit" && Input.GetMouseButton(0))
                        {
                           // Console.WriteLine("WHOOOO Credit BUTTON");
                            myGame.CurrentLevel = 20;
                            myGame.LevelManagement();
                        }

                        if (button.buttonType is "Quit" && Input.GetMouseButton(0))
                        {
                            //Console.WriteLine("WHOOOO Quit BUTTON");
                            Environment.Exit(0);
                        }

                    }

                    if (collisions[i] is HomeButton)
                    {
                        //Console.WriteLine(" Home Button xxxxxxxxxxxxxxxxx");
                       if (Input.GetMouseButton(0));
                        {
                            myGame.CurrentLevel = 0;
                            myGame.LevelManagement();
                        }
                    }
                   // else if (collisions[i] is "Greyout.png"){ soundPlayed= false; }

                }   
                return;
        
    }

    void PlaySelectSound()
    {
        if (Input.GetMouseButtonUp(0))
        {
            UISelectSound = new Sound("menubutton.wav", false, false).Play();
        }
    }
}

