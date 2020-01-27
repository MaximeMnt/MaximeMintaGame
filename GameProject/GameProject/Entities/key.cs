using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    class Key : Entity
    {

        private Vector2 position = new Vector2(150, 900);
        private Texture2D texture;
        public Rectangle rectangle;

        public override void Load()
        {
            texture = Resources.LoadFile["key"];
            rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, texture.Width, texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Fruit.fruitCount ==0)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }



        public override void Update(GameTime gameTime)
        {

            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); //updaten van de rectangle
            Console.WriteLine(this.rectangle);
        }
    }
}
