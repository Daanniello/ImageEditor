﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class Pencil : Tool
    {
        override public Bitmap ApplyTool(Image image, Color color, Point previous, int x, int y)
        {
            Bitmap bmp = new Bitmap(image);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawLine(Pens.Black, previous.X, previous.Y, x, y);
            }

                //bmp.SetPixel(x, y, Color.Black);
                return bmp;
        }
    }
}
