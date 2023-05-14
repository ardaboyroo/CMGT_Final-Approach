using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;
using GXPEngine.levels;
using GXPEngine.Scenes;

public class MyGame : Game
{
    bool _stepped = false;
    bool _paused = false;
    int _stepIndex = 0;
    public int CurrentLevel = 0;
    public MainMenu menu;

    Canvas _lineContainer = null;

    public List<Ball> movers;
    public List<LineSegment> _lines;

    public MyGame() : base(1280, 704, false, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        //targetFps = 1;

        Console.WriteLine("MyGame initialized");
        LevelManagement();

        _lineContainer = new Canvas(width, height);
        AddChild(_lineContainer);

        movers = new List<Ball>();
        _lines = new List<LineSegment>();
    }

    // For every game object, Update is called every frame, by the engine:
    void Update()
    {
        StepThroughMovers();
        // Empty

    }

    public void LevelManagement()
    {
        const int mainMenu = 0;
        const int level1 = 1;

        //Overlays
        const int credits = 20;
        const int options = 21;

        switch (CurrentLevel)
        {
            case mainMenu:
                DestroyAll();
                menu = new MainMenu();
                AddChild(menu);
                Console.WriteLine("MainMenu loaded");
                break;

            case level1:
                DestroyAll();
                //AddChild(new Ball(16, new Vec2(100, 100)));
                AddChild(new LineSegment(new Vec2(0, 500), new Vec2(1200, 500)));
                Level1 Level = new Level1();
                AddChild(Level);
                break;

            case credits:
                DestroyAll();
                Credit creditScreen = new Credit();
                AddChild(creditScreen);
                break;

        }

    }

    void DestroyAll()
    {
        List<GameObject> children = GetChildren(true);
        for (int i = children.Count - 1; i >= 0; i--)
        {
            children[i].Destroy();

        }
    }

    public int GetNumberOfLines()
    {
        return _lines.Count;
    }



    public LineSegment GetLine(int index)
    {
        if (index >= 0 && index < _lines.Count)
        {
            return _lines[index];
        }
        return null;
    }

    public int GetNumberOfMovers()
    {
        return movers.Count;
    }

    public Ball GetMover(int index)
    {
        if (index >= 0 && index < movers.Count)
        {
            return movers[index];
        }
        return null;
    }

    public void DrawLine(Vec2 start, Vec2 end)
    {
        _lineContainer.graphics.DrawLine(Pens.White, start.x, start.y, end.x, end.y);
    }

    void StepThroughMovers()
    {
        if (_stepped)
        { // move everything step-by-step: in one frame, only one mover moves
            _stepIndex++;
            if (_stepIndex >= movers.Count)
            {
                _stepIndex = 0;
            }
            if (movers[_stepIndex].moving)
            {
                movers[_stepIndex].Step();
            }
        }
        else
        { // move all movers every frame
            foreach (Ball mover in movers)
            {
                if (mover.moving)
                {
                    mover.Step();
                }
            }
        }
    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}