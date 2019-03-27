using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    abstract class Tool
    {
        public abstract void ApplyTool(ref Image image, Color color, Point previous, Point current);
    }
}
