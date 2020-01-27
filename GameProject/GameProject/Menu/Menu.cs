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
        protected GraphicsDevice graphicsDevice;
        
        protected Menu(GraphicsDevice _graphicsDevice)
        {
            this.graphicsDevice = _graphicsDevice;
            
        }

        public virtual void Initialize() { }       

        public virtual void LoadContent() { }

        public abstract void Update(GameTime gameTime, Game1 game);

        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
