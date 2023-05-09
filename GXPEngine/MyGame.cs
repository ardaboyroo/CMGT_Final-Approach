using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;

public class MyGame : Game {

	public int CurrentLevel;
	public MyGame() : base(1280, 720, false)     // Create a window that's 800x600 and NOT fullscreen
	{
		

		Console.WriteLine("MyGame initialized");
	}

	// For every game object, Update is called every frame, by the engine:
	void Update() {
		// Empty
	}

	void LevelManagement()
	{
		switch (CurrentLevel)
		{
			case 1:
				DestroyAll();
				MainMenu menu = new MainMenu();
				AddChild(menu);
				break;
			case 2:

				break;
			case 3:

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

    static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}