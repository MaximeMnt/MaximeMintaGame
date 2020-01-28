using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        //MENU
        Menu menu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public void MenuChange(gameState gs)
        {
            if (gs == gameState.Playing)
            {
                this.menu = new PlayingState(GraphicsDevice);

            }
            if (gs == gameState.End)
            {
                this.menu = new MenuEnd(GraphicsDevice);             
            }
            menu.Initialize();
            menu.LoadContent();
        }
 
        protected override void Initialize()
        {
            base.Initialize(); 
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
           
            //Sprites + sounds inladen
            Resources.LoadImages(Content);
            Resources.LoadFont(Content);
            Sounds.Load(Content);

            //Menu aanmaken
            menu = new MenuStart(GraphicsDevice); //Ging niet anders (zonder grote refactor)
            menu.Initialize();
            menu.LoadContent();

            //play background music
            Sounds.playBackgroundMusic(0.5f);                
        }
       
        protected override void UnloadContent(){  }

        protected override void Update(GameTime gameTime)
        {      
            menu.Update(gameTime,this);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            menu.Draw(spriteBatch);       
            base.Draw(gameTime);
        }
    }
}
