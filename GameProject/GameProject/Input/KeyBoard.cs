using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public abstract class Remote
    {
        public bool left { get; set; }
        public bool right { get; set; }
        public bool idle { get; set; }
        public bool sprint { get; set; }
        public bool jump { get; set; }
        public bool duck { get; set; }
        public abstract void Update();
    }


    public class KeyBoard : Remote
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.RightShift))
            {
                sprint = true;
            }
            if (stateKey.IsKeyUp(Keys.RightShift))
            {
                sprint = false;
            }
            if (stateKey.IsKeyDown(Keys.Left))
            {
                left = true;
                idle = false;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                left = false;
                idle = false;
            }

            if (stateKey.IsKeyDown(Keys.Right))
            {
                right = true;
                idle = false;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                right = false;
                idle = false;
            }
            if (stateKey.GetPressedKeys().Length == 0)
            {
                idle = true;
            }
            if (stateKey.IsKeyDown(Keys.Up))
            {
                //jump
                jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                jump = false;
            }
            if (stateKey.IsKeyDown(Keys.Down))
            {
                //bukken
                duck = true;                
            }
            if (stateKey.IsKeyUp(Keys.Down))
            {
                duck = false;
            }

            
        }
    }
}
