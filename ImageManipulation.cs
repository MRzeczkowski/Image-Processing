using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace ImageProcessing
{
    // Manipulate method (bitmap)
        public class ImageEventArgs : EventArgs
        {
            public Bitmap bmap { get; set; }
           
        }

    class ImageManipulation
    {

        private Bitmap bmp { get; set; }

        public Bitmap Bmp { get { return bmp; } set { bmp = value; } }

        private Color[] pixels;
        private double[] values;

        public ImageManipulation(Bitmap bitmap)
        {
            if (bitmap == null) return;

            this.bmp = bitmap;
            SecondaryBitmap = (Bitmap)bmp.Clone();

            pixels = new Color[bmp.Height * bmp.Width];
            values = new double[bmp.Height * bmp.Width];
        }
                
        private Bitmap SecondaryBitmap;

        private BitmapData BitmapToBitmapData()
        {
            BitmapData bitmapData = new BitmapData();
            if (bmp != null)
            {
                bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                return bitmapData;
            }

            return bitmapData;
        }

        public BitmapData CloneBitmapData()
        {
            BitmapData SecondaryBitmapData = new BitmapData();
            if (bmp != null)
            {
                SecondaryBitmapData = SecondaryBitmap.LockBits(new Rectangle(0, 0, SecondaryBitmap.Width, SecondaryBitmap.Height), ImageLockMode.ReadWrite, SecondaryBitmap.PixelFormat);
                return SecondaryBitmapData;
            }

            return SecondaryBitmapData;
        }

        public void SortByHue()
        {
            /* int counter = 0;

             for (int i = 0; i < bmp.Width; i++)
             {
                 for (int j = 0; j < bmp.Height; j++)
                 {
                     pixels[counter] = bmp.GetPixel(i, j);
                     values[counter] = (bmp.GetPixel(i, j).GetHue());
                     counter++;
                 }
             }

             HeapSort();

             counter = 0;

             for (int i = 0; i < bmp.Width; i++)
             {
                 for (int j = 0; j < bmp.Height; j++)
                 {
                     bmp.SetPixel(i, j, pixels[counter]);
                     counter++;
                 }
             }*/

            var dictOfColors = new Dictionary<Color, int>();

            int x, y; // Coordinates

            for (x = bmp.Width; x-- > 0;)
            {
                for (y = bmp.Height; y-- > 0;)
                {
                    var pix = bmp.GetPixel(x, y);
                    dictOfColors[pix] = dictOfColors.ContainsKey(pix) ? dictOfColors[pix] + 1 : 1;
                }
            }

            y = bmp.Height;

            foreach(var q in dictOfColors.OrderBy(v => v.Key.GetHue()))
            {
                for (var n = q.Value; n-- > 0;)
                {
                    if (x <= 0)
                    {
                        x = bmp.Width;
                        --y;
                    }
                    bmp.SetPixel(--x, y, q.Key);

                }

            }

            OnImageFinished(bmp);
        }

        public void SortBySaturantion()
        {
            int counter = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    pixels[counter] = bmp.GetPixel(i, j);
                    values[counter] = (bmp.GetPixel(i, j).GetSaturation());
                    counter++;
                }
            }

            HeapSort();

            counter = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, pixels[counter]);
                    counter++;
                }
            }

            OnImageFinished(bmp);
        }

        public void SortByBrightness()
        {
            int counter = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    pixels[counter] = bmp.GetPixel(i, j);
                    values[counter] = (bmp.GetPixel(i, j).GetBrightness());
                    counter++;
                }
            }

            

            HeapSort();

            counter = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, pixels[counter]);
                    counter++;
                }
            }

            OnImageFinished(bmp);
        }
        
        public void SetRed(int Red)
        {
            BitmapData bitmapData = BitmapToBitmapData();
            BitmapData SecondaryBitmapData = CloneBitmapData();

            try
            {
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;

                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel
                    byte* PtrFirstPixelClone = (byte*)SecondaryBitmapData.Scan0;

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                        byte* currentLineClone = PtrFirstPixelClone + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {                           

                            if ((currentLine[x + 2] + Red > 0) && (currentLine[x + 2] + Red < 255))
                            {                            
                                currentLine[x + 2] = (byte)(currentLineClone[x + 2] + Red);
                            }
                            //else
                            //{
                            //    if (currentLine[x + 2] + Red == 0)
                            //    {
                            //        currentLine[x + 2] = 0;
                            //    }
                            //    else
                            //    {
                            //        currentLine[x + 2] = 255;
                            //    }
                            //}
                        }
                    }
                    bmp.UnlockBits(bitmapData);
                    SecondaryBitmap.UnlockBits(SecondaryBitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void SetGreen(int Green)
        {

            BitmapData bitmapData = BitmapToBitmapData();
            BitmapData SecondaryBitmapData = CloneBitmapData();

            try
            {
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;

                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel
                    byte* PtrFirstPixelClone = (byte*)SecondaryBitmapData.Scan0;

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                        byte* currentLineClone = PtrFirstPixelClone + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            if ((currentLine[x + 1] + Green > 0) && (currentLine[x + 1] + Green < 255))
                            {                            
                                currentLine[x + 1] = (byte)(currentLineClone[x + 1] + Green);
                            }
                        }
                    }
                    bmp.UnlockBits(bitmapData);
                    SecondaryBitmap.UnlockBits(SecondaryBitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void SetBlue(int Blue)
        {
            BitmapData bitmapData = BitmapToBitmapData();
            BitmapData SecondaryBitmapData = CloneBitmapData();

            try
            {
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;

                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel
                    byte* PtrFirstPixelClone = (byte*)SecondaryBitmapData.Scan0;

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                        byte* currentLineClone = PtrFirstPixelClone + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            if ((currentLine[x] + Blue > 0) && (currentLine[x] + Blue < 255))
                            {
                                currentLine[x] = (byte)(currentLineClone[x] + Blue);
                            }
                        }
                    }
                    bmp.UnlockBits(bitmapData);
                    SecondaryBitmap.UnlockBits(SecondaryBitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void ShiftPixelValue()
        {

            try
            {
                BitmapData bitmapData = BitmapToBitmapData();

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;


                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel



                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            byte tmp = currentLine[x];
                            currentLine[x] = currentLine[x + 1]; // Blue to green
                            currentLine[x + 1] = currentLine[x + 2]; //Green to red 
                            currentLine[x + 2] = tmp; // Red to blue
                                                      // ShiftPixelValue                           
                        }
                    }
                    bmp.UnlockBits(bitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void GrayScale()
        {
            try
            {
                BitmapData bitmapData = BitmapToBitmapData();

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;


                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            int avg = (currentLine[x] + currentLine[x + 1] + currentLine[x + 2])/3;

                            currentLine[x] = (byte)(0.0722 * currentLine[x] + 0.7152 * currentLine[x + 1] + 0.2126 * currentLine[x + 2]);
                            //GreyScale
                        }
                    }
                    bmp.UnlockBits(bitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void SwapBlueAndGreen()
        {
            try
            {
                BitmapData bitmapData = BitmapToBitmapData();

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;

                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel



                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            byte tmp = currentLine[x];
                            currentLine[x] = currentLine[x + 1]; // Blue to green
                            currentLine[x + 1] = tmp; //Green to Blue                                
                        }
                    }

                    bmp.UnlockBits(bitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void SwapBlueAndRed()
        {
            try
            {
                BitmapData bitmapData = BitmapToBitmapData();

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;

                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            byte tmp = currentLine[x];
                            currentLine[x] = currentLine[x + 2]; // Blue to Red
                            currentLine[x + 2] = tmp; //Red to Blue
                                                      // Swap Blue&Red                     
                        }
                    }

                    bmp.UnlockBits(bitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void SwapGreenAndRed()
        {
           try
            {
                BitmapData bitmapData = BitmapToBitmapData();

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;

                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel



                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            byte tmp = currentLine[x + 1];
                            currentLine[x + 1] = currentLine[x + 2]; // Green to Red
                            currentLine[x + 2] = tmp; //Red to Green
                                                      // Swap Green&Red                        
                        }
                    }

                    bmp.UnlockBits(bitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void Negative()
        {
            try
            {
                BitmapData bitmapData = BitmapToBitmapData();

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;


                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            currentLine[x] = (byte)(255 - currentLine[x]);
                            currentLine[x + 1] = (byte)(255 - currentLine[x + 1]);
                            currentLine[x + 2] = (byte)(255 - currentLine[x + 2]);
                        }
                    }
                    bmp.UnlockBits(bitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void OnlyRed()
        {
            try
            {
                BitmapData bitmapData = BitmapToBitmapData();

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;


                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            currentLine[x] = 0;
                            currentLine[x + 1] = 0;
                        }
                    }
                    bmp.UnlockBits(bitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void OnlyGreen()
        {
            try
            {
                BitmapData bitmapData = BitmapToBitmapData();

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;


                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            currentLine[x] = 0;
                            currentLine[x + 2] = 0;
                        }
                    }
                    bmp.UnlockBits(bitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void OnlyBlue()
        {
            try
            {
                BitmapData bitmapData = BitmapToBitmapData();

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;


                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            currentLine[x + 1] = 0;
                            currentLine[x + 2] = 0;
                        }
                    }
                    bmp.UnlockBits(bitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void Sepia()
        {
            try
            {
                BitmapData bitmapData = BitmapToBitmapData();

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;


                unsafe // C# doesn't support pointer arithmetic
                {
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0; // Point to first pixel

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);

                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            int tr = (int)(0.393 * currentLine[x + 2] + 0.769 * currentLine[x + 1] + 0.189 * currentLine[x]);
                            int tg = (int)(0.349 * currentLine[x + 2] + 0.686 * currentLine[x + 1] + 0.168 * currentLine[x]);
                            int tb = (int)(0.272 * currentLine[x + 2] + 0.534 * currentLine[x + 1] + 0.131 * currentLine[x]);

                            if(tr > 255)
                            {
                                currentLine[x + 2] = 255;
                            }
                            else
                            {
                                currentLine[x + 2] = (byte)tr;
                            }

                            if (tg > 255)
                            {
                                currentLine[x + 1] = 255;
                            }
                            else
                            {
                                currentLine[x + 1] = (byte)tg;
                            }

                            if (tb > 255)
                            {
                                currentLine[x] = 255;
                            }
                            else
                            {
                                currentLine[x] = (byte)tb;
                            }
                        }
                    }
                    bmp.UnlockBits(bitmapData);
                }
                OnImageFinished(bmp);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
            }
        }

        public void MirrorImage()
        {
            Bitmap tmp = bmp.Clone(new Rectangle(0,0,bmp.Width, bmp.Height), bmp.PixelFormat);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, tmp.GetPixel(bmp.Width - i - 1,j));
                }
            }
            OnImageFinished(bmp);
        }

        public void BlackAndWhite()
        {
            using (Graphics gr = Graphics.FromImage(bmp)) // SourceImage is a Bitmap object
            {
                var gray_matrix = new float[][] {
                new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                new float[] { 0,      0,      0,      1, 0 },
                new float[] { 0,      0,      0,      0, 1 }
            };

                int width = bmp.Width;
                int height = bmp.Height;

                var ia = new System.Drawing.Imaging.ImageAttributes();
                ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(gray_matrix));
                ia.SetThreshold((float)0.8); // Change this threshold as needed

                var rc = new Rectangle(0, 0, bmp.Width, bmp.Height);
                gr.DrawImage(bmp, rc, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, ia);

                Bitmap b = new Bitmap(width, height, gr);
                OnImageFinished(b);
            }
        }


        // Define the EventHandler Delegate
        public event EventHandler<ImageEventArgs> ImageFinished;

        // Add event Method
        protected virtual void OnImageFinished(Bitmap bmap)
        {
            ImageFinished?.Invoke(this, new ImageEventArgs() { bmap = bmp });
        }

        private void HeapSort()
        {
            int heapSize = bmp.Height * bmp.Width;

            Color color;
            double tmp;

            for (int p = (heapSize - 1) / 2; p >= 0; p--)
                MaxHeapify(heapSize, p);

            for (int i = bmp.Height * bmp.Width - 1; i >= 0; i--)
            {
                color = Color.FromArgb(pixels[i].A, pixels[i].R, pixels[i].G, pixels[i].B);
                pixels[i] = Color.FromArgb(pixels[0].A, pixels[0].R, pixels[0].G, pixels[0].B);
                pixels[0] = Color.FromArgb(color.A, color.R, color.G, color.B);

                tmp = values[i];
                values[i] = values[0];
                values[0] = tmp;

                heapSize--;
                MaxHeapify(heapSize, 0);
            }
        }

        private void MaxHeapify(int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            Color color;
            double tmp;

            if (left < heapSize && values[left] > values[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && values[right] > values[largest])
                largest = right;

            if (largest != index)
            {
                color = Color.FromArgb(pixels[index].A, pixels[index].R, pixels[index].G, pixels[index].B);
                pixels[index] = Color.FromArgb(pixels[largest].A, pixels[largest].R, pixels[largest].G, pixels[largest].B);
                pixels[largest] = Color.FromArgb(color.A, color.R, color.G, color.B);

                tmp = values[index];
                values[index] = values[largest];
                values[largest] = tmp;

                MaxHeapify(heapSize, largest);
            }
        }
    }
}