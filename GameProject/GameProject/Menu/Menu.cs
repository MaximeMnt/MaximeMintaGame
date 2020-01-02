using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Menu
{
    class Menu
    {
        protected Background background;
        protected int level;

        protected Menu(int _level)
        {
            Init();
            this.level = _level;
        }

        protected void Init()
        {
            background = new Background();
            background.LoadTexture(Resources.Images["Background"]);
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
