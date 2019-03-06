using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class RandomizedFilter : Filter
    {
        private int offset = -1;

        protected override byte[] CalculatePixel(byte r, byte g, byte b)
        {
            if (offset == -1) SetRandomOffset();

            return new byte[]
            {
                Convert.ToByte((r + offset) % 255),
                Convert.ToByte((g + offset) % 255),
                Convert.ToByte((b + offset) % 255)
            };
        }

        private void SetRandomOffset()
        {
            Random r = new Random();
            offset = r.Next(100, 200);
        }
    }
}
