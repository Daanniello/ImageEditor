using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class Media
    {
        public Image File;
        public string Extension;
        public int FrameIndex;
        public List<int> SelectedFrames;
        public List<Image> Frames;

        public Media()
        {

        }

    }
}
