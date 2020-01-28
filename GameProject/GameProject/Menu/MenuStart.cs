using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    class MenuStart : Menu
    {
        Texture2D Background;
        public MenuStart(GraphicsDevice _graphicsDevice) : base(_graphicsDevice)
        {
            Background = Resources.LoadFile["Background"];
        }
        public override void Initialize() { }

        public override void LoadContent() { }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                game.MenuChange(Game1.gameState.Playing);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Vector2(PlayingState.levelWidth, PlayingState.levelHeight), Color.White);
            spriteBatch.DrawString(Resources.font, MenuMessages.gameTitle, new Vector2(150, 10),Color.Black,0, new Vector2(0,0), 3f, SpriteEffects.None,1.0f);
            spriteBatch.Draw(Resources.LoadFile["Pineapple/Pineapple10"], new Vector2(425, 40), new Rectangle(0,0,64,64) ,Color.White,1f,new Vector2(0,0),5f,SpriteEffects.None,1f);
            spriteBatch.DrawString(Resources.font, MenuMessages.MainMenuInfo, new Vector2(150, 400), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1.0f);       
            base.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
