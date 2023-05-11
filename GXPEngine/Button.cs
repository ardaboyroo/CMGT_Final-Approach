using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

public class Button : AnimationSprite
{
    public string buttonType;
    public Button(TiledObject obj = null) : base("square.png",1,1)
    {
        alpha = 0; // set to 0 to make invis

        buttonType = obj.GetStringProperty("Button");
    }

    void Update()
    {
        
    }

  
}

