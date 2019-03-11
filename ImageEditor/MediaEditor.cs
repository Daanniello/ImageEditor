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
        private MediaPorter _mediaPorter;
        public Media Media;
       
        

        public MediaEditor()
        {
            Media = new Media();
            _mediaPorter = new MediaPorter();
        }

        public bool OpenMedia(OpenFileDialog openMediaDialog)
        {           
            Media.File = _mediaPorter.OpenMedia(openMediaDialog);
            Media.Extension = Path.GetExtension(openMediaDialog.FileName);
            if (Media == null) return false;

            if (Media.Extension == ".gif")
            {
                Media.Frames = MediaToFrames(Media.File);
            }
            else
            {
                Media.Frames = new List<Image>();
                Media.Frames.Add(Media.File);
            }

            Media.FrameIndex = 0;

            return true;
        }

        public bool ExportMedia(FolderBrowserDialog folderSelectDialog)
        {
            if (Media.Extension == ".gif")
            {
                return _mediaPorter.ExportMedia(folderSelectDialog, Media.File, Media.Extension, Media.Frames);
            }
            return _mediaPorter.ExportMedia(folderSelectDialog, Media.File);
        }

        public List<Image> MediaToFrames(Image media)
        {
            List<Image> frames = new List<Image>();
            int length = media.GetFrameCount(FrameDimension.Time);

            for (int i = 0; i < length; i++)
            {
                media.SelectActiveFrame(FrameDimension.Time, i);
                frames.Add(new Bitmap(media));
            }

            return frames;
        }

        public bool ApplyFilter(string type)
        {
            Filter filter = Filter.MakeFilter(type);

            if (filter == null) return false;

            foreach (int index in Media.SelectedFrames)
            {
                Media.Frames[index] = filter.ApplyFilter(Media.Frames[index]);
            }

            return true;
        }
    }
}
