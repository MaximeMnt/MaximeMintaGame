using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    //MAXIME MINTA 2EA2-CLOUD
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Background background;
        Map map;
        Player player;
        Camera camera;
        Remote remote;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            background = new Background();
            remote = new KeyBoard();
            map = new Map();
            player = new Player(Content,remote);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            background.LoadTexture(Content.Load<Texture2D>("Background"));
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(GraphicsDevice.Viewport);
            //content meegeven aan tiles
            Tiles.Content = Content;
            //Sounds.Content = Content;


            map.setLevel("level1"); //welklevel
            map.GenerateLevel();            
            player.Load(Content);


            //play background music
            //Sounds.playBackgroundMusic(50);                
        }

        
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            //Collision&CameraMovement
            foreach (CollisionTiles item in map.LevelCurrent.CollisionTiles)
            {
                player.Collision(item.Rectangle, map.LevelCurrent.Width, map.LevelCurrent.Heigt);
                camera.Update(player.Position, map.LevelCurrent.Width, map.LevelCurrent.Heigt);
            }

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,null,camera.Transform);
            background.Draw(spriteBatch, new Rectangle(0, 0, 1050, 1400));
            map.DrawLevel(spriteBatch);
            player.Draw(spriteBatch);     
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
