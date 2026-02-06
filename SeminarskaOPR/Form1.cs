using AxWMPLib;
using MediaPlayer.Core;
using System;
using System.Windows.Forms;
using WMPLib;
using static MediaPlayer.Core.MediaItem;

namespace SeminarskaOPR
{
    public partial class Form1 : Form, IVolumeControl
    {
        private Playlist playlist;
        private PlayerStats stats;
        private MediaItem[] trenutnoPrikazani;

        private bool isMuted = false;
        private int lastVolume = 50;
            
        public int CurrentVolume
        {
            get {return axWindowsMediaPlayer.settings.volume;}
            set { axWindowsMediaPlayer.settings.volume = value; }
        }
        public void Mute()
        {
            if (!isMuted)
            {
                lastVolume = CurrentVolume;
                CurrentVolume = 0;

                isMuted = true;
            }
            else
            {
                CurrentVolume = lastVolume;
                isMuted = false;
            }
        }

        public async void FadeOut(int steps, int intervalMs)
        {
            if (steps <= 0) return;
            int decrement = CurrentVolume / steps;
            for (int i = 0; i < steps; i++)
            {
                int newVal = CurrentVolume - decrement;
                CurrentVolume = (newVal < 0) ? 0 : newVal;
                await System.Threading.Tasks.Task.Delay(intervalMs);
            }
            axWindowsMediaPlayer.Ctlcontrols.stop();
        }

        public Form1()
        {
            InitializeComponent();

            playlist = new Playlist();
            stats = new PlayerStats();

            if (trkVolume != null)
            {
                trkVolume.Minimum = 0;
                trkVolume.Maximum = 100;
                trkVolume.Value = 50;

                if (axWindowsMediaPlayer != null && axWindowsMediaPlayer.settings != null)
                {
                    axWindowsMediaPlayer.settings.volume = trkVolume.Value;
                    axWindowsMediaPlayer.uiMode = "none";
                }
            }

            if (axWindowsMediaPlayer != null)
            {
                try
                {
                    axWindowsMediaPlayer.PlayStateChange += axMediaPlayer_PlayStateChange;
                    axWindowsMediaPlayer.uiMode = "none";
                    if (axWindowsMediaPlayer.settings != null && trkVolume != null)
                    {
                        axWindowsMediaPlayer.settings.volume = trkVolume.Value;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Napaka pri inicializaciji predvajalnika: " + ex.Message);
                }
            }
            //buttonPrevious.Click += buttonPrevious_Click;
            //buttonNext.Click += buttonNext_Click;

            if (buttonFullScreen != null)
            {
                buttonFullScreen.Enabled = false;
            }
        }

        private void axMediaPlayer_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                this.BeginInvoke(new Action(() => {

                    if (lstPlaylist.SelectedIndex != -1)
                    {
                        buttonNext_Click(null, null);
                    }
                }));
            }
        }

        private void PlaySelectedItem()
        {
            if (lstPlaylist.SelectedIndex < 0) return;

            MediaItem item = trenutnoPrikazani[lstPlaylist.SelectedIndex];//playa se trenutno prkazani

            axWindowsMediaPlayer.Ctlcontrols.stop();

            axWindowsMediaPlayer.URL = item.FilePath;
            buttonFullScreen.Enabled = (item is VideoItem);
            axWindowsMediaPlayer.uiMode = "none";

            axWindowsMediaPlayer.Ctlcontrols.play();

            stats.Increment();
            labelPlaying.Text = $"Currently playing: {item.GetInfo()}";
            CurrentVolume = 100;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            PlaySelectedItem();

        }

        private void buttonPause_Click(object sender, EventArgs e) 
        {
            axWindowsMediaPlayer.Ctlcontrols.pause();


        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (lstPlaylist.Items.Count > 0)
            {
                if (lstPlaylist.SelectedIndex > 0)
                {
                    lstPlaylist.SelectedIndex = lstPlaylist.SelectedIndex - 1;
                }
                else
                {
                    lstPlaylist.SelectedIndex = lstPlaylist.Items.Count - 1;
                }
                PlaySelectedItem();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (lstPlaylist.Items.Count > 0)
            {
                if (lstPlaylist.SelectedIndex < lstPlaylist.Items.Count - 1)
                {
                    lstPlaylist.SelectedIndex = lstPlaylist.SelectedIndex + 1;
                }
                else
                {
                    lstPlaylist.SelectedIndex = 0;
                }
                PlaySelectedItem();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Media files|*.mp3;*.wav;*.mp4;*.avi" };//pokaze samo video in audio tipe datotek

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(ofd.FileName).ToLower();
                if (PlayerConfig.IsSupported(ext))
                {
                    MediaItem item;

                    if (ext == ".mp3" || ext == ".wav")
                    {
                        item = new AudioItem(ofd.FileName);
                        
                    }
                    else
                    {
                        item = new VideoItem(ofd.FileName);
                        
                    }

                    bool uspeh = playlist.Add(item);
                    Random r = new Random();
                    item.Duration = TimeSpan.FromMinutes(r.Next(1, 10));

                    if (uspeh == true)
                    {
                        lstPlaylist.Items.Add(item.Title);
                    }
                    else
                    {
                        MessageBox.Show("Ta datoteka je že na seznamu", "Error", MessageBoxButtons.OKCancel);
                    }
                }
                
            }

        }


        private void trkVolume_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.settings.volume = trkVolume.Value;
        }

        private void lstPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPlaylist.SelectedIndex >= 0)
            {
                MediaItem item = playlist.GetAt(lstPlaylist.SelectedIndex);
                labelPlaying.Text = $"Currently Playing: {item.GetInfo()}";
            }
        }

        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                try
                {

                    axWindowsMediaPlayer.fullScreen = true;
                }
                catch (Exception ex)

                {
                    MessageBox.Show("ni mogoce prikazati v full screen: " + ex.Message);
                }
            }
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            playlist.Shuffle();

            
            lstPlaylist.Items.Clear();
            foreach (var item in playlist.Items)
            {
                lstPlaylist.Items.Add(item.Title);
            }
        }

        private void buttonFade_Click(object sender, EventArgs e)
        {
            this.FadeOut(10, 100);
        }

        private void buttonMute_Click(object sender, EventArgs e)
        {
            this.Mute();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string iskaniNiz = textSearch.Text;

            if (string.IsNullOrWhiteSpace(iskaniNiz))
            {
                OsveziPrikaz(playlist.Items);
                return;
            }

            MediaItem[] rezultati = playlist.Search(iskaniNiz);

            OsveziPrikaz(rezultati);
        }
        private void OsveziPrikaz(MediaItem[] items)
        {
            lstPlaylist.Items.Clear();
            trenutnoPrikazani = items; 

            foreach (var item in items)
            {
                lstPlaylist.Items.Add(item.Title);
            }

            if (lstPlaylist.Items.Count == 0)
            {
                labelPlaying.Text = "Ni zadetkov";
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text == "")
            {
                OsveziPrikaz(playlist.Items);
            }
        }

        private void buttonSortLongest_Click(object sender, EventArgs e)
        {
            playlist.SortByDuration();
            OsveziPrikaz(playlist.Items);
        }
    }
}