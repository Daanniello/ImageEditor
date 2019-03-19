using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class CycledFilter : Filter
    {
        protected override byte[] CalculatePixel(byte r, byte g, byte b)
        {
            return new byte[] 
            {
                Convert.ToByte(b),
                Convert.ToByte(r),
                Convert.ToByte(g)
            };
        }
    }
}
