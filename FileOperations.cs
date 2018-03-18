using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ImageProcessing
{
    class FileOperations
    {
        Bitmap newImage;

        public Bitmap OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "C:\\Images";
            ofd.Filter = "images| *.jpg; *.png; *.bmp; *.gif;";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                newImage = new Bitmap(Image.FromFile(ofd.FileName));
            }
            return newImage;
        }

        public void SaveFile(Bitmap bmp)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = "C:\\Images";
            sfd.Filter = "images| *.jpg; *.png; *.bmp; *gif;";

            if (sfd.ShowDialog() == DialogResult.OK && bmp != null)
            {
                bmp.Save(sfd.FileName);
            }            
        }
    }
}
