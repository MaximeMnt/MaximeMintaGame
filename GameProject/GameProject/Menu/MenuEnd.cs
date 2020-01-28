using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    class MenuEnd : Menu
    {
        protected Background background;
        public MenuEnd(GraphicsDevice _graphicsDevice) : base(_graphicsDevice) { }

        public override void Initialize() {
            background = new Background();
        }

        public override void LoadContent() {
            background.LoadTexture(Resources.LoadFile["Background"]); }

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
            background.Draw(spriteBatch, new Rectangle(0, 0,PlayingState.levelWidth,PlayingState.levelHeight));
            spriteBatch.DrawString(Resources.font, MenuMessages.EndGameInfo, new Vector2(100, 10), Color.Black, 0, new Vector2(0, 0), 3f, SpriteEffects.None, 1.0f);
            spriteBatch.Draw(Resources.LoadFile["Pineapple/Pineapple10"], new Vector2(425, 40), new Rectangle(0, 0, 64, 64), Color.White, 1f, new Vector2(0, 0), 5f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Resources.font, MenuMessages.EndGameRestart, new Vector2(30, 400), Color.Black, 0, new Vector2(0, 0), 0.90f, SpriteEffects.None, 1.0f);
            base.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
