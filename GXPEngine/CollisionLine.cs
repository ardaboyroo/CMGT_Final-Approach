using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;


class CollisionLine : AnimationSprite
{
    MyGame myGame;

    public CollisionLine(TiledObject obj = null) : base("square.png", 1, 1)
    {
        myGame = (MyGame)game;
        alpha = 0.1f;
        Console.WriteLine(rotation);
        // suggested fix: (1) don't do this:
        AddChild(new LineSegment(new Vec2(x - width / 2, y - height / 2), new Vec2(x + width / 2, y - height / 2)));
        Console.WriteLine(width);
        //AddChild(new LineSegment(new Vec2(0, 500), new Vec2(1200, 500)));
    }


    void Update()
    {

    }
}

