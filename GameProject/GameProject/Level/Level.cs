﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

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
        public List<Fruit> Fruits
        {
            get { return fruits; }
        }

        private int width, height;
        public int Width { get { return width; } }
        public int Height { get { return height; } }
          
        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    if (number > 0 && number != 10)
                    {
                        collisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));
                    }
                    if (number == 10)
                    {                      
                        fruits.Add(new Fruit(new Vector2(x * size, y * size)));
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
