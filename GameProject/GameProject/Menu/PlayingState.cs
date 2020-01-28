using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    class PlayingState:Menu
    {
        //ENTITIES
        Player player;
        Key key;

        //VISUAL
        Map map;
        int currentLevel = 1;

        //MISC
        Camera camera;
        Remote remote;

        GraphicsDevice graphicsDevice;

        //Background
        Texture2D Background;

        //levelwidth & Heigt
        public static int levelWidth;
        public static int levelHeight;

        public PlayingState(GraphicsDevice _graphicsDevice):base(_graphicsDevice)
        {
            this.graphicsDevice = _graphicsDevice;
        }
        public override void Initialize()
        {
            map = new Map();
            remote = new KeyBoard();
            player = new Player(remote);
            key = new Key();
            this.camera = new Camera(graphicsDevice.Viewport);



        }

        public override void LoadContent()
        {
            map.setLevel(currentLevel);
            map.GenerateLevel();
            key.Load();
            player.Load();

            Background = Resources.LoadFile["Background"];

            levelWidth = map.LevelCurrent.Width;
            levelHeight = map.LevelCurrent.Height;
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            player.Update(gameTime);
            key.Update(gameTime);

            //Collision&CameraMovement
            foreach (CollisionTiles item in map.LevelCurrent.CollisionTiles)
            {
                player.Collision(item.Rectangle, map.LevelCurrent.Width, map.LevelCurrent.Height);
                camera.Update(player.Position, map.LevelCurrent.Width, map.LevelCurrent.Height);
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

            //Collision met key
            if (player.rectangle.Intersects(key.rectangle) && Fruit.fruitCount == 0 && currentLevel <= 2)
            {
                currentLevel++;
                map.setLevel(currentLevel); 
                map.GenerateLevel();
                Fruit.fruitCount = 4;
                Sounds.ananasPickup.Play();
            }
            else if (currentLevel > 2)
            {
                camera.Update(new Vector2(0,900),map.LevelCurrent.Width, map.LevelCurrent.Height);
                game.MenuChange(Game1.gameState.End);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                currentLevel++;
            }

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Rectangle(0, 0, map.LevelCurrent.Width, map.LevelCurrent.Height), Color.White);
            spriteBatch.End();
            
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            map.DrawLevel(spriteBatch);
            foreach (Fruit item in map.LevelCurrent.Fruits)
            {
                item.Draw(spriteBatch);
            }
            key.Draw(spriteBatch);
            player.Draw(spriteBatch);
            base.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
