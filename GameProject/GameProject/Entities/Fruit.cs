using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{

    class Fruit : Entity
    {
        private Vector2 position;       
        private Texture2D texture;      
        public Rectangle rectangle;
        public static int fruitCount = 4;



        public Fruit(Vector2 _position)
        {            
            Load();
            this.position = _position;
        }


        public void hasTouched()
        {
            fruitCount--;
        }       

        public override void Load()
        {
            texture = Resources.LoadFile["Pineapple/Pineapple10"];
            rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, texture.Width, texture.Height);
        }
        public override void Update(GameTime gameTime)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); //updaten van de rectangle
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
