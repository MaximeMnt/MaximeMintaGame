using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Resources
    {
        //FIELDS
        public static Dictionary<string, Texture2D> LoadFile;
        public static SpriteFont font;

        //LOAD
        public static void LoadImages(ContentManager content)
        {
            LoadFile = new Dictionary<string, Texture2D>();

            List<string> graphics = new List<string>()
            {
                "Tile1",
                "Tile2",
                "Background",
                "player",
                "vita",
                "Pineapple/Pineapple10",
                "key"
            };

            foreach (string item in graphics)
            {
                LoadFile.Add(item, content.Load<Texture2D>(item));
            }
        }

        public static void LoadFont(ContentManager content)
        {
            font = content.Load<SpriteFont>("File");
        }
    }
}
