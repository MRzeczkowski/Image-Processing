using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ImageProcessing
{
    public partial class MainForm : Form
    {
        Bitmap newFile;
        Bitmap original;

        ImageManipulation modifyRGB;
        ImageHistogram histogram1;
        ImageHistogram histogram2;
        FileOperations getFile;
        

        public MainForm()
        {
            InitializeComponent();

            getFile = new FileOperations();

        }

        public void DisplayImage(Bitmap bitmap, int window)
        {
            switch (window)
            {
                case 1:
                    pictureBox1.Image = bitmap;
                    break;
                case 2:
                    pictureBox2.Image = bitmap;
                    break;
                case 3:
                    pictureBox1.Image = bitmap;
                    pictureBox2.Image = bitmap;
                    break;
            }
            
        }       

        public void OnImageFinished(object sender, ImageEventArgs e)
        {
            DisplayImage(e.bmap, 2);
            
            //histogram2.DrawHistogram();            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            newFile =  getFile.OpenFile();
            if(newFile != null)
                original = newFile.Clone(new Rectangle(0, 0, newFile.Width, newFile.Height), newFile.PixelFormat);


            modifyRGB= new ImageManipulation(newFile);
            modifyRGB.ImageFinished += OnImageFinished;
            
            DisplayImage(original, 3);

            histogram1 = new ImageHistogram(pictureBox1, pictureBox3);
            histogram1.DrawHistogram();

            histogram2 = new ImageHistogram(pictureBox2, pictureBox4);
            histogram2.DrawHistogram();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RedBar_Scroll(object sender, EventArgs e)
        {
            lbRed.Text = "Red:" + RedBar.Value;

            modifyRGB.SetRed(RedBar.Value);
            //histogram2.DrawHistogram();
        }

        private void GreenBar_Scroll(object sender, EventArgs e)
        {
            lbGreen.Text = "Green:" + GreenBar.Value;
            modifyRGB.SetGreen(GreenBar.Value);            
        }

        private void BlueBar_Scroll(object sender, EventArgs e)
        {
            lbBlue.Text = "Blue:" + BlueBar.Value;
            modifyRGB.SetBlue(BlueBar.Value);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(original != null)
            newFile = original.Clone(new Rectangle(0,0, original.Width, original.Height), original.PixelFormat);

            modifyRGB.Bmp = newFile;
            RedBar.Value = 0;
            GreenBar.Value = 0;
            BlueBar.Value = 0;
            DisplayImage(newFile, 3);
            histogram2.DrawHistogram();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            getFile.SaveFile(newFile);
        }

        private void btnRotateCountClockwise_Click(object sender, EventArgs e)
        {
            if(newFile != null)
            {
                newFile.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            DisplayImage(newFile, 2);
        }

        private void btnRotateClockwise_Click(object sender, EventArgs e)
        {
            if (newFile != null)
            {
                newFile.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            DisplayImage(newFile, 2);
        }

        private void cmbSwapPixelValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modifyRGB == null)
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
                return;
            }

            switch (cmbSwapPixelValues.Text)
            {
                case "ShiftPixelValues":
                    modifyRGB.ShiftPixelValue();
                    break;

                case "Swap Blue&Green":
                    modifyRGB.SwapBlueAndGreen();
                    break;

                case "Swap Blue&Red":
                    modifyRGB.SwapBlueAndRed();
                    break;

                case "Swap Green&Red":
                    modifyRGB.SwapGreenAndRed();
                    break;

            }
        }

        private void cmbChangeTone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modifyRGB == null)
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
                return;
            }

            switch (cmbChangeTone.Text)
            {
                case "Grayscale":
                    modifyRGB.GrayScale();
                    histogram2.DrawHistogram();
                    break;

                case "Sepia":
                    modifyRGB.Sepia();
                    histogram2.DrawHistogram();
                    break;               
            }
        }

        private void cmbRemoveColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modifyRGB == null)
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
                return;
            }

            switch (cmbRemoveColor.Text)
            {
                case "Only red":
                    modifyRGB.OnlyRed();
                    histogram2.DrawHistogram();
                    break;

                case "Only green":
                    modifyRGB.OnlyGreen();
                    histogram2.DrawHistogram();
                    break;

                case "Only blue":
                    modifyRGB.OnlyBlue();
                    histogram2.DrawHistogram();
                    break;

                case "Black and white":
                    modifyRGB.BlackAndWhite();
                    histogram2.DrawHistogram();
                    break;
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modifyRGB == null)
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
                return;
            }

            switch (cmbSort.Text)
            {
                case "Sort by hue":
                    modifyRGB.SortByHue();
                    histogram2.DrawHistogram();
                    break;

                case "Sort by saturation":
                    modifyRGB.SortBySaturantion();
                    histogram2.DrawHistogram();
                    break;

                case "Sort by brightness":
                    modifyRGB.SortByBrightness();
                    histogram2.DrawHistogram();
                    break;
            }
        }

        private void btnMirrorImage_Click(object sender, EventArgs e)
        {
            if (modifyRGB == null)
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
                return;
            }

            newFile.RotateFlip(RotateFlipType.RotateNoneFlipX);
            DisplayImage(newFile, 2);
            histogram2.DrawHistogram();
        }

        private void btnNegtive_Click(object sender, EventArgs e)
        {
            if (modifyRGB == null)
            {
                System.Windows.Forms.MessageBox.Show("Please select image first", "Error");
                return;
            }

            modifyRGB.Negative();
            histogram2.DrawHistogram();
        }

        private void RedBar_MouseUp(object sender, MouseEventArgs e)
        {
            histogram2.DrawHistogram();
        }

        private void GreenBar_MouseUp(object sender, MouseEventArgs e)
        {
            histogram2.DrawHistogram();
        }

        private void BlueBar_MouseUp(object sender, MouseEventArgs e)
        {
            histogram2.DrawHistogram();
        }
    }
}