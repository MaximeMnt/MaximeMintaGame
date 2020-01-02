using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Player : Entity
    {
        //FIELDS
        Animation runAnimation, animationIdle, duckAnimation, duckIdleAnimation, damageAnimation, currentAnimation;
        private Texture2D texture;
        private Vector2 position= new Vector2(0,900);
        private Vector2 velocity;
        private Rectangle rectangle;
        private SpriteEffects sprEff;
        public int playerHealth = 0;
        private bool hasJumped = false;
        Remote remote;

        //GETTERS
        public Vector2 Position
        {
            get { return position; }
        }

        //CONSTRUCTOR
        public Player(Remote _remote)
        {           
            this.remote = _remote;
            
            //LOOP ANIMATIE
            CreateRunAnimation();

            //IDLE ANIMATION
            CreateAnimationIdle();

            //bukken
            CreateDuckAnimation();
            CreateDuckIdleAnimation();          

            //Damage
            CreateDamageAnimation();


        }
        
        #region Create Animation

        private void CreateAnimationIdle()
        {
            animationIdle = new Animation(50);
            //animationIdle.AddFrame(content.Load<Texture2D>("idle1"));
            //animationIdle.AddFrame(content.Load<Texture2D>("idle2"));
            //animationIdle.AddFrame(content.Load<Texture2D>("idle3"));
            //animationIdle.AddFrame(content.Load<Texture2D>("idle4"));

            animationIdle.AddFrame(new Rectangle(0, 0, 24, 24));
            animationIdle.AddFrame(new Rectangle(24, 0, 24, 24));
            animationIdle.AddFrame(new Rectangle(48, 0, 24, 24));
            animationIdle.AddFrame(new Rectangle(72, 0, 24, 24));

            currentAnimation = animationIdle;

        }

        private void CreateRunAnimation()
        {
            runAnimation = new Animation(50);
            runAnimation.AddFrame(new Rectangle(96, 0, 24, 24));//1e is welk mannetje, 2e is welke rij, 3e is de breedte, 4e is de hoogte
            runAnimation.AddFrame(new Rectangle(120, 0, 24, 24));
            runAnimation.AddFrame(new Rectangle(144, 0, 24, 24));
            runAnimation.AddFrame(new Rectangle(168, 0, 24, 24));
            runAnimation.AddFrame(new Rectangle(192, 0, 24, 24));
            runAnimation.AddFrame(new Rectangle(216, 0, 24, 24));


            currentAnimation = runAnimation;

        }

        private void CreateDuckAnimation()
        {
            duckAnimation = new Animation(50);
            duckAnimation.AddFrame(new Rectangle(409, 0, 24, 24));
            duckAnimation.AddFrame(new Rectangle(433, 0, 24, 24));
            duckAnimation.AddFrame(new Rectangle(457, 0, 24, 24));
            duckAnimation.AddFrame(new Rectangle(481, 0, 24, 24));
            duckAnimation.AddFrame(new Rectangle(505, 0, 24, 24));
            duckAnimation.AddFrame(new Rectangle(529, 0, 24, 24));
            duckAnimation.AddFrame(new Rectangle(553, 0, 24, 24));

            currentAnimation = duckAnimation;
        }

        private void CreateDuckIdleAnimation()
        {
            duckIdleAnimation = new Animation(50);
            duckIdleAnimation.AddFrame(new Rectangle(433, 0, 24, 24));

            currentAnimation = duckAnimation;
        }

        private void CreateDamageAnimation()
        {
            damageAnimation = new Animation(50);
            damageAnimation.AddFrame(new Rectangle(360, 0, 24, 24));
            damageAnimation.AddFrame(new Rectangle(384, 0, 24, 24));
            damageAnimation.AddFrame(new Rectangle(408, 0, 24, 24));

            currentAnimation = damageAnimation;

        }

        #endregion
        public void Respawn()
        {
            this.position = new Vector2(0, 900);
        }

        private void Input(GameTime gameTime)
        {
            if (remote.right)
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

                //ASSIGN ANIMATIONS
                currentAnimation = runAnimation;
                sprEff = SpriteEffects.None;
            }
            else if (remote.left)
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

                //ASSIGN ANIMATIONS
                currentAnimation = runAnimation;
                sprEff = SpriteEffects.FlipHorizontally;
            }
            else velocity.X = 0f;


            if (remote.jump && hasJumped == false)
            {
                position.Y -= 5f;
                velocity.Y = -9f;
                hasJumped = true;
                Sounds.effect.Play(0.5f, 0, 0); //Jumpsound
            }

            if (remote.idle)
            {
                currentAnimation = animationIdle;
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
            texture = Resources.Images["player"];
        }

        public override void Update(GameTime gameTime)
        {

            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            //update Input
            Input(gameTime);
            remote.Update();

            if (velocity.Y < 10)
            {

                velocity.Y += 0.4f;
            }
            //updaten van animation
            currentAnimation.Update(gameTime);
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            //spriteBatch.Draw(texture, position, rectangle, Color.Red, 0f, new Vector2(0, 0), 0f, sprEff, 1);
            //spriteBatch.Draw(texture, position, currentAnimation.currentFrame.SourceRectangle, Color.AliceBlue, 0f, new Vector2(0, 0), 3, sprEff, 1);

        }

    }

}
