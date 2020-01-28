using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public abstract class Remote
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Idle { get; set; }
        public bool Jump { get; set; }
        public abstract void Update();
    }


    public class KeyBoard : Remote
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.Left))
            {
                Left = true;
                Idle = false;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Left = false;
                Idle = false;
            }

            if (stateKey.IsKeyDown(Keys.Right))
            {
                Right = true;
                Idle = false;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                Right = false;
                Idle = false;
            }
            if (stateKey.GetPressedKeys().Length == 0)
            {
                Idle = true;
            }
            if (stateKey.IsKeyDown(Keys.Up))
            {
                Jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                Jump = false;
            }
        }
    }
}
