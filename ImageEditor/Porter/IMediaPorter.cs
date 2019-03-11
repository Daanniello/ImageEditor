using System.Collections.Generic;
using System.Drawing;

namespace ImageEditor
{
    interface IMediaPorter
    {
        List<Image> MediaToFrames(Image image);
        bool ImportMedia();
        bool ExportMedia();
    }
}
