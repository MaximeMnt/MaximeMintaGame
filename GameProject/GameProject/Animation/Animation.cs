using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Animation
    {
        private List<AnimationFrame> frames;
        public AnimationFrame currentFrame;
        private double xOffset;
        int counter = 0, speed;

        public Animation(int _speed)
        {
            frames = new List<AnimationFrame>(); ;
            xOffset = 0;
            speed = _speed;
        }

        public void AddFrame(Texture2D texture)
        {
            AnimationFrame frame = new AnimationFrame()
            {
                SourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height),
                SourceTexture = texture
            };
            frames.Add(frame);
            currentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            xOffset += currentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.Milliseconds / speed;
            if (xOffset >= currentFrame.SourceRectangle.Width)
            {
                counter++;
                if (counter >= frames.Count)
                    counter = 0;

                currentFrame = frames[counter];
                xOffset = 0;
            }
        }
    }
}
