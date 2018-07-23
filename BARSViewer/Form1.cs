using System;
using System.IO;
using System.Linq.Expressions;
using System.Threading;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace BARSViewer
{
    public partial class Form1 : Form
    {
        public BMETA Bmta = new BMETA();
        private string path = "";
        private WaveFileReader reader;
        private bool init = false;
        WaveOutEvent waveOut = new WaveOutEvent();
        private Thread trackbarUpdater;

        public Form1()
        {
            InitializeComponent();
            waveOut.PlaybackStopped += new EventHandler<StoppedEventArgs>(onPlaybackFinished);
            trackbarUpdater = new Thread(() => updateTrackbar(waveOut, reader, trackBar1));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bmta = new BMETA();
            openFileDialog1.ShowDialog();
            path = Path.GetDirectoryName(openFileDialog1.FileName);
            if (openFileDialog1.FileName == "") return;
            else Bmta.load(openFileDialog1.FileName);

            listBox1.Items.Clear();
            extractButton.Enabled = true;
            extractWavButton.Enabled = true;

            for (int i = 0; i < Bmta.strgList.Count; i++)
            {
                listBox1.Items.Add(new string(Bmta.strgList[i].fwavName));
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            Bmta.unpack(openFileDialog1.FileName.Replace(".bars", ""));
            MessageBox.Show("Done.");
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BARS Viewer 0.1 by MasterF0x and Sam Poulton", "About");
        }

        private void ExtractWavButton_Click(object sender, EventArgs e)
        {
            Bmta.unpackWav(openFileDialog1.FileName.Replace(".bars", ""));
            MessageBox.Show("Converted all compatible formats.");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename = "";
            try
            {
                foreach (BMETA.STRG strg in Bmta.strgList)
                {
                    if (listBox1.SelectedItem.ToString().Contains(strg.name))
                    {
                        filename = strg.name;
                        break;
                    }
                }
                Stream audio = Bmta.unpackWavStream(filename);
                audio.Position = 0;
                reader = new WaveFileReader(audio);
                lengthLabel.Text = reader.TotalTime.ToString();
                waveOut.Init(reader);
                init = true;
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (init)
            {
                waveOut.Play();
                // trackbarUpdater.Start();
                updateTrackbar(waveOut,reader,trackBar1);
            }

        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (init)
            {
                waveOut.Pause();
            }
        }

        private void onPlaybackFinished(object sender, StoppedEventArgs e)
        {
            reader.Position = 0;
            updateTrackbar(waveOut, reader, trackBar1);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (init)
            {
                waveOut.Stop();
                reader.Position = trackBar1.Value;
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Play();
                } 
            }
        }

        private static void updateTrackbar(WaveOutEvent waveOut, WaveFileReader reader, TrackBar trackBar)
        {
            do
            {
                try
                {
                    trackBar.Value = (int) ((waveOut.GetPosition() / reader.Length) * 1000);
                }
                catch (ArgumentOutOfRangeException)
                {
                    trackBar.Value = trackBar.Maximum;
                }
            } while (waveOut.PlaybackState == PlaybackState.Playing);
        }
    }
}
