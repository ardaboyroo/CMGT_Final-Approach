using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine.Scenes
{
    public class Credit : Sprite
    {
        MyGame myGame;
        int i;
        public Credit() : base("1_Credits.jpg")
        {

            myGame = (MyGame)game;
        }

        void Update()
        {
            //make sure the first 10 frames are not checked
            i++;
            //set Current level back to main manu when done with Credit
            if (Input.GetMouseButton(0) && i > 10)
                {
                    myGame.CurrentLevel = 0;
                    myGame.LevelManagement();
                }
            }
        }
    }

