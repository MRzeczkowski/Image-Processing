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
    class ImageHistogram
    {
        private Bitmap bitmap;
        private PictureBox Source;
        private PictureBox Sink;

        private Dictionary<float, int> histogram = new Dictionary<float, int>();

        public ImageHistogram(PictureBox Source, PictureBox Sink)
        {
            this.Source = Source;
            this.Sink = Sink;               
        }

        public void CreateHistogram()
        {
            histogram.Clear();
            this.bitmap = new Bitmap(Source.Image, Source.Width, Source.Height);

            for (int i = 0; i < bitmap.Width; i ++)
            {
                for(int j = 0; j < bitmap.Height; j++)
                {
                    Color col = bitmap.GetPixel(i, j);

                    //int brightness =  (int)Math.Floor((col.GetBrightness()));

                    float brightness = col.GetBrightness();

                    //int c = (col.R + col.G + col.B) / 3;

                    if (histogram.ContainsKey(brightness))
                    {
                        histogram[brightness] = histogram[brightness] + 1;
                    }
                    else
                    {
                        histogram.Add(brightness, 1);
                    }
                }
            }

            histogram.OrderBy(v => v.Value);

           
        }

        public void DrawHistogram()
        {
            

            CreateHistogram();

            int i = 0;

            Graphics g = Graphics.FromImage(bitmap);

            g.Clear(Color.White);

            int myMaxValue = histogram.Values.Max();
            int myLength = histogram.Count();

            float myOffset = 2;

            float myYUnit = (float)(Sink.Height - (2 * myOffset)) / myMaxValue;
            float myXUnit = (float)(Sink.Width - (2 * myOffset)) / (myLength - 1);


            foreach(var entry in histogram.OrderBy(v => v.Key))
            {
                
                Console.WriteLine("Key = {0}, Value = {1}", entry.Key, entry.Value);

                Pen myPen = new Pen(Color.Black);

                

                g.DrawLine(myPen, new PointF(myOffset + (i * myXUnit),
                            Sink.Height - myOffset), new PointF(myOffset + (i * myXUnit),
                            Sink.Height - myOffset - entry.Value * myYUnit));


               
                i++;
            }

            Console.WriteLine("+++++++++++SKONCZYLEM++++++++++++");
            Console.WriteLine("+++++++++++SKONCZYLEM++++++++++++");
            Console.WriteLine("+++++++++++SKONCZYLEM++++++++++++");

            Sink.Image = bitmap;

            g.Dispose();
        }
    }
}
