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
    class Map
    {
        public ContentManager content;
        public Level level1, level2;
        public Background background;

        int[,] level1Array = new int[,] {
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10 },
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 ,2 ,2 ,2 },
            {0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,0 ,0 ,0 ,0 ,0 ,0 },
            {0 ,0 ,0 ,0 ,2 ,2 ,2 ,0 ,0 ,0 ,10 ,0 ,0 ,0 ,2 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,2 },
            {10 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 },
            {2 ,2 ,2 ,0 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 },
            {0 ,0 ,0 ,0 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,2 ,0 ,0 ,2 ,2 ,2 ,0 ,0 ,2 ,2 ,2 ,2 },
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 ,0 ,2 ,2 ,0 ,0 ,0 ,0 ,2 ,0 ,0 ,0 ,0 ,0 },
            {2 ,0 ,0 ,0 ,0 ,0 ,2 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 ,0 ,0 ,0 ,2 ,0 ,0 ,0 ,0 ,0 },
            {2 ,2 ,0 ,0 ,0 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,0 ,2 ,2 ,0 ,0 ,0 ,0 },
            {2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,2 ,0 },
            {2 ,2 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,2 ,2 ,2 },
            {0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 ,2 ,0 ,0 ,0 ,2 ,2 ,2 ,2 ,0 ,0 ,2 ,0 ,0 ,0 ,0 },
            {0 ,0 ,0 ,0 ,0 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 ,2 ,2 ,0 ,2 ,2 ,2 ,0 ,0 ,0 },
            {0 ,0 ,0 ,0 ,2 ,2 ,2 ,0 ,0 ,0 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,0 ,10 },
            {1 ,1 ,1 ,1 ,2 ,2 ,2 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 }
        };

        int[,] level2Array = new int[,]
        {
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,0 ,2 ,2 ,2 ,2 },
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 },
            {0 ,0 ,0 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,10 },
            {0 ,0 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,0 ,0 ,2 ,2 ,2 ,2 ,0 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 },
            {2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {0 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {0 ,0 ,0 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {0 ,0 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {2 ,10 ,2 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 ,2 ,2 ,0 ,0 },
            {2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,0 ,0 ,2 ,2 ,0 ,2 ,2 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,2 },
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 },
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 },
            {0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 ,2 ,2 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,2 ,2 ,2 },
            {0 ,0 ,0 ,0 ,2 ,2 ,10 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,2 ,0 ,0 ,0 ,0 ,10 },
            {1 ,1 ,1 ,1 ,2 ,2 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 }
        };

        public Level LevelCurrent;


        public Map(ContentManager _content)
        {
            this.content = _content;
            Init();
        }

        public void Init()
        {
            level1 = new Level(content);
            level2 = new Level(content);
            background = new Background();
        }

        public void setLevel(int level)
        {
            if (level == 1)
            {
                LevelCurrent = level1;
            } else if(level == 2)
            {
                LevelCurrent = level2;
            }         
        }

        public void GenerateLevel()
        {
            background.LoadTexture(Resources.LoadFile["Background"]);

            if (LevelCurrent == level1)
            {
                level1.Generate(level1Array, 64);
            } else if(LevelCurrent == level2)
            {
                level2.Generate(level2Array, 64);

            } 
        }

        public void DrawLevel(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch, new Rectangle(0, 0, 1050, 1400));
            LevelCurrent.Draw(spriteBatch); 
        }
    }
}
