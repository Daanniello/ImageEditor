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
        public MediaInformation MediaInformation;
        private MainView _view;

        public MediaEditor(MainView view)
        {
            MediaInformation = new MediaInformation();
            _view = view;
        }

        public bool OpenMedia(OpenFileDialog openFileDialog)
        {
            MediaInformation = new MediaPorter().Open(openFileDialog);
            return true;
        }

        public bool ExportMedia(SaveFileDialog saveFileDialog)
        {
            return new MediaPorter().Save(saveFileDialog, MediaInformation);
        }
        
        public bool ApplyFilter(string type)
        {
            Filter filter = Filter.MakeFilter(type);
            if (filter == null) return false;

            List<Image> frames = MediaInformation.GetSelectedFrames();
            Queue<Image> updatedFrames = filter.ApplyFilterOnFrames(frames);
            return MediaInformation.SetSelectedFrames(updatedFrames);
        }
    }
}
