using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class MainMenu : GameObject
{
    MyGame mygame;
    public MainMenu()
    {
        mygame = (MyGame)game;


        Cursor Mouse = new Cursor();
        AddChild(Mouse);

        Level Mainmenu = new Level("MainMenu.tmx");
        AddChild(Mainmenu);

        GearVisualTest Gear = new GearVisualTest();
        AddChild(Gear);
    }
    //load tiled level which has buttons
    
    // give buttons id's in tiled and link actions to them 
    // get collision info with mouse and which button


    //load animation sprite with moving background

    void ButtonCheck()
    {
        
    }

}

    


