﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Fruit : Entity
    {
        private Vector2 position = new Vector2(0, 900);       
        private Texture2D texture;      
        //private Vector2 position;
        Animation FruitIdleAnimation;
        public Rectangle rectangle;
        private ContentManager content;

        public Fruit(ContentManager _content, Vector2 position)
        {          
            this.content = _content;
            //this.texture = content.Load<Texture2D>("Pineapple/Pineapple1");


            //IDLE ANIMATION
            CreateAnimationIdle();

            //this.position = position;

        }


        

        private void CreateAnimationIdle()
        {
            FruitIdleAnimation = new Animation(50);
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple1"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple2"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple3"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple4"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple5"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple6"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple7"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple8"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple9"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple10"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple11"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple12"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple13"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple14"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple15"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple16"));
            //FruitIdleAnimation.AddFrame(content.Load<Texture2D>("Pineapple/Pineapple17"));
        }

        public override void Load()
        {
            this.texture = Resources.Images["Pineapple/Pineapple1"];
            rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, texture.Width, texture.Height);

        }
        public override void Update(GameTime gameTime)
        {
            //FruitIdleAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
          //spriteBatch.Draw(texture, position, FruitIdleAnimation.currentFrame.SourceRectangle, Color.AliceBlue, 0f, new Vector2(0, 0), 0, SpriteEffects.None, 1);
           //spriteBatch.Draw(texture, position, Color.White); //TEXTURE IS NULL?
        }  
    }
}
