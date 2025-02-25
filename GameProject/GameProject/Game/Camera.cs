﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public class Camera
    {
        //FIELDS
        private Matrix transform;
        public Vector2 center;
        private Viewport viewPort;

        //GETTERS
        public Matrix Transform
        {
            get { return transform; }         
        }
        public Camera(Viewport newViewPort)
        {
            viewPort = newViewPort;
        }

        //UPDATE METHOD
        public void Update(Vector2 position, int xOffset, int yOffset)
        {
            if (position.X < viewPort.Width / 2)
            {
                center.X = viewPort.Width / 2;
            }
            else if (position.X > xOffset - (viewPort.Width / 2))
            {
                center.X = xOffset - (viewPort.Width / 2);
            }
            else center.X = position.X;

            if (position.Y < viewPort.Height / 2)
            {
                center.Y = viewPort.Height / 2;
            }
            else if (position.Y > yOffset - (viewPort.Height / 2))
            {
                center.Y = yOffset - (viewPort.Height / 2);
            }
            else center.Y = position.Y;

            transform = Matrix.CreateTranslation(new Vector3(-center.X + (viewPort.Width / 2), -center.Y +(viewPort.Height/2),0));
        }
    }
}
