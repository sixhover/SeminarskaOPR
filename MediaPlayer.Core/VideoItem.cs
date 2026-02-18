using System;

namespace MediaPlayer.Core
{
    public class VideoItem : MediaItem
    {
        public string Resolution { get; set; }

        public VideoItem(string path) : base(path)
        {
            this.Type = MediaType.Video;
            this.Resolution = "1080p";
        }

        public override string GetInfo()
        {
            return $"Video: {Title} ({Resolution})";
        }
    }
}
