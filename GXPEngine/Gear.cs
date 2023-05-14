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
        Console.WriteLine($"X: {x} Y: {y}");
        //ball = new Ball(16, new Vec2(x, y), new Vec2(0, 1));
    }

    void AddBall()
    {
        if (!ballPresent)
        {
            ball = new Ball(32, new Vec2(x, y));
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

