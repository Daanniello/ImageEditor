using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnimatedGif;

namespace ImageEditor
{
    class AnimatedImage
    {
        private Image _image;

        public AnimatedImage(Image image)
        {
            _image = image;
        }

        public List<Image> CreateFrames()
        {
            List<Image> frames = new List<Image>();
            int length = _image.GetFrameCount(FrameDimension.Time);

            for (int i = 0; i < length; i++)
            {
                _image.SelectActiveFrame(FrameDimension.Time, i);
                frames.Add(new Bitmap(_image));
            }

            return frames;
        }

        public void Save()
        {

        }
    }
}
