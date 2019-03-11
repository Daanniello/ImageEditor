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

            if (_mediaEditor.Media.Frames == null) return;

            UpdateMedia();
            UpdateTimeline();
        }

        private void UpdateMedia()
        {
            pictureBox1.Image = _mediaEditor.Media.Frames[_mediaEditor.Media.FrameIndex];
        }

        private void UpdateTimeline()
        {
            List<Image> mediaFrames = _mediaEditor.Media.Frames;

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
            _mediaEditor.ExportMedia(folderBrowserDialog1);
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
            if (_mediaEditor.Media.Frames == null) return;

            if (_mediaEditor.ApplyFilter(type))
            {
                UpdateMedia();
                UpdateTimeline();
            };
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            _mediaEditor.Media.SelectedFrames = new List<int>();

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                _mediaEditor.Media.SelectedFrames.Add(item.Index);
            }

            _mediaEditor.Media.FrameIndex = listView1.SelectedItems[0].Index;

            UpdateMedia();
        }
    }
}
