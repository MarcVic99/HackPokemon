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
    public partial class NumberBetween : Form
    {
        public int value1 = 0;
        public int value2 = 2000000000;
        public bool btn = false;

        public NumberBetween()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            value1 = (int)numericUpDown1.Value;
            value2 = (int)numericUpDown2.Value;
            btn = true;
            Close();
        }
    }
}
