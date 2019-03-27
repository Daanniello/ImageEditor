using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class Pencil : Tool
    {
        override public void ApplyTool(ref Image image, Color color, Point previous, int x, int y)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawLine(Pens.Black, previous.X, previous.Y, x, y);
            }
        }
    }
}
