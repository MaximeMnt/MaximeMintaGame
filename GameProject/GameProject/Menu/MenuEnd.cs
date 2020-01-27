using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class MenuEnd : Menu
    {
        public MenuEnd(GraphicsDevice _graphicsDevice,Camera _camera) :base(_graphicsDevice, _camera)
        {
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void LoadContent()
        {
            throw new NotImplementedException();
        }
    }
}
