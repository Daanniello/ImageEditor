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
        protected override Color CalculatePixel(Color color)
        {
            return Color.FromArgb(
                color.A,
                255 - color.R,
                255 - color.G,
                255 - color.B
                );
        }
    }
}
