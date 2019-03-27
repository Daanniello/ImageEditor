using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class SprayCan : Tool
    {
        override public Bitmap ApplyTool(Image image, Color color, Point previous, int x, int y)
        {
            Bitmap bmp = new Bitmap(image);
            bmp.SetPixel(x, y, Color.Black);
            bmp.SetPixel(x+1, y, Color.Black);
            bmp.SetPixel(x+2, y, Color.Black);
            bmp.SetPixel(x+3, y, Color.Black);
            bmp.SetPixel(x+4, y, Color.Black);
            bmp.SetPixel(x+5, y, Color.Black);
            return null;
        }
    }
}
