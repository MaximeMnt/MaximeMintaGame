using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
     class Sounds
    {
        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public static SoundEffect effect= Content.Load<SoundEffect>("Jump.wav");
        public static Song BackgroundMusic = Content.Load<Song>("BackgroundMusic.wav");

        
     
        public static void playBackgroundMusic(int volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(BackgroundMusic);
            MediaPlayer.IsRepeating = true;
        }

    }
}
