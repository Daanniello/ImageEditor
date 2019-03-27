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
        override public void ApplyTool(ref Image image, Color color, Point previous, Point current)
        {
            var _rnd = new Random();
            Pen airbrush = new Pen(color);
            using (Graphics g = Graphics.FromImage(image))
            {
                for (int i = 0; i < 40; ++i)
                {
                    double theta = _rnd.NextDouble() * (Math.PI * 2);
                    double r = _rnd.NextDouble() * 15; // 15 is the radius

                    double x = current.X + Math.Cos(theta) * r;
                    double y = current.Y + Math.Sin(theta) * r;

                    g.DrawEllipse(airbrush, new Rectangle((int)x - 1, (int)y - 1, 1, 1));
                }
            }
        }
    }
}
