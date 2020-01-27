using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace GameProject
{
    //MAXIME MINTA 2EA2-CLOUD
    public class Game1 : Game
    {

        public enum gameState
        {
            Playing,
            End
        }       

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        //VISUAL
        Map map;
        int currentLevel = 1;

        //MISC
        Camera camera;
        Remote remote;

        //ENTITIES
        Player player;
        key key;

        //MENU
        Menu menu;

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
            key = new key();

            menu = new MenuStart();
            base.Initialize();
            

        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(GraphicsDevice.Viewport);

            //content meegeven aan tiles
            Resources.LoadImages(Content);
            Tiles.Content = Content;
            Sounds.Load(Content);
           
            map.setLevel(currentLevel);
            map.GenerateLevel();
            key.Load();
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

            player.Update(gameTime);
            key.Update(gameTime);

            //Collision&CameraMovement
            foreach (CollisionTiles item in map.LevelCurrent.CollisionTiles)
            {
                player.Collision(item.Rectangle, map.LevelCurrent.Width, map.LevelCurrent.Heigt);
                camera.Update(player.Position, map.LevelCurrent.Width, map.LevelCurrent.Heigt);                         
            }

            //collision met fruit
            foreach (Fruit item in map.LevelCurrent.Fruits.ToArray())
            {
                item.Update(gameTime);
                if (player.rectangle.Intersects(item.rectangle))
                {
                    int Collide = map.LevelCurrent.Fruits.IndexOf(item);
                    map.LevelCurrent.Fruits.RemoveAt(Collide);
                    item.hasTouched();
                    Sounds.ananasPickup.Play();
                }           
            }

            if (player.rectangle.Intersects(key.rectangle) && Fruit.fruitCount == 0 && currentLevel <= 2)
            {
                currentLevel++;
                map.setLevel(currentLevel); //welklevel mag niet gehardcoded worden
                map.GenerateLevel();
                Fruit.fruitCount = 4;
                Sounds.ananasPickup.Play();
            } else if(currentLevel > 2 )
            {
                System.Console.WriteLine("GAME END!!!");
            }

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,null,camera.Transform);
            //map.DrawLevel(spriteBatch);
            //foreach (Fruit item in map.LevelCurrent.Fruits)
            //{
            //    item.Draw(spriteBatch);
            //}
            //key.Draw(spriteBatch);
            //player.Draw(spriteBatch);

            //Enkel dit zou moeten overblijven in de game
            menu.Draw(spriteBatch);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
