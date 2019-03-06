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
        public Image Media;

        public MediaEditor()
        {
            _mediaPorter = new MediaPorter();
        }

        public bool OpenMedia(OpenFileDialog openMediaDialog)
        {
            Media = _mediaPorter.OpenMedia(openMediaDialog);
            if (Media != null) return true;
            return false;
        }

        public bool ExportMedia(FolderBrowserDialog folderSelectDialog)
        {
            return _mediaPorter.ExportMedia(folderSelectDialog, Media);
        }

        public List<Image> GetMediaFrames()
        {
            int numberOfFrames = 1;

            try
            {
                numberOfFrames = Media.GetFrameCount(FrameDimension.Time);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
 
            List<Image> frames = new List<Image>();

            for (int i = 0; i < numberOfFrames; i++)
            {
                Media.SelectActiveFrame(FrameDimension.Time, i);
                frames.Add((Image)Media.Clone());
            }

            return frames;
        }

        //TODO moet nog in de pattern worden gezet !!
        public bool ImageGrayscale()
        {
            var gFilter = new ImageGrayscale();
            Media = gFilter.ApplyFilter(Media);
            return true;
        }


    }
}
