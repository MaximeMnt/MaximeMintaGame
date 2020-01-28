using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace GameProject
{
     class Sounds
    {
        public static SoundEffect effect;
        public static SoundEffect ananasPickup;
        public static Song BackgroundMusic;

        public static void Load(ContentManager content)
        {
           effect = content.Load<SoundEffect>("Jump");
           BackgroundMusic = content.Load<Song>("BackgroundMusic");
            ananasPickup = content.Load<SoundEffect>("AnanasPickup");
        }             

        public static void playBackgroundMusic(float volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(BackgroundMusic);
            MediaPlayer.IsRepeating = true;
        }

    }
}
