using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1___openCL___neural_networks
{
    public partial class Form1 : Form
    {
        double[,] array;
        int height, width;
        Bitmap image;
 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image File|*.png";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image = new Bitmap(openFileDialog1.OpenFile());
                width = image.Width;
                height = image.Height;
                array = new double[width, height];

                int pixel;
                for (int i = 0; i < width; i++)
                    for (int j = 0; j < height; j++)
                    {
                        pixel = image.GetPixel(i, j).B;
                        pixel += image.GetPixel(i, j).G;
                        pixel += image.GetPixel(i, j).R;
                        pixel /= 3;
                        if (pixel > 200)
                            array[i, j] = 0;
                        else if (pixel > 150 && pixel < 200)
                            array[i, j] = 0.25f;
                        else if (pixel > 100 && pixel < 150)
                            array[i, j] = 0.5f;
                        else if (pixel > 50 && pixel < 100)
                            array[i, j] = 0.75f;
                        else array[i, j] = 1; 
                    }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double sum = 0;
            Random rand = new Random();

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    sum += array[i, j] * rand.NextDouble() * ( 100 - 0 ) + 0; // ( Max - Min ) + Min
            double euler = 2.71;
            double output = 1 / (1 + Math.Pow(euler, -1 * sum));
            label1.Text = output.ToString();
        }  
    }
}