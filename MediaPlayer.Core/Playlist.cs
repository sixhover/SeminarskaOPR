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

        public int Count { get { return count; } }


        public MediaItem[] Items
        {
            get
            {
                MediaItem[] result = new MediaItem[count];
                for(int i =0; i < count; i++)
                {
                    result[i] = items[i];
                }
                return result;
            }
        }




        public Playlist()
        {
            items = new MediaItem[10];
            count = 0;
        }

        

        public bool Add(MediaItem item)
        {

            for (int i = 0; i < count; i++)
            {
                if (items[i].FilePath == item.FilePath)
                {
                    return false;
                }
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
            count = count + 1;
            return true;
        }

        public void RemoveAt(int index)
        {
            if(index>=0 && index < count)
            {
                for(int i = index; i < count - 1; i++)
                {
                    items[i] = items[i + 1];


                }
                items[count - 1] = null;

                count--;
            }
        }

        public MediaItem GetAt(int index)
        {
            if(index >=0 && index < count)
            {
                return items[index];
            }
            else{
                return null;
            }
        }
        public void Clear()
        {
            for(int i = 0; i < count; i++)
            {

                items[i] = null;
            }
            count = 0;
        }


        public void Shuffle()
        {
            for (int i = count-1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                MediaItem temp = items[i];


                items[i] = items[j];
                items[j] = temp;
            }
        }

        public TimeSpan GetTotalDuration()
        {
            TimeSpan total = TimeSpan.Zero;
            for(int i = 0; i < count; i++)
            {
                total += items[i].Duration;
            }
            return total;
        }

        public MediaItem[]Search(string search)
        {
            int fonud = 0;
            for ( int i = 0;i< count; i++)
            {
                if(items[i].Title.ToLower().Contains(search.ToLower()))
                {
                    fonud++;

                }
            }

            MediaItem[] results = new MediaItem[fonud];
            int index = 0;
            for(int i = 0; i < count; i++)
            {
                if(items[i].Title.ToLower().Contains(search.ToLower()))
                {
                    results[index] = items[i];
                    index++;
                }
            }
            return results;
        }

        public MediaItem this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                {
                    return items[index];
                }
                return null;
            }
        }



        public void SortByDuration()
        {
            if (count < 2) return; 



            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {

                    if (items[j].Duration > items[j + 1].Duration)//tu uporabim preoplezen operator
                    {
                        MediaItem temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                    }
                }
            }
        }

        ~Playlist()
        {
            Clear();
        }

    }
}