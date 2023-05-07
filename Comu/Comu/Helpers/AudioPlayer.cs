using Comu.BaseVVM;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Comu.Helpers
{
    public sealed  class AudioPlayer
    {
        ISimpleAudioPlayer Audio;

        public AudioPlayer()
        {
           Audio = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        }
        private static AudioPlayer _AudioPlayer;
        public static AudioPlayer GetInstance() 
        {

            if (_AudioPlayer == null) 
            {
                _AudioPlayer = new AudioPlayer();
            }
           
            return _AudioPlayer;
        }

       public  void Si() 
        {
             SearchSound("si.mp3");
           
        }
         public void No()
        {
           SearchSound("no.mp3");
        }
        private void SearchSound(string sound) 
        {
            try
            {

                var assembly = typeof(App).GetTypeInfo().Assembly;
                var stream = assembly.GetManifestResourceStream("Comu.Sonido." + sound);
              
                Audio.Load(stream);
                Audio.Play();
            }
            catch (Exception) { return; }
           
        }




    }
}
