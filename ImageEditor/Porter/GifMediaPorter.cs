using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageEditor
{
    class GifMediaPorter : IMediaPorter
    {
        public List<Image> MediaToFrames(Image image)
        {
            List<Image> frames = new List<Image>();
            int length = image.GetFrameCount(FrameDimension.Time);

            for (int i = 0; i < length; i++)
            {
                image.SelectActiveFrame(FrameDimension.Time, i);
                frames.Add(new Bitmap(image));
            }

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
