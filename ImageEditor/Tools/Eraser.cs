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
        override public void ApplyTool(ref Image image, Color color, Point previous, Point current)
        {
            SolidBrush eraser = new SolidBrush(Color.White);
            //Pen eraser = new Pen(Color.White);
            //eraser.Width = 10;
            using (Graphics g = Graphics.FromImage(image))
            {
                //g.DrawLine(eraser, previous.X, previous.Y, current.X, current.Y);
                g.FillRectangle(eraser, current.X-5, current.Y-5, 10, 10);
            }
        }
    }
}
