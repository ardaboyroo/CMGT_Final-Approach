using GXPEngine;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using TiledMapParser;


public class Level : GameObject
{
    public static TiledLoader loader;
    MyGame myGame;

    public Level(string filename)
    {
        myGame = (MyGame)game;
        loader = new TiledLoader(filename);
        CreateLevel();

    }
    public void CreateLevel(bool includeimagelayers = true)
    {
        loader.LoadImageLayers();
        loader.rootObject = this;
        loader.LoadTileLayers();
        loader.autoInstance = true;
        loader.LoadObjectGroups();

        CollisionLine[] lines = FindObjectsOfType<CollisionLine>();
        foreach (var line in lines)
        {
            Console.WriteLine("Line found at {0},{1}", line.x, line.y);
            // HERE: register the lines in global space in MyGame

            // (2) do this instead:
            CollisionLine cLine = line as CollisionLine;
            var corners = cLine.GetExtents(); // returns global space points
            //Console.WriteLine("TODO: In MyGame, add a collision line from {0} to {1}", corners[0], corners[1]);

            // top line:
            myGame.AddChild(new LineSegment(new Vec2(corners[0].x, corners[0].y), new Vec2(corners[1].x, corners[1].y)));
            // right line:
            myGame.AddChild(new LineSegment(new Vec2(corners[1].x, corners[1].y), new Vec2(corners[2].x, corners[2].y)));
            // bottom line:
            myGame.AddChild(new LineSegment(new Vec2(corners[2].x, corners[2].y), new Vec2(corners[3].x, corners[3].y)));
            // left line:
            myGame.AddChild(new LineSegment(new Vec2(corners[3].x, corners[3].y), new Vec2(corners[0].x, corners[0].y)));

            // Create a new LineSegment here (in global space)
            // MyGame.AddLine(corners[0],corners[1],...)
        }

       /* Driehoek[] driehoeken = FindObjectsOfType<Driehoek>();
        foreach (var driehoek in driehoeken)
        {
            Console.WriteLine("Line found at {0},{1}", driehoeken.x, driehoeken.y);
            // HERE: register the lines in global space in MyGame

            // (2) do this instead:
            Driehoek cLine = driehoek as Driehoek;
            var corners = cLine.GetExtents(); // returns global space points
            //Console.WriteLine("TODO: In MyGame, add a collision line from {0} to {1}", corners[0], corners[1]);

            // top line:
            myGame.AddChild(new LineSegment(new Vec2(corners[0].x, corners[0].y), new Vec2(corners[1].x, corners[1].y)));
            // right line:
            myGame.AddChild(new LineSegment(new Vec2(corners[1].x, corners[1].y), new Vec2(corners[2].x, corners[2].y)));
            // bottom line:
            myGame.AddChild(new LineSegment(new Vec2(corners[2].x, corners[2].y), new Vec2(corners[3].x, corners[3].y)));
            // left line:
            myGame.AddChild(new LineSegment(new Vec2(corners[3].x, corners[3].y), new Vec2(corners[0].x, corners[0].y)));

            // Create a new LineSegment here (in global space)
            // MyGame.AddLine(corners[0],corners[1],...)
        } */
    }



}

