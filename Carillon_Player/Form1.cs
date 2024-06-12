using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.DirectX.DirectSound;

using com.olab_it;

namespace Carillon_Player
{
    public partial class Form1 : Form
    {
        public Form1(bool autoStart = true)
        {
            InitializeComponent();
            player = new CarillonPlayer();
            player.TimerElapsed += new EventHandler(player_TimerElapsed);
            timer1.Start();
            AutoStart = autoStart;
            Application.DoEvents();
        }

        bool baloonTipVisible = false,
            AutoStart;
        CarillonPlayer player;

        void player_TimerElapsed(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(500);
                baloonTipVisible = true;
                this.Hide();
            }
            else
            {
                this.notifyIcon1.Visible = false;
            }
            Application.DoEvents();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!player.Running)
                player.Start(this.Handle);
            UpdateUI();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            player.Stop();
            UpdateUI();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(AutoStart && this.Visible)
            {
                if (!player.Running)
                    player.Start(this.Handle);
                AutoStart = false;
                this.WindowState = FormWindowState.Minimized;
            }
            UpdateUI();
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!baloonTipVisible)
            {
                TimeSpan span = player.TimeUntilNextPlay;
                notifyIcon1.BalloonTipText = player.Running ? string.Format("Next Play {0} hours, {1} minutes, {2} seconds", span.Hours, span.Minutes, span.Seconds) : "Not running";
                this.notifyIcon1.ShowBalloonTip(100);
                baloonTipVisible = true;
            }
        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            baloonTipVisible = false;
        }

        private void UpdateUI()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.UpdateUI));
            }
            else
            {
                TimeSpan span = player.TimeUntilNextPlay;
                this.lblNextPlayTime.Text = player.Running ? string.Format("{0} hours, {1} minutes, {2} seconds", span.Hours, span.Minutes, span.Seconds) : "Not running";
                notifyIcon1.BalloonTipText = player.Running ? string.Format("Next Play {0} hours, {1} minutes, {2} seconds", span.Hours, span.Minutes, span.Seconds) : "Not running";
                this.lblPlayList.Text = player.Running ? player.ActivePlayList : "";
                this.lblWaveInfo.Text = player.Running ? player.WaveDescription : "";
                this.panel1.BackgroundImage = player.Running ? player.IsPlaying ? global::Carillon_Player.Properties.Resources.Red_Dot_32 :
                    global::Carillon_Player.Properties.Resources.Green_Dot_32 :
                    global::Carillon_Player.Properties.Resources.Aqua_Dot_32;
                Application.DoEvents();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Stop();
            player.Dispose();
            timer1.Stop();
        }

    }
}
