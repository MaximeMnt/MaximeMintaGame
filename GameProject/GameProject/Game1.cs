using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameProject
{
    //MAXIME MINTA 2EA2-CLOUD
    public class Game1 : Game
    {

        enum gameState
        {
            Playing,
            Menu,
            End
        }
        gameState currentGameState = gameState.Menu;


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        
        //VISUAL
        Map map;

        //MISC
        Camera camera;
        Remote remote;

        //ENTITIES
        Player player;
        Fruit F;

        
       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            remote = new KeyBoard();
            map = new Map(Content);           
            player = new Player(remote);
            F = new Fruit(Content, new Vector2(0, 900)); //TEMP
            base.Initialize();

        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(GraphicsDevice.Viewport);
            
            //content meegeven aan tiles
            Tiles.Content = Content;
            Sounds.Load(Content);
            Resources.LoadImages(Content);

            F.Load();
            map.setLevel(1); //welklevel
            map.GenerateLevel();            
            player.Load();


            //play background music
            Sounds.playBackgroundMusic(50);                
        }

        
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            F.Update(gameTime);
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
            map.DrawLevel(spriteBatch);
            player.Draw(spriteBatch);
            F.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
