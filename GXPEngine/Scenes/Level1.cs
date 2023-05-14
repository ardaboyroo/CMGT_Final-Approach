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

        public Level1()
        {
           AddChild(Level);

        }

        
        

    }
}
