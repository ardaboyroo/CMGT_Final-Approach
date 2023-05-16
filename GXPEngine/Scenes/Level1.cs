using GXPEngine.Dialogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine.levels
{
    class Level1 : GameObject
    {

        bool text1loaded;
        
        Level Level = new Level("Level_1.tmx");
        int speach;
        public Level1()
        {
           AddChild(Level);

            Cursor Mouse = new Cursor();
            AddChild(Mouse);

            

        }


        //Dialogue 

        void Update()
        {
            //Console.WriteLine(speach);
           /* if (Input.GetMouseButtonDown(0))
            {
                First_Text text1 = new First_Text();
                speach++;
                switch (speach)
                {
                    case 1:
                        if (!text1loaded)
                        {
                            AddChild(text1);
                        }
                        return;
                    case 2:

                        RemoveChild(Level1.);                            
                        Console.WriteLine(" remove child ");
                            
                        
                        return;
                    case 3:
                        return;
                    case 4:
                        return;
                }
            }*/
        }
    }
}
