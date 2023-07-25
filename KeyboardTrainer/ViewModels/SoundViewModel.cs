using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace KeyboardTrainer.ViewModels
{
    internal class SoundViewModel
    {
        private System.Media.SoundPlayer clickButtonSound;
        public SoundViewModel()
        {
            clickButtonSound = new System.Media.SoundPlayer(@"../../Resources/Sound/button-press.wav");
        }
        public void PlaySoundClickButton()
        {         
           clickButtonSound.Play();
        }
    }
}
