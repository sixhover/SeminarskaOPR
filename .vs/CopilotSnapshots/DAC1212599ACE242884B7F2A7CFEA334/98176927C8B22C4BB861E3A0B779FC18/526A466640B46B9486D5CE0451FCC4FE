using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.Core
{
    public class Playlist
    {
        private MediaItem[] items;
        private int count;
        private Random random = new Random();


        public delegate bool FilterKriterij(MediaItem item);//delegate za filtriranje 
        public int Count { get { return count; } }

        public MediaItem[] Items
        {
            get
            {



                MediaItem[] currentItems = new MediaItem[count];
                for (int i = 0; i < count; i++)
                {
                    currentItems[i] = items[i];
                }
                return currentItems;
            }
        }

        
        public MediaItem this[int index]
        {
            get
            {
                if (index >= 0)
                {
                    if (index < count)
                    {
                        return items[index];
                    }
                }
                return null;
            }
        }

        public Playlist()
        {
            items = new MediaItem[10];
            count = 0;
        }
        public MediaItem[] Isci(FilterKriterij kriterij)
        {
            List<MediaItem> rezultati = new List<MediaItem>();

            for (int i = 0; i < count; i++)
            {
                // Namesto fiksnega iskanja, pokličemo delegat!
                if (kriterij(items[i]))
                {
                    rezultati.Add(items[i]);
                }
            }
            return rezultati.ToArray();
        }
        public bool Add(MediaItem item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].FilePath == item.FilePath)
                    return false;
            }

            if (count == items.Length)
            {
                MediaItem[] newItems = new MediaItem[items.Length * 2];
                for (int i = 0; i < items.Length; i++)
                {
                    newItems[i] = items[i];
                }
                items = newItems;
            }

            items[count] = item;
            count++;
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < count)
            {
                for (int i = index; i < count - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                items[count - 1] = null;
                count--;
            }
        }

        public MediaItem GetAt(int index) => this[index];

        public void Clear()
        {
            for (int i = 0; i < count; i++) items[i] = null;
            count = 0;
        }

        public void Shuffle()
        {
            for (int i = count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                MediaItem temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

        public MediaItem[] Search(string search)
        {
            int found = 0;
            string s = search.ToLower();
            for (int i = 0; i < count; i++)
            {
                if (items[i].Title.ToLower().Contains(s)) found++;
            }

            MediaItem[] results = new MediaItem[found];
            int resIndex = 0;
            for (int i = 0; i < count; i++)
            {
                if (items[i].Title.ToLower().Contains(s))
                {
                    results[resIndex] = items[i];
                    resIndex++;
                }
            }
            return results;
        }

        public void SortByDuration()
        {
            if (count < 2) return;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (items[j].Duration > items[j + 1].Duration)
                    {

                        MediaItem temp = items[j];

                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                    }
                }
            }
        }

        ~Playlist() { Clear(); }
    }
}