using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class GearVisualTest : Sprite
    {
        float Vx = 1.5f;
        public GearVisualTest() : base("circle.png")
        {
            SetOrigin(this.width/2,this.height/2);
            SetXY(0 , game.height/2);
        }

        void Update()
        {
            rotation += Vx;
            x += Vx;
        }
    }
}
