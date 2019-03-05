using System;
using System.Collections.Generic;
using System.Drawing;
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


    }
}
