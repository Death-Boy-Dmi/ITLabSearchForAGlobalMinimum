using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Second_Interface
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
        }

        Graphics g;
        Pen xOy, gr, pt;
        int minX = 0, minY = -10, maxX = 10, maxY = 10, width, height;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                rLabel.Visible = true;
                mLabel.Visible = false;
                lyambdaLabel.Visible = false;
            }
            if (comboBox2.SelectedIndex == 1)
            {
                rLabel.Visible = true;
                mLabel.Visible = false;
                lyambdaLabel.Visible = false;
            }
            if (comboBox2.SelectedIndex == 2)
            {
                rLabel.Visible = false;
                mLabel.Visible = false;
                lyambdaLabel.Visible = true;
            }
            if (comboBox2.SelectedIndex == 3)
            {
                rLabel.Visible = false;
                mLabel.Visible = true;
                lyambdaLabel.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void mLabel_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void Vbutton1_Click_1(object sender, EventArgs e)
        {
            width = GrafPanel.Width;
            height = GrafPanel.Height;
            g = GrafPanel.CreateGraphics();
            xOy = new Pen(Color.Black, 2F);
            gr = new Pen(Color.Black);
            pt = new Pen(Color.Red, 2F);
            g.RotateTransform(180F);
            g.TranslateTransform(-width, -height);
            g.Clear(Color.White);

            if (VradioButton4.Checked)
                create_dinamic_axes();
            if (VradioButton5.Checked)
            {
                label5.Text = "x= " + minX.ToString();
                label6.Text = "x= " + maxX.ToString();
                label7.Text = "y= " + minY.ToString();
                label8.Text = "y= " + maxY.ToString();
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                create_static_axes();
            }
            create_curve();
        }

        private void VisualizationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Vbutton2_Click_1(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            g.Clear(Color.White);
            g.Dispose();
            xOy.Dispose();
            gr.Dispose();
            pt.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void create_dinamic_axes()
        {
            if (minX < 0 && maxX > 0 && minY < 0 && maxY > 0)
            {
                g.DrawLine(xOy, 0, Math.Abs(minY) * height / (maxY - minY), width, Math.Abs(minY) * height / (maxY - minY));
                g.DrawLine(xOy, maxX * width / (maxX - minX), 0, maxX * width / (maxX - minX), height);
            }
            else if (minX < 0 && maxX > 0 && minY >= 0)
            {
                g.DrawLine(xOy, 0, height / 75, width, height / 75);
                g.DrawLine(xOy, maxX * width / (maxX - minX), 0, maxX * width / (maxX - minX), height);
            }
            else if (minX < 0 && maxX > 0 && maxY <= 0)
            {
                g.DrawLine(xOy, 0, height - height / 75, width, height - height / 75);
                g.DrawLine(xOy, maxX * width / (maxX - minX), 0, maxX * width / (maxX - minX), height);
            }
            else if (minX >= 0 && minY < 0 && maxY > 0)
            {
                g.DrawLine(xOy, 0, Math.Abs(minY) * height / (maxY - minY), width, Math.Abs(minY) * height / (maxY - minY));
                g.DrawLine(xOy, width - width / 75, 0, width - width / 75, height);
            }
            else if (maxX <= 0 && minY < 0 && maxY > 0)
            {
                g.DrawLine(xOy, 0, Math.Abs(minY) * height / (maxY - minY), width, Math.Abs(minY) * height / (maxY - minY));
                g.DrawLine(xOy, width / 75, 0, width / 75, height);
            }
            else if (minX >= 0 && minY >= 0)
            {
                g.DrawLine(xOy, 0, height / 75, width, height / 75);
                g.DrawLine(xOy, width - width / 75, 0, width - width / 75, height);
            }
            else if (minX >= 0 && maxY <= 0)
            {
                g.DrawLine(xOy, 0, height - height / 75, width, height - height / 75);
                g.DrawLine(xOy, width - width / 75, 0, width - width / 75, height);
            }
            else if (maxX <= 0 && maxY <= 0)
            {
                g.DrawLine(xOy, 0, height - height / 75, width, height - height / 75);
                g.DrawLine(xOy, width / 75, 0, width / 75, height);
            }
            else if (maxX <= 0 && minY >= 0)
            {
                g.DrawLine(xOy, 0, height / 75, width, height / 75);
                g.DrawLine(xOy, width / 75, 0, width / 75, height);
            }
        }

        private void create_static_axes()
        {
            g.DrawLine(xOy, 0, height / 50, width, height / 50);
            g.DrawLine(xOy, width - width / 80, 0, width - width / 80, height);
        }

        private void create_curve()
        {
            int count = 150;
            double minimum = -9.01015;
            double[,] points = { { 0, 0 }, { 0.0665324, 0.0650858 }, { 0.133465, 0.121916 }, { 0.200398, 0.162016 }, { 0.267514, 0.178557 }, { 0.334622, 0.166291 }, { 0.401547, 0.122472 }, { 0.468473, 0.0466723 }, { 0.534803, -0.0579051 }, { 0.602599, -0.190338 }, { 0.669438, -0.339138 }, { 0.736276, -0.497065 }, { 0.802008, -0.651202 }, { 0.868623, -0.7952 }, { 0.934268, -0.914132 }, { 0.999913, -0.999911 }, { 1.06507, -1.04326 }, { 1.13019, -1.03778 }, { 1.19555, -0.978256 }, { 1.26092, -0.862352 }, { 1.32736, -0.687525 }, { 1.39262, -0.463857 }, { 1.45963, -0.187996 }, { 1.52664, 0.123916 }, { 1.59579, 0.469112 }, { 1.66109, 0.801348 }, { 1.72835, 1.13266 }, { 1.79562, 1.43493 }, { 1.86441, 1.6955 }, { 1.93222, 1.8873 }, { 2.0008, 2.0008 }, { 2.06938, 2.02188 }, { 2.13782, 1.94358 }, { 2.20921, 1.75372 }, { 2.27935, 1.46287 }, { 2.34948, 1.07786 }, { 2.41724, 0.630416 }, { 2.48744, 0.10799 }, { 2.5542, -0.422541 }, { 2.62095, -0.961974 }, { 2.68382, -1.45552 }, { 2.75399, -1.96314 }, { 2.82019, -2.37525 }, { 2.88639, -2.69982 }, { 2.95003, -2.91157 }, { 3.01492, -3.01225 }, { 3.07942, -2.98776 }, { 3.14392, -2.83486 }, { 3.21058, -2.54335 }, { 3.26985, -2.17628 }, { 3.33293, -1.68543 }, { 3.396, -1.10726 }, { 3.46396, -0.410305 }, { 3.52791, 0.289234 }, { 3.59651, 1.05413 }, { 3.6651, 1.79834 }, { 3.73746, 2.5203 }, { 3.80409, 3.09267 }, { 3.8729, 3.55889 }, { 3.94171, 3.87123 }, { 4.01136, 4.00964 }, { 4.08088, 3.95643 }, { 4.14985, 3.71078 }, { 4.21883, 3.27848 }, { 4.28571, 2.69491 }, { 4.3565, 1.92535 }, { 4.42321, 1.08696 }, { 4.48993, 0.174143 }, { 4.5509, -0.692024 }, { 4.61721, -1.63028 }, { 4.67637, -2.43082 }, { 4.73553, -3.16639 }, { 4.78801, -3.74214 }, { 4.85203, -4.3202 }, { 4.91022, -4.70539 }, { 4.96842, -4.93994 }, { 5.02455, -5.01255 }, { 5.08063, -4.92864 }, { 5.13897, -4.67456 }, { 5.19731, -4.25523 }, { 5.26201, -3.61005 }, { 5.36604, -2.23396 }, { 5.42148, -1.36915 }, { 5.48451, -0.314544 }, { 5.54178, 0.676703 }, { 5.6053, 1.77319 }, { 5.66882, 2.82325 }, { 5.73688, 3.84733 }, { 5.79803, 4.63756 }, { 5.86148, 5.29186 }, { 5.92493, 5.7476 }, { 5.98925, 5.98364 }, { 6.05334, 5.97801 }, { 6.11712, 5.72887 }, { 6.1809, 5.24184 }, { 6.24301, 4.55301 }, { 6.29487, 3.83184 }, { 6.34394, 3.04353 }, { 6.39301, 2.1699 }, { 6.43789, 1.31292 }, { 6.48698, 0.332202 }, { 6.5302, -0.551057 }, { 6.61015, -2.17636 }, { 6.66204, -3.18496 }, { 6.70483, -3.9654 }, { 6.7824, -5.2118 }, { 6.8554, -6.1269 }, { 6.91639, -6.65894 }, { 6.9969, -6.99537 }, { 7.07501, -6.89767 }, { 7.15312, -6.37868 }, { 7.24532, -5.25584 }, { 7.32414, -3.91623 }, { 7.42163, -1.8939 }, { 7.51911, 0.36133 }, { 7.6318, 2.98544 }, { 7.72423, 4.92948 }, { 7.82218, 6.58085 }, { 7.92061, 7.65025 }, { 8.02014, 8.00992 }, { 8.11975, 7.58986 }, { 8.16942, 7.09267 }, { 8.2181, 6.43078 }, { 8.26816, 5.58432 }, { 8.3159, 4.6378 }, { 8.4073, 2.52162 }, { 8.48826, 0.427581 }, { 8.55706, -1.41076 }, { 8.62317, -3.14408 }, { 8.67425, -4.41199 }, { 8.73411, -5.76949 }, { 8.77693, -6.62871 }, { 8.81975, -7.37581 }, { 8.84881, -7.81145 }, { 8.90975, -8.51779 }, { 8.9496, -8.81665 }, { 9.01482, -9.01015 }, { 9.08696, -8.78453 }, { 9.19823, -7.54921 }, { 9.26101, -6.41734 }, { 9.35155, -4.32895 }, { 9.44208, -1.84804 }, { 9.55692, 1.55665 }, { 9.65988, 4.51974 }, { 9.7145, 5.94373 }, { 9.77238, 7.27789 }, { 9.82854, 8.35693 }, { 9.88567, 9.19893 }, { 9.94279, 9.75325 }, { 10, 9.99873 } };

            PointF[] p = new PointF[count];

            if (VradioButton4.Checked)
            {
                for (int i = 0; i < count; ++i)
                {
                    PointF poss = new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(Math.Abs(minY) * height / (maxY - minY) + points[i, 1] * height / (maxY - minY)));
                    p[i] = poss;
                }

                if (VradioButton2.Checked)
                {
                    for (int i = 0; i < count; ++i)
                    {
                        if (points[i, 1] == minimum)
                        {
                            g.FillEllipse(Brushes.Green, new RectangleF(p[i], new Size(6, 6)));
                        }
                        else
                            g.FillEllipse(Brushes.Red, new RectangleF(p[i], new Size(4, 4)));
                    }
                }
                else if (VradioButton3.Checked)
                {
                    for (int i = 0; i < count; ++i)
                    {
                        if (points[i, 1] == minimum)
                        {
                            g.FillEllipse(Brushes.Green, new RectangleF(new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(height / (maxY - minY))), new Size(6, 6)));
                        }
                        else
                            g.FillEllipse(Brushes.Red, new RectangleF(new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(height / (maxY - minY))), new Size(4, 4)));
                    }
                }
            }

            if (VradioButton5.Checked)
            {
                for (int i = 0; i < count; ++i)
                {
                    PointF poss = new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(Math.Abs(minY) * height / (maxY - minY) + points[i, 1] * height / (maxY - minY + 0.1)));
                    p[i] = poss;
                }
                if (VradioButton2.Checked)
                {
                    for (int i = 0; i < count; ++i)
                    {
                        if (points[i, 1] == minimum)
                        {
                            g.FillEllipse(Brushes.Green, new RectangleF(p[i], new Size(6, 6)));
                        }
                        else
                            g.FillEllipse(Brushes.Red, new RectangleF(p[i], new Size(4, 4)));
                    }
                }
                else if (VradioButton3.Checked)
                {
                    for (int i = 0; i < count; ++i)
                    {
                        if (points[i, 1] == minimum)
                        {
                            g.FillEllipse(Brushes.Green, new RectangleF(new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(height / 50)), new Size(6, 6)));
                        }
                        else
                            g.FillEllipse(Brushes.Red, new RectangleF(new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(height / 50)), new Size(4, 4)));
                    }
                }
            }

            g.DrawLines(gr, p);
        }


    }
}