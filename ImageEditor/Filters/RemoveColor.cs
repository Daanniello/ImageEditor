using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor.Filters
{
    class RemoveColor : Filter
    {
        private Color pickedColor;
        private int rRange = 50;
        private int gRange = 50;
        private int bRange = 50;

        public RemoveColor()
        {
            var dialog = new ColorDialog();
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;
            pickedColor = dialog.Color;
        }

        protected override byte[] CalculatePixel(byte r, byte g, byte b, byte a)
        {
            var alpha = a;
            if (r > 130 || g > 130 || g > 130)
            {
                int ga = 3;
            }
            var k = Color.FromArgb(a, r, g, b);
            var f = pickedColor.GetHue();
            var h = k.GetHue();
            var n = k.ToKnownColor();

            if (h - f > 200)
            {
                alpha = 0;
            }

            return new byte[]
            {
                Convert.ToByte(r),
                Convert.ToByte(g),
                Convert.ToByte(b),
                Convert.ToByte(alpha)
            };
        }
    }
}
