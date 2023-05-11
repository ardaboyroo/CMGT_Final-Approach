using GXPEngine;
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

    }

    

}

