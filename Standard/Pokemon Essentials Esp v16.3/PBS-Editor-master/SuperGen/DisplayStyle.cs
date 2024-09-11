using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGen
{
    public partial class DisplayStyle : Form
    {
        public bool applied = false;
        public string type = "1";
        public string name = "2";
        public string id = "0";

        public DisplayStyle()
        {
            InitializeComponent();
            numericUpDown3.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            type = numericUpDown1.Value.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            name = numericUpDown2.Value.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            id = numericUpDown3.Value.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                type = "0";
                numericUpDown1.Enabled = false;
                numericUpDown1.ResetText();
            }
            else
            {
                numericUpDown1.Enabled = true;
                numericUpDown1.Value = 1;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                name = "0";
                numericUpDown2.Enabled = false;
                numericUpDown2.ResetText();
            }
            else
            {
                numericUpDown2.Enabled = true;
                numericUpDown2.Value = 1;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                id = "0";
                numericUpDown3.Enabled = false;
                numericUpDown3.ResetText();
            }
            else
            {
                numericUpDown3.Enabled = true;
                numericUpDown3.Value = 2;
                numericUpDown3.Value = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type == "0" && name == "0" && id != "0" ||
                type == "0" && name != "0" && id == "0" ||
                type != "0" && name == "0" && id == "0" ||
                type != "0" && name != "0" && id == "0")
            {
                applied = true;
                Close();
            }
            else if (type == name || type == id || name == id)
            {
                MessageBox.Show("You cannot use the same number multiple times!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (type == "0" && name == "0" && id == "0")
                {
                    MessageBox.Show("You have to choose at least one visible variable!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    applied = true;
                    Close();
                }
            }
        }

        private void DisplayStyle_Load(object sender, EventArgs e)
        {

        }
    }
}
