using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    class MediaEditor
    {
        public Media Media;

        private IMediaPorter _porter;
        private MainView _view;

        public MediaEditor(MainView view)
        {
            _view = view;
        }

        private IMediaPorter MakePorter(string type)
        {
            switch (type)
            {
                case ".gif":
                    return new GifMediaPorter();
                case ".png":
                    return new PngMediaPorter();
                default:
                    throw new InvalidOperationException();
            }
        }

        public bool OpenMedia(OpenFileDialog openMediaDialog)
        {
            openMediaDialog.Filter = "Image Files (PNG,GIF)|*.PNG;*.GIF";
            DialogResult result = openMediaDialog.ShowDialog();
            if (result != DialogResult.OK) return false;

            string extension = Path.GetExtension(openMediaDialog.FileName);
            _porter = MakePorter(extension);

            // Fill Media object
            Media = new Media();
            Media.File = Image.FromFile(openMediaDialog.FileName);
            Media.Frames = _porter.MediaToFrames(Media.File);
            Media.Extension = extension;
            Media.FrameIndex = 0;
            Media.SelectedFrames = new List<int>(new int[]{ 0 });

            return true;
        }

        public bool ExportMedia(FolderBrowserDialog folderSelectDialog)
        {
            return _porter.ExportMedia(folderSelectDialog, Media.Frames);
        }
        
        public bool ApplyFilter(string type)
        {
            Filter filter = Filter.MakeFilter(type);
            if (filter == null) return false;

            List<Image> frames = Media.GetSelectedFrames();
            Queue<Image> updatedFrames = filter.ApplyFilterOnFrames(frames);
            return Media.SetSelectedFrames(updatedFrames);
        }
    }
}
