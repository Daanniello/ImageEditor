using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class MainView : Form
    {
        private MediaEditor _mediaEditor;
        private float _scaleFactor, _scaledWidth, _scaledHeight, _filler;

        public MainView()
        {
            InitializeComponent();
            _mediaEditor = new MediaEditor(this);
            
        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked on open");
            _mediaEditor.OpenMedia(openFileDialog1);

            if (_mediaEditor.MediaInformation.Frames == null) return;

            UpdateMedia();
            UpdateTimeline();
        }

        private void UpdateMedia()
        {
            pictureBox1.Image = _mediaEditor.MediaInformation.Frames[_mediaEditor.MediaInformation.FrameIndex];
        }

        private void UpdateTimeline()
        {
            List<Image> mediaFrames = _mediaEditor.MediaInformation.Frames;

            var mediaList = new ImageList();
            mediaList.ImageSize = new Size(96, 96);
            listView1.Clear();
            listView1.LargeImageList = mediaList;
            

            for (var x = 0; x < mediaFrames.Count; x++)
            {
                Image image = mediaFrames[x];
                mediaList.Images.Add(mediaFrames[x]);

            }
            for (var x = 0; x < mediaFrames.Count; x++)
            {
                var item = new ListViewItem();
                item.ImageIndex = x;
                item.Text = x.ToString();
                listView1.Items.Add(item);
            }
        }

        private void exportToolStripMenuItem_click(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked on export");
            _mediaEditor.ExportMedia(saveFileDialog1);
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter("Grayscale");
        }

        private void invertedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter("Inverted");
        }

        private void randomizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter("Randomized");
        }

        private void ApplyFilter(string type)
        {
            if (_mediaEditor.MediaInformation.Frames == null) return;

            if (_mediaEditor.ApplyFilter(type))
            {
                UpdateMedia();
                UpdateTimeline();
            };
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            _mediaEditor.MediaInformation.SelectedFrames = new List<int>();

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                _mediaEditor.MediaInformation.SelectedFrames.Add(item.Index);
            }

            _mediaEditor.MediaInformation.FrameIndex = listView1.SelectedItems[0].Index;

            UpdateMedia();
        }

        private bool useTool = false;
        private Point? _Previous = null;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            useTool = true;
            _Previous = e.Location;
            Point p = e.Location;
            //_mediaEditor.SaveImagestatus()
            //pictureBox1.Image = _mediaEditor.UseTool(p.X, p.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Previous != null)
            {
                Point p = e.Location;
                var image = pictureBox1.Image;
                _mediaEditor.UseTool(_Previous.Value, p.X, p.Y, ref image);
            }
            if(useTool)
                _Previous = e.Location;

            pictureBox1.Invalidate();
            //if (useTool)
            //{
            //    Point p = e.Location;
            //    //_mediaEditor.SaveImagestatus()
            //    pictureBox1.Image = _mediaEditor.UseTool(p.X, p.Y);
            //}
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Update actual image
            _Previous = null;
            useTool = false;
        }

        private void pencilButton_Click(object sender, EventArgs e)
        {
            var tool = new Pencil();
            _mediaEditor.SetTool(tool);
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            var tool = new Eraser();
            _mediaEditor.SetTool(tool);
        }

        private void sprayCanButton_Click(object sender, EventArgs e)
        {
            var tool = new SprayCan();
            _mediaEditor.SetTool(tool);
        }

        private void CheckRatio()
        {
            int w_i = pictureBox1.Image.Width;
            int h_i = pictureBox1.Image.Height;
            int w_c = pictureBox1.Width;
            int h_c = pictureBox1.Height;

            float imageRatio = w_i / (float)h_i; // image W:H ratio
            float containerRatio = w_c / (float)h_c; // container W:H ratio

            if (imageRatio >= containerRatio)
            {
                // horizontal image
                _scaleFactor = w_c / (float)w_i;
                _scaledHeight = h_i * _scaleFactor;
                // calculate gap between top of container and top of image
                _filler = Math.Abs(h_c - _scaledHeight) / 2;
                //unscaled_p.X = (int)(p.X / scaleFactor);
                //unscaled_p.Y = (int)((p.Y - filler) / scaleFactor);
            }
            else
            {
                // vertical image
                _scaleFactor = h_c / (float)h_i;
                _scaledWidth = w_i * _scaleFactor;
                _filler = Math.Abs(w_c - _scaledWidth) / 2;
                //unscaled_p.X = (int)((p.X - filler) / scaleFactor);
                //unscaled_p.Y = (int)(p.Y / scaleFactor);
            }
        }

        //private void test()
        //{
        //    Bitmap bmp = new Bitmap(pictureBox1.Image);
        //    using (Graphics g = Graphics.FromImage(bmp))
        //    {
        //        g.DrawImage(new Bitmap((@"C:\Users\Mena\Desktop\1.png"), new Point(182, 213));
        //    }
        //    pictureBox1.Image = bmp;
        //}
    }
}
