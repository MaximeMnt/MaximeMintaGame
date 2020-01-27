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

        //MISC
        Camera camera;
        Remote remote;

        //MENU
        Menu menu;

        //Font
        SpriteFont font; 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public void MenuChange(gameState gs)
        {
            if (gs == gameState.Playing)
            {
                this.menu = new PlayingState(GraphicsDevice, this.camera);
                
            }
            if (gs == gameState.End)
            {
                this.menu = new MenuEnd(GraphicsDevice, this.camera);
            }
            menu.Initialize();
            menu.LoadContent();
        }

        
        protected override void Initialize()
        {
            remote = new KeyBoard();          
            base.Initialize(); 
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(GraphicsDevice.Viewport);
            font = Content.Load<SpriteFont>("File");
           
            //Sprites + sounds inladen
            Resources.LoadImages(Content);
            Sounds.Load(Content);

            //Menu aanmaken
            menu = new MenuStart(font, GraphicsDevice, this.camera); //Ging niet anders
            

            //play background music
            Sounds.playBackgroundMusic(50);                
        }

        
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {      
            menu.Update(gameTime,this);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            //spriteBatch.Begin();
            //Enkel dit zou moeten overblijven in de game
            menu.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
