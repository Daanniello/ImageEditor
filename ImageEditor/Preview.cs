using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class Preview : Form
    {
        private List<Image> frames;
        private List<Image> copyFrames;
        private int delay;

        public Preview(List<Image> Frames, int Delay = 1000)
        {
            InitializeComponent();
            frames = Frames;
            copyFrames = new List<Image>();
            MakeFramesStatic();

            delay = Delay;
        }

        private void MakeFramesStatic()
        {
            copyFrames = new List<Image>();
            foreach (var frame in frames)
            {
                copyFrames.Add((Image)frame.Clone());
            }
        }

        private async void Preview_Load(object sender, EventArgs e)
        {
            await loop();
        }

        private async Task loop()
        {
            var count = 0;
            while (true)
            {               
                try
                {
                    if (count >= copyFrames.Count)
                    {
                        count = 0;
                    }

                    var image = copyFrames[count];

                    pictureBox1.Image = image;

                    await Task.Delay(delay);
             
                }
                catch
                {
                    await Task.Delay(5000);
                    //count -= 2;

                }
                
                
                count++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MakeFramesStatic();
        }
    }
}
