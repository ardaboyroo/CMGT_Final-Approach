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
    bool ballPresent = false;

    public Gear(TiledObject obj = null) : base("circle.png", 1, 1)
    {
        //Console.WriteLine($"X: {x} Y: {y}"); // bogus - always print 0,0
        //ball = new Ball(16, new Vec2(x, y), new Vec2(0, 1));
    }

    void AddBall()
    {
        if (!ballPresent)
        {
            ball = new Ball(32, new Vec2(0, 0));
            AddChild(ball);
            ballPresent = true;
        }
    }

    public void Update()
    {
        AddBall();
        //ball.Step();
    }
}

