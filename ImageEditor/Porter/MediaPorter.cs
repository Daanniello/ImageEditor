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

            if (result != DialogResult.OK) throw new Exception();

            MediaInformation mediaInformation = new MediaInformation();
            mediaInformation.Frames = new MediaAdapter(Image.FromFile(openFileDialog.FileName)).GetFrames();

            return mediaInformation;
        }

        public bool Save(SaveFileDialog saveFileDialog, MediaInformation media)
        {
            saveFileDialog.Title = "Save File to as...";
            saveFileDialog.Filter = "PNG Image|*.png|Gif Image|*.gif";
            DialogResult result = saveFileDialog.ShowDialog();

            Image image = media.File;

            System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();

            if (result != DialogResult.OK) return false;

            if (media.Extension == ".gif")
            {
                using (var gif = AnimatedGif.AnimatedGif.Create("temp", 33))
                {
                    foreach (var frame in media.Frames) gif.AddFrame(frame, -1, GifQuality.Bit8);
                }
                image.Save("temp", System.Drawing.Imaging.ImageFormat.Gif);
                return true;
            }
            else
            {
                image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                return true;
            }


        }
    }
}
