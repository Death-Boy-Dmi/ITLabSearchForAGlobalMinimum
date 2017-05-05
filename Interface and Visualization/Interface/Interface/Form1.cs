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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
