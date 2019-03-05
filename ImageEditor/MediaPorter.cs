using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    class MediaPorter
    {
        private Image _mediaFile;
        private string _fileLocation;

        public MediaPorter()
        {
            
        }

        public Image OpenMedia(OpenFileDialog openMediaDialog)
        {
            OpenFileDialog mediaDialog = openMediaDialog;

            DialogResult result = mediaDialog.ShowDialog();
            var size = -1;
            Image image = null;

            if (result == DialogResult.OK) // Test result.
            {
                string file = openMediaDialog.FileName;
                try
                {
                    string text = File.ReadAllText(file);
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
            Console.WriteLine(size); 
            Console.WriteLine(result);
            return image;
        }

        public bool SaveMedia()
        {
            return false;
        }

        public bool ExportMedia(FolderBrowserDialog folderSelectDialog, Image media)
        {
            string selectedPath;
            using (var fbd = folderSelectDialog)
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectedPath = fbd.SelectedPath;
                    media.Save(selectedPath + "\\" + media.Tag);
                    return true;
                }
            }
            return false;
        }
    }
}
