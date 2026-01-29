using System;
using System.IO;

namespace MediaPlayer.Core
{
    public abstract class MediaItem
    {
        private string filePath;

        public string Title { get;  set; }
        public TimeSpan Duration { get;  set; }


        public interface IVolumeControl
        {
            void Mute();
            void FadeOut(int steps, int intervalMilisec);
            int CurrentVolume { get; set; }
        }
        


        public string FilePath
        {
            get { return filePath; }
            protected set
            {
                if (File.Exists(value))
                    filePath = value;
                else
                    throw new FileNotFoundException("Datoteka ne obstaja.");
            }
        }

        protected MediaItem(string path)
        {
            FilePath = path;
            Title = Path.GetFileNameWithoutExtension(path);
        }

        public virtual string GetInfo()
        {
            return $"{Title}";
        }

        public static bool operator >(MediaItem a, MediaItem b)
        {
            return a.Duration > b.Duration;
        }

        public static bool operator <(MediaItem a, MediaItem b)
        {
            return a.Duration < b.Duration;
        }
    }
}
