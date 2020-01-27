using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    class MenuStart : Menu
    {
        protected SpriteFont font;

        public MenuStart(SpriteFont _font, GraphicsDevice _graphicsDevice, Camera _camera) : base(_graphicsDevice, _camera)
        {
            this.font = _font;
        }
        public override void Initialize()
        {
            background = new Background();
        }

        public override void LoadContent()
        {
            background.LoadTexture(Resources.LoadFile["Background"]);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Environment.Exit(0);
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                game.MenuChange(Game1.gameState.Playing);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //background.Draw(spriteBatch, new Rectangle(0, 0, 1050, 1400)); //ISNULL
            spriteBatch.DrawString(font, MenuMessages.gameTitle, new Vector2(150, 550),Color.Black,0, new Vector2(0,0), 3f, SpriteEffects.None,0);
            spriteBatch.DrawString(font, MenuMessages.MainMenuInfo, new Vector2(150, 950), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }
    }
}
