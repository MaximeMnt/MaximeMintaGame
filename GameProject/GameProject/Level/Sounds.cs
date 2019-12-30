﻿using Microsoft.Xna.Framework.Audio;
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
        public static SoundEffect effect;
        public static Song BackgroundMusic;

        public static void Load(ContentManager content)
        {
           effect = content.Load<SoundEffect>("Jump");
           BackgroundMusic = content.Load<Song>("BackgroundMusic");
        }             
     
        public static void playBackgroundMusic(int volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(BackgroundMusic);
            MediaPlayer.IsRepeating = true;
        }

    }
}
