using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class MainView : Form
    {
        private MediaEditor _mediaEditor;

        public MainView()
        {
            InitializeComponent();
            _mediaEditor = new MediaEditor();
            
        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked on open");
            _mediaEditor.OpenMedia(openFileDialog1);

            if (_mediaEditor.Media == null) return;

            UpdateMedia();
            UpdateTimeline(_mediaEditor.GetMediaFrames());
        }

        private void UpdateMedia()
        {
            pictureBox1.Image = _mediaEditor.Media;
        }

        private void UpdateTimeline(List<Image> mediaFrames)
        {
            Console.WriteLine("Update Timeline");
            var mediaList = new ImageList();
            mediaList.ImageSize = new Size(96, 96);
            listView1.Clear();
            listView1.LargeImageList = mediaList;
            

            for (var x = 0; x < mediaFrames.Count; x++)
            {
                mediaList.Images.Add(mediaFrames[x]);

            }
            for (var x = 0; x < mediaFrames.Count; x++)
            {
                var item = new ListViewItem();
                item.ImageIndex = x;
                item.Text = x.ToString();
                listView1.Items.Add(item);

            }

            //foreach (var frame in mediaFrames)
            //{
            //    mediaList.Images.Add(frame);
            //    var listViewItem = new ListViewItem();
            //    listViewItem.ad

            //    listView1.Items.Add(frame);
            //}
            //listView1.LargeImageList = mediaList;
            //listView1.



            //panel1.Controls.Add();
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
            if (_mediaEditor.Media == null) return;

            if (_mediaEditor.ApplyFilter(type))
            {
                UpdateMedia();
                UpdateTimeline(_mediaEditor.GetMediaFrames());
            };
        }
    }
}
