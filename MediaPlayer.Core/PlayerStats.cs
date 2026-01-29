using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MediaPlayer.Core
{
    public class PlayerStats
    {
        public readonly DateTime StartedAt;
        public int PlayedItemsCount { get; private set; }

        public PlayerStats()
        {
            StartedAt = DateTime.Now;
            PlayedItemsCount = 0;
        }

        public void Increment()
        {
            PlayedItemsCount++;
        }
    }
}

