namespace SeminarskaOPR
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.lstPlaylist = new System.Windows.Forms.ListBox();
            this.trkVolume = new System.Windows.Forms.TrackBar();
            this.labelPlaying = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonFullScreen = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonFade = new System.Windows.Forms.Button();
            this.buttonMute = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.buttonSortLongest = new System.Windows.Forms.Button();
            this.buttonSkip = new System.Windows.Forms.Button();
            this.buttonBackward = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbVideo = new System.Windows.Forms.RadioButton();
            this.rbDuration = new System.Windows.Forms.RadioButton();
            this.rbTitle = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trkVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonPlay.Location = new System.Drawing.Point(117, 437);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(91, 45);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(222, 448);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(29, 448);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevious.TabIndex = 2;
            this.buttonPrevious.Text = "Prevoius";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // lstPlaylist
            // 
            this.lstPlaylist.FormattingEnabled = true;
            this.lstPlaylist.Location = new System.Drawing.Point(689, 71);
            this.lstPlaylist.Name = "lstPlaylist";
            this.lstPlaylist.Size = new System.Drawing.Size(268, 95);
            this.lstPlaylist.TabIndex = 4;
            this.lstPlaylist.SelectedIndexChanged += new System.EventHandler(this.lstPlaylist_SelectedIndexChanged);
            // 
            // trkVolume
            // 
            this.trkVolume.Location = new System.Drawing.Point(329, 448);
            this.trkVolume.Name = "trkVolume";
            this.trkVolume.Size = new System.Drawing.Size(315, 45);
            this.trkVolume.TabIndex = 5;
            this.trkVolume.Scroll += new System.EventHandler(this.trkVolume_Scroll);
            // 
            // labelPlaying
            // 
            this.labelPlaying.AutoSize = true;
            this.labelPlaying.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPlaying.Location = new System.Drawing.Point(457, 550);
            this.labelPlaying.Name = "labelPlaying";
            this.labelPlaying.Size = new System.Drawing.Size(122, 15);
            this.labelPlaying.TabIndex = 6;
            this.labelPlaying.Text = "Currently playing: ";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(689, 183);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(125, 515);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 8;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonFullScreen
            // 
            this.buttonFullScreen.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonFullScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonFullScreen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonFullScreen.Location = new System.Drawing.Point(993, 520);
            this.buttonFullScreen.Name = "buttonFullScreen";
            this.buttonFullScreen.Size = new System.Drawing.Size(92, 43);
            this.buttonFullScreen.TabIndex = 9;
            this.buttonFullScreen.Text = "Full Screen";
            this.buttonFullScreen.UseVisualStyleBackColor = false;
            this.buttonFullScreen.Click += new System.EventHandler(this.buttonFullScreen_Click);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Location = new System.Drawing.Point(788, 183);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(75, 23);
            this.buttonShuffle.TabIndex = 10;
            this.buttonShuffle.Text = "Shuffle";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(689, 44);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(268, 20);
            this.textSearch.TabIndex = 12;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonSearch.Location = new System.Drawing.Point(977, 41);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(92, 23);
            this.buttonSearch.TabIndex = 13;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonFade
            // 
            this.buttonFade.Location = new System.Drawing.Point(222, 503);
            this.buttonFade.Name = "buttonFade";
            this.buttonFade.Size = new System.Drawing.Size(75, 23);
            this.buttonFade.TabIndex = 14;
            this.buttonFade.Text = "Fade out";
            this.buttonFade.UseVisualStyleBackColor = true;
            this.buttonFade.Click += new System.EventHandler(this.buttonFade_Click);
            // 
            // buttonMute
            // 
            this.buttonMute.Location = new System.Drawing.Point(29, 502);
            this.buttonMute.Name = "buttonMute";
            this.buttonMute.Size = new System.Drawing.Size(75, 23);
            this.buttonMute.TabIndex = 15;
            this.buttonMute.Text = "Mute";
            this.buttonMute.UseVisualStyleBackColor = true;
            this.buttonMute.Click += new System.EventHandler(this.buttonMute_Click);
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(29, 53);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(615, 378);
            this.axWindowsMediaPlayer.TabIndex = 16;
            // 
            // buttonSortLongest
            // 
            this.buttonSortLongest.Location = new System.Drawing.Point(882, 183);
            this.buttonSortLongest.Name = "buttonSortLongest";
            this.buttonSortLongest.Size = new System.Drawing.Size(75, 23);
            this.buttonSortLongest.TabIndex = 18;
            this.buttonSortLongest.Text = "Sort";
            this.buttonSortLongest.UseVisualStyleBackColor = true;
            this.buttonSortLongest.Click += new System.EventHandler(this.buttonSortLongest_Click);
            // 
            // buttonSkip
            // 
            this.buttonSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSkip.Location = new System.Drawing.Point(650, 343);
            this.buttonSkip.Name = "buttonSkip";
            this.buttonSkip.Size = new System.Drawing.Size(75, 23);
            this.buttonSkip.TabIndex = 19;
            this.buttonSkip.Text = "+10";
            this.buttonSkip.UseVisualStyleBackColor = true;
            this.buttonSkip.Click += new System.EventHandler(this.buttonSkip_Click);
            // 
            // buttonBackward
            // 
            this.buttonBackward.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBackward.Location = new System.Drawing.Point(650, 381);
            this.buttonBackward.Name = "buttonBackward";
            this.buttonBackward.Size = new System.Drawing.Size(75, 23);
            this.buttonBackward.TabIndex = 20;
            this.buttonBackward.Text = "-10";
            this.buttonBackward.UseVisualStyleBackColor = true;
            this.buttonBackward.Click += new System.EventHandler(this.buttonBackward_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbVideo);
            this.groupBox1.Controls.Add(this.rbDuration);
            this.groupBox1.Controls.Add(this.rbTitle);
            this.groupBox1.Location = new System.Drawing.Point(981, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(88, 100);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Izberi";
            // 
            // rbVideo
            // 
            this.rbVideo.AutoSize = true;
            this.rbVideo.Location = new System.Drawing.Point(7, 66);
            this.rbVideo.Name = "rbVideo";
            this.rbVideo.Size = new System.Drawing.Size(52, 17);
            this.rbVideo.TabIndex = 2;
            this.rbVideo.TabStop = true;
            this.rbVideo.Text = "Video";
            this.rbVideo.UseVisualStyleBackColor = true;
            // 
            // rbDuration
            // 
            this.rbDuration.AutoSize = true;
            this.rbDuration.Location = new System.Drawing.Point(7, 42);
            this.rbDuration.Name = "rbDuration";
            this.rbDuration.Size = new System.Drawing.Size(65, 17);
            this.rbDuration.TabIndex = 1;
            this.rbDuration.TabStop = true;
            this.rbDuration.Text = "Duration";
            this.rbDuration.UseVisualStyleBackColor = true;
            // 
            // rbTitle
            // 
            this.rbTitle.AutoSize = true;
            this.rbTitle.Location = new System.Drawing.Point(7, 20);
            this.rbTitle.Name = "rbTitle";
            this.rbTitle.Size = new System.Drawing.Size(45, 17);
            this.rbTitle.TabIndex = 0;
            this.rbTitle.TabStop = true;
            this.rbTitle.Text = "Title";
            this.rbTitle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Media Player";
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 575);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonBackward);
            this.Controls.Add(this.buttonSkip);
            this.Controls.Add(this.buttonSortLongest);
            this.Controls.Add(this.axWindowsMediaPlayer);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonMute);
            this.Controls.Add(this.buttonFade);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.buttonShuffle);
            this.Controls.Add(this.buttonFullScreen);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelPlaying);
            this.Controls.Add(this.trkVolume);
            this.Controls.Add(this.lstPlaylist);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPlay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trkVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        //private AxWMPLib.AxWindowsMediaPlayer axPlayer;
        private System.Windows.Forms.ListBox lstPlaylist;
        private System.Windows.Forms.TrackBar trkVolume;
        private System.Windows.Forms.Label labelPlaying;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonFullScreen;
        private System.Windows.Forms.Button buttonShuffle;
        //private AxWMPLib.AxWindowsMediaPlayer axMediaPlayer;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonFade;
        private System.Windows.Forms.Button buttonMute;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.Button buttonSortLongest;
        private System.Windows.Forms.Button buttonSkip;
        private System.Windows.Forms.Button buttonBackward;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbVideo;
        private System.Windows.Forms.RadioButton rbDuration;
        private System.Windows.Forms.RadioButton rbTitle;
        private System.Windows.Forms.Label label1;
    }
}

