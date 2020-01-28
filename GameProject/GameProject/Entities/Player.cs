using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameProject
{
    class Player : Entity
    {
        private Texture2D texture;
        private Vector2 position = new Vector2(0,900);
        private Vector2 velocity;
        public Rectangle rectangle;
        private SpriteEffects sprEff;
        private bool hasJumped = false;
        Remote remote;

        public Vector2 Position
        {
            get { return position; }
        }

        public Player(Remote _remote)
        {           
            this.remote = _remote;
            //LOOP ANIMATIE
            PlayerAnimation.CreateRunAnimation();
            //IDLE ANIMATION
            PlayerAnimation.CreateAnimationIdle();           
        }      

        private void Input(GameTime gameTime)
        {
            if (remote.Right)
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                
                //ASSIGN ANIMATIONS
                PlayerAnimation.currentAnimation = PlayerAnimation.runAnimation;
                
                sprEff = SpriteEffects.None;
            }
            else if (remote.Left)
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

                //ASSIGN ANIMATIONS
                PlayerAnimation.currentAnimation = PlayerAnimation.runAnimation;
                sprEff = SpriteEffects.FlipHorizontally;
            }
            else velocity.X = 0f;


            if (remote.Jump && hasJumped == false)
            {
                position.Y -= 5f;
                velocity.Y = -9f;
                hasJumped = true;
                Sounds.effect.Play(0.5f, 0, 0); //Jumpsound
            }

            if (remote.Idle)
            {
                PlayerAnimation.currentAnimation = PlayerAnimation.animationIdle;
            }
        }    

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.touchTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;

            }
            if (rectangle.touchLeftOf(newRectangle))
            {
                position.X = newRectangle.X - rectangle.Width - 2;
            }
            if (rectangle.touchRightOf(newRectangle))
            {
                position.X = newRectangle.X + newRectangle.Width + 2;
            }
            if (rectangle.touchBottomOf(newRectangle))
            {
                velocity.Y = 1f;
            }
            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.Y < 0)
            {
                velocity.Y = 1f;
            }
            if (position.Y > yOffset - rectangle.Height)
            {
                position.Y = yOffset - rectangle.Height;
            }

            if (position.X > xOffset - rectangle.Width)
            {
                position.X = xOffset - rectangle.Width;
            }
        }

        //LOAD,UPDATE,DRAW
        public override void Load()
        {
            texture = Resources.LoadFile["vita"];
        }

        public override void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, PlayerAnimation.currentAnimation.currentFrame.SourceRectangle.Width+10, PlayerAnimation.currentAnimation.currentFrame.SourceRectangle.Height+20); //updaten van de rectangle
            //update Input
            Input(gameTime);
            remote.Update();

            if (velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }
            //updaten van animation
            PlayerAnimation.currentAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, PlayerAnimation.currentAnimation.currentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 2, sprEff, 1);
        }
    }

}
