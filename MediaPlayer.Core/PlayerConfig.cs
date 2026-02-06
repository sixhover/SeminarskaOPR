using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.Core
{
    public static class PlayerConfig
    {
        public const int MaxVolume = 100;
        public const int MinVolume = 0;

        public static int DefaultVolume = 50;

        public static bool IsSupported(string extension)
        {
            extension = extension.ToLower();
            return extension == ".mp3" || extension == ".wav" || extension == ".mp4" ||extension == ".avi";
        }
    }
}

