using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class Eraser : Tool
    {
        override public void ApplyTool(ref Image image, Color color, Point previous, Point current)
        {
            //SolidBrush eraser = new SolidBrush(Color.White);
            Pen eraser = new Pen(Color.White, 20);
            eraser.LineJoin = LineJoin.Bevel;
            //eraser.Width = 10;
            using (Graphics g = Graphics.FromImage(image))
            {
                var path = new GraphicsPath();
                path.AddLine(previous, current);
                //g.DrawLine(eraser, previous.X, previous.Y, current.X, current.Y);
                //g.FillEllipse(eraser, current.X-5, current.Y-5, 10, 10);
                g.DrawPath(eraser, path);
                g.Dispose();
            }
        }
    }
}
