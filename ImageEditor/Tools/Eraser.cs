using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class Eraser : Tool
    {
        override public Bitmap ApplyTool(Image image, Color color, Point previous, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
