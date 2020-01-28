using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class PlayerAnimation
    {
        public static Animation runAnimation, animationIdle, currentAnimation;
        public static void CreateAnimationIdle()
        {
            animationIdle = new Animation(70);
            animationIdle.AddFrame(new Rectangle(0, 0, 24, 24));
            animationIdle.AddFrame(new Rectangle(24, 0, 24, 24));
            animationIdle.AddFrame(new Rectangle(48, 0, 24, 24));
            animationIdle.AddFrame(new Rectangle(72, 0, 24, 24));

            currentAnimation = animationIdle;
        }

        public static void CreateRunAnimation()
        {
            runAnimation = new Animation(50);
            runAnimation.AddFrame(new Rectangle(96, 0, 24, 24));
            runAnimation.AddFrame(new Rectangle(120, 0, 24, 24));
            runAnimation.AddFrame(new Rectangle(144, 0, 24, 24));
            runAnimation.AddFrame(new Rectangle(168, 0, 24, 24));
            runAnimation.AddFrame(new Rectangle(192, 0, 24, 24));
            runAnimation.AddFrame(new Rectangle(216, 0, 24, 24));

            currentAnimation = runAnimation;
        }

    }
}
