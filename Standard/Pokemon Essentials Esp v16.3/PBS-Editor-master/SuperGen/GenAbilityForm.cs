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
    public partial class GenAbilityForm : Form
    {
        public string pbs = null;

        public GenAbilityForm()
        {
            InitializeComponent();
        }

        private void GenAbilityForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = pbs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(pbs);
        }
    }
}
