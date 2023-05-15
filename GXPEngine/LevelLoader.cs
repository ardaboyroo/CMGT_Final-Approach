using GXPEngine;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using TiledMapParser;


public class Level : GameObject
{
    public static TiledLoader loader;

    public Level(string filename)
    {
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
            Console.WriteLine(  "Line found at {0},{1}",line.x,line.y);
            // HERE: register the lines in global space in MyGame

            // (2) do this instead:
            CollisionLine cLine = line as CollisionLine;
            var corners = cLine.GetExtents(); // returns global space points
            Console.WriteLine("TODO: In MyGame, add a collision line from {0} to {1}",corners[0],corners[1]);
            // Create a new LineSegment here (in global space)
            // MyGame.AddLine(corners[0],corners[1],...)
        }
    }

    

}

