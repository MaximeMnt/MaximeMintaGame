using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Camera
    {
        private Matrix transform;

        public Matrix Transform
        {
            get { return transform; }         
        }

        private Vector2 centre;
        private Viewport viewPort;

        public Camera(Viewport newViewPort)
        {
            viewPort = newViewPort;
        }

        public void Update(Vector2 position, int xOffset, int yOffset)
        {
            if (position.X < viewPort.Width / 2)
            {
                centre.X = viewPort.Width / 2;
            }
            else if (position.X > xOffset - (viewPort.Width / 2))
            {
                centre.X = xOffset - (viewPort.Width / 2);
            }
            else centre.X = position.X;

            if (position.Y < viewPort.Height / 2)
            {
                centre.Y = viewPort.Height / 2;
            }
            else if (position.Y > yOffset - (viewPort.Height / 2))
            {
                centre.Y = yOffset - (viewPort.Height / 2);
            }
            else centre.Y = position.Y;



            transform = Matrix.CreateTranslation(new Vector3(-centre.X + (viewPort.Width / 2), -centre.Y +(viewPort.Height/2),0));

        }
    }
}
