using System;

namespace MediaPlayer.Core
{
    public class VideoItem : MediaItem
    {
        public string Resolution { get; set; }

        public VideoItem(string path, string resolution = "1920x1080")
            : base(path)
        {
            Resolution = resolution;
            
        }

        public override string GetInfo()
        {
            return $"Video: {Title} ({Resolution})";
        }
    }
}
