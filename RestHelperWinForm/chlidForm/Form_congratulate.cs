using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace RestHelperUI.chlidForm
{
    public partial class Form_congratulate : Form
    {
        private int max = 1;
        public Form_congratulate()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Form_congratulate_Load(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("congratu"));
            simpleSound.Play();

            timer1.Interval = 2000;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            max--;
            if(max<0)
            {
                this.Dispose();
            }
        }
    }
}
