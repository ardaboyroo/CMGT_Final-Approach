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
            switch (speach)
            {
                case 0:

                    return;
                case 1:
                    return;
                case 2:
                    return;
                case 3:
                    return;
            }
        }
    }
}
