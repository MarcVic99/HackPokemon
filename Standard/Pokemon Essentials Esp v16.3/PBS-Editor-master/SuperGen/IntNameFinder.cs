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
    public partial class IntNameFinder : Form
    {
        public static string result = "";
        public static bool btn = false;

        public IntNameFinder()
        {
            InitializeComponent();
            result = "";
            btn = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = textBox1.Text;
            btn = true;
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button1_Click(sender, new EventArgs()); }
            if (e.KeyCode == Keys.Escape) { Close(); }
        }

        private void IntNameFinder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Close(); }
        }
    }
}
