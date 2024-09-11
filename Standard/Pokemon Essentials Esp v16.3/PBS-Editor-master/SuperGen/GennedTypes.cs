using SuperGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiscGen
{
    public partial class GennedTypes : Form
    {
        public string txt = null;

        public GennedTypes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txt);
        }

        private void GennedTypes_Load(object sender, EventArgs e)
        {
            pbsTxt.Text = txt;
        }
    }
}
