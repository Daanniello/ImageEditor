using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class MainView : Form
    {
        private MediaEditor _mediaEditor;
        private float _scaleFactor, _filler;
        private float _scaledWidth = 1.0f;
        private float _scaledHeight = 1.0f;

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

            if (_mediaEditor.MediaInformation.Frames.Count == 0) return;

            UpdateMedia();
            InitializeTimeLine();
            //CheckRatio();
        }

        private void UpdateMedia()
        {
            pictureBox1.Image = _mediaEditor.MediaInformation.Frames[_mediaEditor.MediaInformation.FrameIndex];
        }

        private void InitializeTimeLine()
        {
            List<Image> mediaFrames = _mediaEditor.MediaInformation.Frames;

            var mediaList = new ImageList();
            mediaList.ImageSize = new Size(96, 96);
            listView1.Clear();

            for (var x = 0; x < mediaFrames.Count; x++)
            {
                Image image = mediaFrames[x];
                mediaList.Images.Add(mediaFrames[x]);

            }
            listView1.LargeImageList = mediaList;

            for (var x = 0; x < mediaFrames.Count; x++)
            {
                var item = new ListViewItem();
                item.ImageIndex = x;
                item.Text = x.ToString();
                listView1.Items.Add(item);
            }
        }

        private void updateTimeLine()
        {
            List<Image> mediaFrames = _mediaEditor.MediaInformation.Frames;

            var mediaList = new ImageList();
            mediaList.ImageSize = new Size(96, 96);

            for (var x = 0; x < mediaFrames.Count; x++)
            {
                Image image = mediaFrames[x];
                mediaList.Images.Add(mediaFrames[x]);

            }

            listView1.LargeImageList = mediaList;
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

        private void cycledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter("Cycled");
        }

        private void ApplyFilter(string type)
        {
            // Check if the frames exist
            if (_mediaEditor.MediaInformation.Frames == null) return;

            // Gets the selected frames which should get a filter applied
            List<int> selectedFrameIndexes = new List<int>();
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                selectedFrameIndexes.Add(item.Index);
            }
            if (selectedFrameIndexes.Count < 1) return;

            // Apply the filter and update the UI
            if (_mediaEditor.ApplyFilter(type, selectedFrameIndexes))
            {
                UpdateMedia();
                updateTimeLine();
            };
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            _mediaEditor.MediaInformation.FrameIndex = listView1.SelectedItems[0].Index;
            UpdateMedia();
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            colorButton.BackColor = colorDialog1.Color;

        }

        private void removeFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mediaEditor.MediaInformation.Frames.RemoveAt(listView1.SelectedItems[0].Index);
            InitializeTimeLine();
        }

        private void addBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = listView1.SelectedItems[0].Index;
            _mediaEditor.MediaInformation.Frames.Insert(index + 1, new Bitmap(_mediaEditor.MediaInformation.Frames[index]));
            InitializeTimeLine();
        }

        private bool useTool = false;
        private Point _previous;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            useTool = true;
            _previous = e.Location;
            //_mediaEditor.SaveImagestatus()
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (useTool)
            {
                Point curr = e.Location;
                if (horizontal)
                {
                    _previous.X = (int)(_previous.X / _scaleFactor);
                    _previous.Y = (int)((_previous.Y - _filler) / _scaleFactor);
                    curr.X = (int)(curr.X / _scaleFactor);
                    curr.Y = (int)((curr.Y - _filler) / _scaleFactor);
                }
                else if (!horizontal)
                {
                    _previous.X = (int)((_previous.X - _filler) / _scaleFactor);
                    _previous.Y = (int)(_previous.Y / _scaleFactor);
                    curr.X = (int)((curr.X - _filler) / _scaleFactor);
                    curr.Y = (int)(curr.Y / _scaleFactor);
                }

                var image = pictureBox1.Image;
                _mediaEditor.UseTool(_previous, curr, ref image);

                pictureBox1.Invalidate();
                _previous = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Update actual image
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
        bool horizontal = true;
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
                horizontal = true;
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
                horizontal = false;
                _scaleFactor = h_c / (float)h_i;
                _scaledWidth = w_i * _scaleFactor;
                _filler = Math.Abs(w_c - _scaledWidth) / 2;
                //unscaled_p.X = (int)((p.X - filler) / scaleFactor);
                //unscaled_p.Y = (int)(p.Y / scaleFactor);
            }
        }
    }
}
