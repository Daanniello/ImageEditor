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
        protected override Color CalculatePixel(Color color)
        {
            int totalColor = color.R + color.G + color.B;
            int splitColor = totalColor / 3;

            return Color.FromArgb(
                color.A,
                splitColor,
                splitColor,
                splitColor
                );
        }
    }
}
