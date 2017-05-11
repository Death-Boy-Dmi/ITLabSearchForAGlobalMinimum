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
        int minX = -10, minY = -10, maxX = 10, maxY = 10, width, height;

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
            double[,] points = new double[(maxX - minX) * 10 + 1, 2];
            PointF[] p = new PointF[(maxX - minX) * 10 + 1];
            alg(points);
            if (VradioButton4.Checked)
            {
                for (int i = 0; i < (maxX - minX) * 10 + 1; ++i)
                {
                    PointF poss = new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(Math.Abs(minY) * height / (maxY - minY) + points[i, 1] * height / (maxY - minY)));
                    p[i] = poss;
                }
                if (VradioButton2.Checked)
                {
                    for (int i = 0; i < (maxX - minX) * 10 + 1; ++i)
                        g.FillEllipse(Brushes.Red, new RectangleF(p[i], new Size(4, 4)));
                }
                else if (VradioButton3.Checked)
                {
                    for (int i = 0; i < (maxX - minX) * 10 + 1; ++i)
                        g.FillEllipse(Brushes.Red, new RectangleF(new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(Math.Abs(minY) * height / (maxY - minY))), new Size(4, 4)));
                }
            }

            if (VradioButton5.Checked)
            {
                for (int i = 0; i < (maxX - minX) * 10 + 1; ++i)
                {
                    PointF poss = new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(Math.Abs(minY) * height / (maxY - minY) + points[i, 1] * height / (maxY - minY + 0.1)));
                    p[i] = poss;
                }
                if (VradioButton2.Checked)
                {
                    for (int i = 0; i < (maxX - minX) * 10 + 1; ++i)
                        g.FillEllipse(Brushes.Red, new RectangleF(p[i], new Size(4, 4)));
                }
                else if (VradioButton3.Checked)
                {
                    for (int i = 0; i < (maxX - minX) * 10 + 1; ++i)
                        g.FillEllipse(Brushes.Red, new RectangleF(new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(height / 50)), new Size(4, 4)));
                }
            }

            g.DrawLines(gr, p);
        }

        private void alg(double[,] points)
        {
            int index = 0;
            for (double i = minX; i <= maxX; i = i + 0.1, ++index)
            {
                points[index, 0] = i;
                points[index, 1] = Math.Sin(i);
            }
        }
    }
}