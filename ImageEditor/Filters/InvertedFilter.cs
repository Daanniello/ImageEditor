using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class InvertedFilter : Filter
    {
        protected override byte[] CalculatePixel(byte r, byte g, byte b)
        {
            return new byte[] 
            {
                Convert.ToByte(255 - r),
                Convert.ToByte(255 - g),
                Convert.ToByte(255 - b)
            };
        }
    }
}
