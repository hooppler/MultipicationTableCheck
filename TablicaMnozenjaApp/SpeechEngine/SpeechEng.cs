using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace TablicaMnozenjaApp.SpeechEngine
{
    public class SpeechEng
    {
        public MediaPlayer player = new MediaPlayer();

        public SpeechEng()
        {
        }

        public void OpenFile(int FirstNumber, int SecondNumber)
        {
            string file_name = FirstNumber.ToString() + "x" + SecondNumber.ToString() + ".mp3";
            string path = "Media/";
            string full_path = path + file_name;

            Uri uri_path = new Uri(full_path, UriKind.Relative);
            player.Open(uri_path);
        }

        public void Play()
        {
            player.Position = new TimeSpan(0);
            player.Play();
        }
    }
}
