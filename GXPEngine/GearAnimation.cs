using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

public class GearAnimation : AnimationSprite
{
    public GearAnimation(TiledObject obj = null) : base("1_GearAnimationSheet.png", 7, 7)
    {
        SetCycle(0, 46);
    }

    void Update()
    {
        Animate(0.2f);
    }

}

