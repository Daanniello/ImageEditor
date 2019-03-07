using System;

namespace ImageEditor
{
    class RandomizedFilter : Filter
    {
        private int offsetR = -1;
        private int offsetG = -1;
        private int offsetB = -1;

        protected override byte[] CalculatePixel(byte r, byte g, byte b)
        {
            if (offsetR == -1) SetRandomOffset();

            return new byte[]
            {
                Convert.ToByte((r + offsetR) % 255),
                Convert.ToByte((g + offsetG) % 255),
                Convert.ToByte((b + offsetB) % 255)
            };
        }

        private void SetRandomOffset()
        {
            Random r = new Random();
            offsetR = r.Next(100, 200);
            offsetG = r.Next(100, 200);
            offsetB = r.Next(100, 200);
        }
    }
}
