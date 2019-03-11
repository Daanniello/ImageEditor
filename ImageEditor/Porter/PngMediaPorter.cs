using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageEditor
{
    class PngMediaPorter : IMediaPorter
    {
        public List<Image> MediaToFrames(Image image)
        {
            List<Image> frames = new List<Image>();
            frames.Add(new Bitmap(image));
            return frames;
        }

        public bool ImportMedia()
        {
            throw new NotImplementedException();
        }

        public bool ExportMedia()
        {
            //if (Media.Extension == ".gif")
            //{
            //    return _mediaPorter.ExportMedia(folderSelectDialog, Media.File, Media.Extension, Media.Frames);
            //}
            //return _mediaPorter.ExportMedia(folderSelectDialog, Media.File);
            throw new NotImplementedException();
        }
    }
}
