using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    interface IMediaPorter
    {
        List<Image> MediaToFrames(Image image);
        bool ImportMedia();
        bool ExportMedia(FolderBrowserDialog folderSelectDialog, List<Image> frames);
    }
}
