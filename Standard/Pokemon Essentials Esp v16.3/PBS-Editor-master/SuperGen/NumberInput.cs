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
    public partial class NumberInput : Form
    {
        public int value = 0;
        public bool btn = false;

        public NumberInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            value = (int) numericUpDown1.Value;
            btn = true;
            Close();
        }
    }
}
