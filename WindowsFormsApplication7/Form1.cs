using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        private int szer = 0, wys = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //odczytaj
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                szer = pictureBox1.Image.Width;
                wys = pictureBox1.Image.Height;
                pictureBox2.Image = new Bitmap(szer, wys);
            }
        }

        private void button1_Click_1(object sender, EventArgs e) //koniec
        {
            Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //R-B
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k2 = Color.FromArgb(k1.B, k1.G, k1.R);
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void button3_Click(object sender, EventArgs e) //R-G
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k2 = Color.FromArgb(k1.G, k1.R, k1.B);
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private double checkRGB(double RGB)
        {
            if (RGB > 255) return 255;
            else if (RGB < 0) return 0;
            else return RGB;
        }
        //button5 rozjasnanie przyciemnianie
        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            int d = (int)numericUpDown1.Value;

            Color k1, k2;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k2 = Color.FromArgb((int)checkRGB(k1.R+d), (int)checkRGB(k1.G + d), (int)checkRGB(k1.B + d));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }
        //button6 - negatyw
        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            int d = (int)numericUpDown1.Value;

            Color k1, k2;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k2 = Color.FromArgb(255 - k1.R, 255 - k1.G, 255 - k1.B);
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Potegowa_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            int d = (int)numericUpDown1.Value;
            double c = 1;
            double n = (double)numericUpDown2.Value;

            Color k1, k2;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    double new_R = (Math.Pow((double)k1.R/255, n) *c)*255;
                    double new_G = (Math.Pow((double)k1.G/255, n) * c)*255;
                    double new_B = (Math.Pow((double)k1.B/255, n) * c)*255;
                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void Suma_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    k2 = Color.FromArgb((int)checkRGB(k1.R+k3.R), (int)checkRGB(k1.G + k3.G), (int)checkRGB(k1.B + k3.B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Load(openFileDialog2.FileName);
                pictureBox2.Image = new Bitmap(szer, wys);
            }
        }

        private void Odejmowanie_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R = ((double)k1.R/255 + (double)k3.R/255 - 1) * 255;
                    double new_G = ((double)k1.G/255 + (double)k3.G/255 - 1) * 255; 
                    double new_B = ((double)k1.B/255 + (double)k3.B/255 - 1) * 255;
                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Roznica_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    k2 = Color.FromArgb(Math.Abs(k1.R - k3.R), Math.Abs(k1.G - k3.G), Math.Abs(k1.B - k3.B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Mnozenie_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R = ((double)k1.R / 255 * (double)k3.R / 255) * 255;
                    double new_G = ((double)k1.G / 255 * (double)k3.G / 255) * 255;
                    double new_B = ((double)k1.B / 255 * (double)k3.B / 255) * 255;
                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Mnozenie_odw_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R = (1 - (1 - (double)k1.R / 255) * (1 - (double)k3.R / 255)) * 255;
                    double new_G = (1 - (1 - (double)k1.G / 255) * (1 - (double)k3.G / 255)) * 255;
                    double new_B = (1 - (1 - (double)k1.B / 255) * (1 - (double)k3.B / 255)) * 255;
                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Negacja_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R = (1 - Math.Abs(1 - (double)k1.R/255 - (double)k3.R)/255) * 255;
                    double new_G = (1 - Math.Abs(1 - (double)k1.G/255 - (double)k3.G/255)) * 255;
                    double new_B = (1 - Math.Abs(1 - (double)k1.B/255 - (double)k3.B/255)) * 255;
                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Ciemniejsze_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R;
                    double new_G;
                    double new_B;
                    if (k1.R > k3.R)
                        new_R = k1.R;
                    else
                        new_R = k3.R;
                    if (k1.G > k3.G)
                        new_G = k1.G;
                    else
                        new_G = k3.G;
                    if (k1.B > k3.B)
                        new_B = k1.B;
                    else
                        new_B = k3.B;

                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Jasniejsze_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R;
                    double new_G;
                    double new_B;
                    if (k1.R < k3.R)
                        new_R = k1.R;
                    else
                        new_R = k3.R;
                    if (k1.G < k3.G)
                        new_G = k1.G;
                    else
                        new_G = k3.G;
                    if (k1.B < k3.B)
                        new_B = k1.B;
                    else
                        new_B = k3.B;

                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Wylaczenie_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R = ((double)k1.R/255 + (double)k3.R/255 - 2* ((double)k1.R/255)* ((double)k3.R/255))*255;
                    double new_G = ((double)k1.G / 255 + (double)k3.G / 255 - 2 * ((double)k1.G / 255) * ((double)k3.G / 255)) * 255;
                    double new_B = ((double)k1.B / 255 + (double)k3.B / 255 - 2 * ((double)k1.B / 255) * ((double)k3.B / 255)) * 255;


                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Nakladka_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R;
                    double new_G;
                    double new_B;
                    if (k1.R < 0.5)
                        new_R = (2 * (double)k1.R / 255 * (double)k3.R / 255) * 255;
                    else
                        new_R = (1 - 2 * (1 - (double)k1.R / 255) * (1 - (double)k3.R / 255)) * 255;

                    if (k1.G < 0.5)
                        new_G = (2 * (double)k1.G / 255 * (double)k3.G / 255) * 255;
                    else
                        new_G = (1 - 2 * (1 - (double)k1.G / 255) * (1 - (double)k3.G / 255)) * 255;

                    if (k1.B < 0.5)
                        new_B = (2 * (double)k1.B / 255 * (double)k3.B / 255) * 255;
                    else
                        new_B = (1 - 2 * (1 - (double)k1.B / 255) * (1 - (double)k3.B / 255)) * 255;


                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }
        //ostre swiatlo
        private void button7_Click_2(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R;
                    double new_G;
                    double new_B;

                    if (k3.R < 0.5)
                        new_R = (2 * (double)k1.R / 255 * (double)k3.R / 255) * 255;
                    else
                        new_R = (1 - 2 * (1 - (double)k1.R / 255) * (1 - (double)k3.R / 255)) * 255;

                    if (k3.G < 0.5)
                        new_G = (2 * (double)k1.G / 255 * (double)k3.G / 255) * 255;
                    else
                        new_G = (1 - 2 * (1 - (double)k1.G / 255) * (1 - (double)k3.G / 255)) * 255;

                    if (k3.B < 0.5)
                        new_B = (2 * (double)k1.B / 255 * (double)k3.B / 255) * 255;
                    else
                        new_B = (1 - 2 * (1 - (double)k1.B / 255) * (1 - (double)k3.B / 255)) * 255;


                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void lag_sw_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R;
                    double new_G;
                    double new_B;

                    if (k3.R < 0.5)
                        new_R = (2 * (double)k1.R / 255 * (double)k3.R / 255 + Math.Pow((double)k1.R / 255, 2) * (1 - 2 * (double)k3.R / 255)) * 255;
                    else
                        new_R = (Math.Sqrt((double)k1.R / 255) * (2 * (double)k3.R / 255 - 1) + (2 * (double)k1.R / 255) * (1 - (double)k3.R / 255))*255;

                    if (k3.G < 0.5)
                        new_G = (2 * (double)k1.G / 255 * (double)k3.G / 255 + Math.Pow((double)k1.G / 255, 2) * (1 - 2 * (double)k3.G / 255)) * 255;
                    else
                        new_G = (Math.Sqrt((double)k1.G / 255) * (2 * (double)k3.G / 255 - 1) + (2 * (double)k1.G / 255) * (1 - (double)k3.G / 255)) * 255;

                    if (k3.B < 0.5)
                        new_B = (2 * (double)k1.B / 255 * (double)k3.B / 255 + Math.Pow((double)k1.B / 255, 2) * (1 - 2 * (double)k3.B / 255)) * 255;
                    else
                        new_B = (Math.Sqrt((double)k1.B / 255) * (2 * (double)k3.B / 255 - 1) + (2 * (double)k1.B / 255) * (1 - (double)k3.B / 255)) * 255;


                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Rozcienczanie_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R;
                    double new_G;
                    double new_B;

                    new_R = ((double)k1.R/255 / (1 - (double)k3.R/255))*255;
                    new_G = ((double)k1.G / 255 / (1 - (double)k3.G / 255)) * 255;
                    new_B = ((double)k1.B / 255 / (1 - (double)k3.B / 255)) * 255;

                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Wypalanie_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R;
                    double new_G;
                    double new_B;

                    new_R = (1 - (1 - (double)k1.R / 255) / (double)k3.R / 255) * 255;
                    new_G = (1 - (1 - (double)k1.G / 255) / (double)k3.G / 255) * 255;
                    new_B = (1 - (1 - (double)k1.B / 255) / (double)k3.B / 255) * 255;

                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void reflect_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);
                    double new_R;
                    double new_G;
                    double new_B;

                    new_R = (Math.Sqrt((double)k1.R / 255) / (1 - (double)k3.R / 255)) * 255;
                    new_G = (Math.Sqrt((double)k1.G / 255) / (1 - (double)k3.G / 255)) * 255;
                    new_B = (Math.Sqrt((double)k1.B / 255) / (1 - (double)k3.B / 255)) * 255;


                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void przez_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            double a = (double)numericUpDown3.Value;
            Color k1, k2, k3;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = b3.GetPixel(x, y);

                    double new_R;
                    double new_G;
                    double new_B;

                    new_R = ((1 - a) * (double)k3.R / 255 + a * (double)k1.R/255)*255;
                    new_G = ((1 - a) * (double)k3.G / 255 + a * (double)k1.G/255) * 255;
                    new_B = ((1 - a) * (double)k3.B / 255 + a * (double)k1.B/255) * 255;


                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void Filltr_Click(object sender, EventArgs e)
        {
            
        }

        private void Filtr_Click(object sender, EventArgs e)
        {
            int w1 = Int32.Parse(textBox1.Text);
            int w2 = Int32.Parse(textBox2.Text);
            int w3 = Int32.Parse(textBox3.Text);
            int w4 = Int32.Parse(textBox4.Text);
            int w5 = Int32.Parse(textBox5.Text);
            int w6 = Int32.Parse(textBox6.Text);
            int w7 = Int32.Parse(textBox7.Text);
            int w8 = Int32.Parse(textBox8.Text);
            int w9 = Int32.Parse(textBox9.Text);
            int wspolczynniki = w1 + w2 + w3 + w4 + w5 + w6 + w7 + w8 + w9;
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1, k2, k3, k4, k5, k6, k7, k8, k9;

            for (int x = 1; x < szer - 1; x++)
            {
                for (int y = 1; y < wys - 1; y++)
                {
                    k1 = b1.GetPixel(x - 1, y - 1);
                    k2 = b1.GetPixel(x - 1, y);
                    k3 = b1.GetPixel(x - 1, y + 1);
                    k4 = b1.GetPixel(x, y - 1);
                    k5 = b1.GetPixel(x, y);
                    k6 = b1.GetPixel(x, y + 1);
                    k7 = b1.GetPixel(x + 1, y - 1);
                    k8 = b1.GetPixel(x + 1, y);
                    k9 = b1.GetPixel(x + 1, y + 1);



                    double new_R;
                    double new_G;
                    double new_B;

                    if (wspolczynniki != 0)
                    {
                        new_R = (k1.R * w1 + k2.R * w2 + k3.R * w3 + k4.R * w4 + k5.R * w5 + k6.R * w6 + k7.R * w7 + k8.R * w8 + k9.R * w9) / wspolczynniki;
                        new_G = (k1.G * w1 + k2.G * w2 + k3.G * w3 + k4.G * w4 + k5.G * w5 + k6.G * w6 + k7.G * w7 + k8.G * w8 + k9.G * w9) / wspolczynniki;
                        new_B = (k1.B * w1 + k2.B * w2 + k3.B * w3 + k4.B * w4 + k5.B * w5 + k6.B * w6 + k7.B * w7 + k8.B * w8 + k9.B * w9) / wspolczynniki;
                    }
                    else
                    {
                        new_R = (k1.R * w1 + k2.R * w2 + k3.R * w3 + k4.R * w4 + k5.R * w5 + k6.R * w6 + k7.R * w7 + k8.R * w8 + k9.R * w9);
                        new_G = (k1.G * w1 + k2.G * w2 + k3.G * w3 + k4.G * w4 + k5.G * w5 + k6.G * w6 + k7.G * w7 + k8.G * w8 + k9.G * w9);
                        new_B = (k1.B * w1 + k2.B * w2 + k3.B * w3 + k4.B * w4 + k5.B * w5 + k6.B * w6 + k7.B * w7 + k8.B * w8 + k9.B * w9);
                    }


                    k2 = Color.FromArgb((int)checkRGB(new_R), (int)checkRGB(new_G), (int)checkRGB(new_B));
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }

        private void button4_Click(object sender, EventArgs e) //G-B
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k1, k2;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k2 = Color.FromArgb(k1.R, k1.B, k1.G);
                    b2.SetPixel(x, y, k2);
                }
            }
            pictureBox2.Refresh();
        }
    }
}
