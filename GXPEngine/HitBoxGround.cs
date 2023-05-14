using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

public class HitBoxGround : AnimationSprite
{
    public HitBoxGround(TiledObject obj = null) : base("square.png", 1, 1)
    {
        alpha = 0.5f;
    }
}

