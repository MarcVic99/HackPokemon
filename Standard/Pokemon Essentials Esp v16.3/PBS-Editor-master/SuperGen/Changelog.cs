using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using static SuperGen.SuperForm;

namespace SuperGen
{
    public partial class Changelog : Form
    {
        public Changelog()
        {
            InitializeComponent();
        }

        private void DocuForm_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            Stream stream = wc.OpenRead(changelogUrl);
            using (StreamReader sr = new StreamReader(stream)) { richTextBox1.Text = sr.ReadToEnd(); } ;
        }
    }
}
