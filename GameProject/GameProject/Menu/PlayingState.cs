using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        


        public PlayingState(GraphicsDevice _graphicsDevice, Camera _camera):base(_graphicsDevice, _camera)
        {
            this.graphicsDevice = _graphicsDevice;
            this.camera = _camera;
        }
        public override void Initialize()
        {
            map = new Map();
            remote = new KeyBoard();
            player = new Player(remote);
            key = new Key();
        }

        public override void LoadContent()
        {
            //camera = new Camera(graphicsDevice.Viewport);

            map.setLevel(currentLevel);
            map.GenerateLevel();
            key.Load();
            player.Load();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
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
            }
            else if (currentLevel > 2)
            {
                System.Console.WriteLine("GAME END!!!");
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            map.DrawLevel(spriteBatch); //Map is null
            foreach (Fruit item in map.LevelCurrent.Fruits)
            {
                item.Draw(spriteBatch);
            }
            key.Draw(spriteBatch);
            player.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
