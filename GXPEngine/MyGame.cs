using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;
using GXPEngine.levels;

public class MyGame : Game {

	public int CurrentLevel = 0;
	public MyGame() : base(1280, 720, false)     // Create a window that's 800x600 and NOT fullscreen
	{
		

		Console.WriteLine("MyGame initialized");
		LevelManagement();
	}

	// For every game object, Update is called every frame, by the engine:
	void Update() {
		// Empty

	}

	public void LevelManagement()
	{
		const int MainMenu = 0;
		const int level1 = 1;

		switch (CurrentLevel)
		{
			case MainMenu:
				DestroyAll();
				MainMenu menu = new MainMenu();
				AddChild(menu);
				Console.WriteLine("MainMenu loaded");
				break;
			case level1:
				Level1 Level = new Level1();
				AddChild(Level);
			
				break;
			case 2:
				
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