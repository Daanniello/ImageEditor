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

        public List<Image> GetSelectedFrames()
        {
            List<Image> frames = new List<Image>();
            for (int i = 0; i < Frames.Count; i++)
            {
                if (SelectedFrames.IndexOf(i) > -1)
                {
                    frames.Add(Frames[i]);
                }
            }
            return frames;
        }

        public bool SetSelectedFrames(Queue<Image> updatedFrames)
        {
            foreach (int i in SelectedFrames)
            {
                Frames[i] = updatedFrames.Dequeue();
            }
            return true;
        }
    }
}
