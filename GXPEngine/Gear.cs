using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;

class Gear : AnimationSprite
{
    public Ball ball;

    public Gear(TiledObject obj = null) : base("circle.png", 1, 1)
    {
        ball = new Ball(16, new Vec2(x, y), new Vec2(0, 1));
        AddChild(ball);
    }
}

