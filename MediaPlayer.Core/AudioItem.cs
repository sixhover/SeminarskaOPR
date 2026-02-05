using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.Core
{
    public class AudioItem : MediaItem
    {
        public string Artist { get; set; }

        public AudioItem(string path, string artist = "Neznan")
            : base(path)
        {
            Artist = artist;
        }

        public override string GetInfo()
        {
            return $"Audio: {Title} - {Artist}";
        }
    }
}
