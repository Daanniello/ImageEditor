using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class MediaAdapter
    {
        private List<Image> _frames;

        public MediaAdapter(Image image)
        {
            try
            {
                if (image.GetFrameCount(FrameDimension.Time) > 1)
                {
                    _frames = new AnimatedImage(image).CreateFrames();
                }
            }
            catch
            {
                _frames = new StaticImage(image).CreateFrames();
            }
        }

        public List<Image> GetFrames()
        {
            return _frames;
        }
    }
}
