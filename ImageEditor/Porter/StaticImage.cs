using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class StaticImage
    {
        private Image _image;

        public StaticImage(Image image)
        {
            _image = image;
        }

        public List<Image> CreateFrames()
        {
            return new List<Image>{_image};
        }
    }
}

