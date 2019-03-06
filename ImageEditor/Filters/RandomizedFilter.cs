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

        protected override Color CalculatePixel(Color color)
        {
            if (offset == -1) SetRandomOffset();

            return Color.FromArgb(
                color.A,
                (color.R + offset) % 255,
                (color.G + offset) % 255,
                (color.B + offset) % 255
                );
        }

        private void SetRandomOffset()
        {
            Random r = new Random();
            offset = r.Next(100, 200);
        }
    }
}
