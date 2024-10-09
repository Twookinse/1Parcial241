using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap imagenOriginal = new Bitmap(ofd.FileName);
                pictureBox1.Image = imagenOriginal;

                Bitmap imagenGris = ConvertirAGris(imagenOriginal);

                Bitmap imagenBordes = DeteccionBordesSobel(imagenGris);

                pictureBox2.Image = imagenBordes;
            }
        }
        private Bitmap ConvertirAGris(Bitmap imagen)
        {
            Bitmap gris = new Bitmap(imagen.Width, imagen.Height);

            for (int i = 0; i < imagen.Width; i++)
            {
                for (int j = 0; j < imagen.Height; j++)
                {
                    Color pixel = imagen.GetPixel(i, j);
                    int grisColor = (int)(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B);
                    gris.SetPixel(i, j, Color.FromArgb(grisColor, grisColor, grisColor));
                }
            }

            return gris;
        }
        private Bitmap DeteccionBordesSobel(Bitmap imagenGris)
        {
            Bitmap resultado = new Bitmap(imagenGris.Width, imagenGris.Height);

            int[,] sobelX = new int[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            int[,] sobelY = new int[,]
            {
                { -1, -2, -1 },
                { 0, 0, 0 },
                { 1, 2, 1 }
            };

            for (int x = 1; x < imagenGris.Width - 1; x++)
            {
                for (int y = 1; y < imagenGris.Height - 1; y++)
                {
                    int pixelX = 0;
                    int pixelY = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = imagenGris.GetPixel(x + i, y + j);
                            int intensidad = pixel.R;

                            pixelX += intensidad * sobelX[i + 1, j + 1];
                            pixelY += intensidad * sobelY[i + 1, j + 1];
                        }
                    }

                    int magnitud = (int)Math.Sqrt(pixelX * pixelX + pixelY * pixelY);

                    magnitud = Math.Min(255, Math.Max(0, magnitud));

                    resultado.SetPixel(x, y, Color.FromArgb(magnitud, magnitud, magnitud));
                    Color colorBorde;
                    if (magnitud > 200)
                    {
                        colorBorde = Color.Red; 
                    }
                    else if (magnitud > 100)
                    {
                        colorBorde = Color.Yellow;  
                    }
                    else
                    {
                        colorBorde = Color.Cyan; 
                    }
                }
            }

            return resultado;
        }

    }
}
