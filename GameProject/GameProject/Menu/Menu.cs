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
        protected GraphicsDevice graphicsDevice;
        public Vector2 position;
        Camera camera;
        

        protected Menu(GraphicsDevice _graphicsDevice, Camera _camera)
        {           
            this.position = new Vector2(0, 0);
            this.graphicsDevice = _graphicsDevice;
            camera = _camera;
        }

        public virtual void Initialize()
        {
            background = new Background();
        }

        public virtual void LoadContent()
        {
            background.LoadTexture(Resources.LoadFile["Background"]);
        }

        public abstract void Update(GameTime gameTime, Game1 game);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //background.Draw(spriteBatch, new Rectangle(0, 0, 1050, 1400));
        }
    }
}
