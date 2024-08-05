using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;

namespace Webp_Convert_Antony
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void OpenWebPImage(string filePath)
        {
            using (MagickImage image = new MagickImage(filePath))
            {
                // Convert the image to a format that can be displayed in a PictureBox
                image.Format = MagickFormat.Bmp;

                // Create a Bitmap from the MagickImage
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Write(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    Bitmap bitmap = new Bitmap(ms);

                    // Display the Bitmap in the PictureBox
                    pictureBox1.Image = bitmap;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Adjust the SizeMode to fit the image
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create and configure the OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "WEBP files (*.webp)|*.webp|All files (*.*)|*.*";
                openFileDialog.Title = "Select a WEBP Image File";

                // Show the dialog and check if the user selected a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    string filePath = openFileDialog.FileName;

                    // Load and display the WEBP image
                    OpenWebPImage(filePath);
                }
            }

        }
    }
}
