using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class GrayscaleFilter : Filter
    {
        protected override byte[] CalculatePixel(byte r, byte g, byte b, byte a)
        {
            int totalColor = r + g + b;
            byte value = Convert.ToByte(totalColor / 3);

            return new byte[] { value, value, value, Convert.ToByte(a) };
        }
    }
}
