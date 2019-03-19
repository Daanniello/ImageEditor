using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ImageEditor
{
    class MediaInformation
    {
        public Image File;
        public string Extension;
        public int FrameIndex;
        public List<Image> Frames;

        public MediaInformation(Image file = null, string extension = "")
        {
            File = file;
            Extension = extension;
            FrameIndex = 0;
            Frames = new List<Image>();
        }

        public List<Image> GetSelectedFrames(List<int> selectedFrameIndexes)
        {
            List<Image> frames = new List<Image>();
            for (int i = 0; i < Frames.Count; i++)
            {
                if (selectedFrameIndexes.IndexOf(i) > -1)
                {
                    frames.Add(Frames[i]);
                }
            }
            return frames;
        }

        public bool SetSelectedFrames(List<int> selectedFrameIndexes, Queue<Image> updatedFrames)
        {
            foreach (int i in selectedFrameIndexes)
            {
                Frames[i] = updatedFrames.Dequeue();
            }
            return true;
        }
    }
}
