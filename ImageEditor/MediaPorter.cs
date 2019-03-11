using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AnimatedGif;

namespace ImageEditor
{
    internal class MediaPorter
    {
        private string _fileLocation;
        private Image _mediaFile;

        public Image OpenMedia(OpenFileDialog openMediaDialog)
        {
            var mediaDialog = openMediaDialog;
            var result = mediaDialog.ShowDialog();
            var size = -1;
            Image image = null;

            if (result == DialogResult.OK) // Test result.
            {
                var file = openMediaDialog.FileName;
                try
                {
                    var text = File.ReadAllText(file);
                    size = text.Length;
                    image = Image.FromFile(openMediaDialog.FileName);
                    var fileNameArray = file.Replace("\\", "|").Split('|');
                    image.Tag = fileNameArray[fileNameArray.Length - 1];
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return image;
        }

        public bool SaveMedia()
        {
            return false;
        }

        public bool ExportMedia(FolderBrowserDialog folderSelectDialog, Image media, string extension = null, List<Image> frames = null)
        {
            string selectedPath;
            using (var fbd = folderSelectDialog)
            {
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectedPath = fbd.SelectedPath;

                    if (extension == ".gif")
                    {
                        using (var gif = AnimatedGif.AnimatedGif.Create(selectedPath, 33))
                        {
                            foreach (var frame in frames) gif.AddFrame(frame, -1, GifQuality.Bit8);
                        }

                        return true;
                    }

                    media.Save(selectedPath + "\\" + media.Tag);
                    return true;
                }
            }

            return false;
        }
    }
}