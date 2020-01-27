using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public abstract class Menu
    {
        protected Background background;
        protected SpriteFont font;

        protected void Init(SpriteFont _font)
        {
            background = new Background();
            background.LoadTexture(Resources.LoadFile["Background"]);
            font = _font;
        }

        public virtual void Update(GameTime gameTime, Game1 game)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch, new Rectangle(0, 0, 1050, 1400));

        }
    }
}
