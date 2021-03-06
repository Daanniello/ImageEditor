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
        override public void ApplyTool(ref Image image, Color color, Point previous, Point current)
        {
            Pen p = new Pen(color);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawLine(p, previous.X, previous.Y, current.X, current.Y);
            }
        }
    }
}
