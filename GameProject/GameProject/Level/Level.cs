using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Level
    {
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();            
        public List<CollisionTiles> CollisionTiles
        {
            get { return collisionTiles; }
        }
        private List<Fruit> fruits = new List<Fruit>();
        ContentManager content;

        private int width, height;

        public int Width { get { return width; } }
        public int Heigt { get { return height; } }


        public Level(ContentManager _content)
        {
            this.content = _content;          
        }

        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    if (number > 0 && number != 10)
                    {
                        collisionTiles.Add(new CollisionTiles(number, new Microsoft.Xna.Framework.Rectangle(x * size, y * size, size, size)));
                    }
                    if (number == 10)
                    {
                        Vector2 pos = new Vector2((x * size), (y * size));
                        fruits.Add(new Fruit(pos)); 
                    }
                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles item in collisionTiles)
            {
                item.Draw(spriteBatch);
            }

            foreach (Fruit item in fruits)
            {                
                item.Draw(spriteBatch);
            }
        }


    }
}
