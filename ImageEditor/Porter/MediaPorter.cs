using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using AnimatedGif;

namespace ImageEditor
{
    class MediaPorter
    {
        public MediaPorter()
        {

        }

        public List<Image> MediaToFrames(Image image)
        {
            List<Image> frames = new List<Image>();
            int length = image.GetFrameCount(FrameDimension.Time);

            for (int i = 0; i < length; i++)
            {
                image.SelectActiveFrame(FrameDimension.Time, i);
                frames.Add(new Bitmap(image));
            }

            return frames;
        }

        public MediaInformation Open(OpenFileDialog openFileDialog)
        {
            openFileDialog.Filter = "Image Files (PNG,GIF)|*.PNG;*.GIF";
            DialogResult result = openFileDialog.ShowDialog();

            if (result != DialogResult.OK) return new MediaInformation();

            MediaInformation mediaInformation = new MediaInformation();
            mediaInformation.Frames = new MediaAdapter(Image.FromFile(openFileDialog.FileName)).GetFrames();
            mediaInformation.File = Image.FromFile(openFileDialog.FileName);

            return mediaInformation;
        }

        public bool Save(SaveFileDialog saveFileDialog, MediaInformation media)
        {
            if (media.Frames.Count == 0) return false;
            saveFileDialog.Title = "Save File as...";
            saveFileDialog.Filter = "PNG Image|*.png";
            if (media.Frames.Count > 1) saveFileDialog.Filter = "Gif Image|*.gif";
            DialogResult result = saveFileDialog.ShowDialog();

            if (result != DialogResult.OK) return false;
            Image image = media.File;

            System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();

            var delay = 100;

            try
            {
                PropertyItem item = media.File.GetPropertyItem(0x5100);
                // Time is in milliseconds
                delay = (item.Value[0] + item.Value[1] * 256) * 10;
            }
            catch (Exception exc) { }

            if (media.Frames.Count > 1)
            {
                fs.Close();
                using (var gif = AnimatedGif.AnimatedGif.Create(fs.Name, delay))
                {
                    foreach (var frame in media.Frames) gif.AddFrame(frame, -1, GifQuality.Bit8);
                    
                }               
                return true;
            }
            else
            {
                media.Frames[0].Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                return true;
            }


        }
    }
}
