using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    class PngMediaPorter : IMediaPorter
    {
        public List<Image> MediaToFrames(Image image)
        {
            List<Image> frames = new List<Image>();
            frames.Add(new Bitmap(image));
            return frames;
        }

        public bool ImportMedia()
        {
            throw new NotImplementedException();
        }

        public bool ExportMedia(FolderBrowserDialog folderSelectDialog, List<Image> frames)
        {
            DialogResult result = folderSelectDialog.ShowDialog();
            string selectedPath = folderSelectDialog.SelectedPath;

            if (result != DialogResult.OK) return false;
            if (string.IsNullOrWhiteSpace(selectedPath)) return false;

            Image media = frames[0];
            media.Save(selectedPath + "\\" + "New image.png");
            return true;

            //if (Media.Extension == ".gif")
            //{
            //    return _mediaPorter.ExportMedia(folderSelectDialog, Media.File, Media.Extension, Media.Frames);
            //}
            //return _mediaPorter.ExportMedia(folderSelectDialog, Media.File);
            //throw new NotImplementedException();
        }
    }
}
