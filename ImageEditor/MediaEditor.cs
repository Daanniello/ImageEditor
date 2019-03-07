using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    class MediaEditor
    {
        private MediaPorter _mediaPorter;

        private Image _media;
        public int FrameIndex;
        public List<Image> Frames;

        public MediaEditor()
        {
            _mediaPorter = new MediaPorter();
        }

        public bool OpenMedia(OpenFileDialog openMediaDialog)
        {
            _media = _mediaPorter.OpenMedia(openMediaDialog);

            if (_media == null) return false;

            try
            {
                Frames = MediaToFrames(_media);
            }
            catch (Exception ex)
            {
                Frames = new List<Image>();
                Frames.Add(_media);
            }

            FrameIndex = 0;

            return true;
        }

        public bool ExportMedia(FolderBrowserDialog folderSelectDialog)
        {
            return _mediaPorter.ExportMedia(folderSelectDialog, _media);
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

            Image currentFrame = Frames[FrameIndex]; ;

            currentFrame = filter.ApplyFilter(currentFrame);

            Frames[FrameIndex] = currentFrame;

            return true;
        }
    }
}
