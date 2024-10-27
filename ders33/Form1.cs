using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ders33
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Visible = false;
            listBox1.Visible = false;
            listBox2.Visible = false;
            trackBar1.Value = 50;
            button7.Visible = false;
            this.Size = new Size(1023, 182);
            button2.Enabled = false;
            button3.Enabled = false;    
            button4.Enabled = false;
            button5.Enabled = false;    
            button6.Enabled = false;
            button7.Enabled = false;
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            for (int i=0; i < openFileDialog1.SafeFileNames.Length;i++)
            {

                listBox1.Items.Add(openFileDialog1.SafeFileNames[i].ToString());
                listBox2.Items.Add(openFileDialog1.FileNames[i].ToString());

            }
            button2.Enabled=true;
            button3.Enabled=true;   
            button4.Enabled=true;
            button5.Enabled=true;
            button6.Enabled=true;
            button7.Enabled=true;
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex=listBox1.SelectedIndex;
            axWindowsMediaPlayer1.URL = listBox2.SelectedItem.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
 
        private void button2_Click(object sender, EventArgs e)
        {
           
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                }
                else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused || axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    
                }
           
          


        }
        
        private void button4_Click(object sender, EventArgs e)
        {


            axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume + 5;
            trackBar1.Value = trackBar1.Value + 5;


            if (trackBar1.Value >= 100) { trackBar1.Value = 100; button4.Enabled = false; }
            if(trackBar1.Value>5)
            button5.Enabled = true;
          


        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
            axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume - 5;
            trackBar1.Value = trackBar1.Value - 5;
            if (trackBar1.Value == 0) { button5.Enabled = false; }
            if (trackBar1.Value < 100)
                button4.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume=trackBar1.Value;
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button7.Visible = true;
            button6.Location = new Point(536,12);
            button6.Size = new Size(84,28);
            button6.Text = "Forward";
            button8.Size = new Size(230,28);
            button8.Location = new Point(536, 74);
            this.Size = new Size(800,182);

            try { 
            axWindowsMediaPlayer1.Ctlcontrols.next();
            listBox2.SelectedIndex=listBox2.SelectedIndex+1;
            listBox1.SelectedIndex=listBox2.SelectedIndex;
            axWindowsMediaPlayer1.URL=listBox2.Text;
            }
            catch (Exception )
            {
                MessageBox.Show("Not enough music selected to switch");
            }
        }
        

        private void button7_Click(object sender, EventArgs e)
        {
            try { 
            listBox2.SelectedIndex = listBox2.SelectedIndex - 1;
            listBox1.SelectedIndex = listBox2.SelectedIndex ;
            axWindowsMediaPlayer1.URL = listBox2.Text;
            }
            catch (Exception )
            {
                MessageBox.Show("Not enough music selected to switch");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
