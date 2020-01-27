using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Background: Game1
    {
        //PROPS
        Texture2D background;
        private Vector2 position;

        //CONSTRUCTOR
        public Background(Texture2D _texture)
        {
            this.position = new Vector2(0, 0);
            this.background = _texture;
        }

        public Background() { }

        //LOAD
        public void LoadTexture(Texture2D texture)
        {
            this.background = texture;
        }

        //DRAW
        public void Draw(SpriteBatch spriteBatch, Rectangle sourceRectangle)
        {
            spriteBatch.Draw(background, position, sourceRectangle, Color.White, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 0);
        }
    }
}
