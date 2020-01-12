using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Collision
{
    interface ICollisionable
    {
        private Rectangle rectangle;
        public Rectangle Rectangle { get { return rectangle; } protected set { rectangle = value; } }
    }
}
