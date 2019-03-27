using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class MainView : Form
    {
        private MediaEditor _mediaEditor;

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

        private void removeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {                 
            ApplyFilter("RemoveColor");
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            var color = new Color();
            Bitmap b = pictureBox1.Image as Bitmap;

            pictureBox1.MouseMove += PictureBoxMouseMove;
            pictureBox1.Click += PictureBoxClick;

            void PictureBoxMouseMove(object sender1, MouseEventArgs e1)
            {
                var pixel = b.GetPixel(e1.X, e1.Y);
                colorPickerButton.BackColor = pixel;
                color = pixel;
            }

            void PictureBoxClick(object sender2, EventArgs e2)
            {
                colorPickerButton.BackColor = color;
                pictureBox1.MouseMove -= PictureBoxMouseMove;
            }
        }
    }
}
