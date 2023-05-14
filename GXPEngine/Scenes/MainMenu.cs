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
        //AddChild(Gear);
    }
    

}

    


