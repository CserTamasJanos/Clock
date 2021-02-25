using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F012Beta
{
   public partial class FormF012 : Form
    {
        private SenderFlashStatus aConcreteButton;

        public FormF012()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AnalogClock analogClockObserver = new AnalogClock();
            DigitalClock digitalClockObserver = new DigitalClock();

            aConcreteButton = new SenderFlashStatus();

            aConcreteButton.AttachAClock(analogClockObserver);
            aConcreteButton.AttachAClock(digitalClockObserver);

            analogClockObserver.TimerTickEvent += DrawClockPlease;
            digitalClockObserver.TimerTickEvent += DrawDigitalClock;

        }

        private void DrawClockPlease(Bitmap analogClockBitmap)
        {
            pictureBoxAnalogClock.Image = analogClockBitmap;
        }

        private void DrawDigitalClock(Bitmap digitalClockBitmap)
        {
            pictureBoxDigitalClock.Image = digitalClockBitmap;
        }

        private void buttonFlash_Click(object sender, EventArgs e)
        {
            aConcreteButton.Flash = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
