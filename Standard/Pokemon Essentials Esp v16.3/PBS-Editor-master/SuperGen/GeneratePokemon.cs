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

namespace PokeGenerator
{
    public partial class GeneratePokemon : Form
    {
        public string gennedPokemon;

        public GeneratePokemon()
        {
            InitializeComponent();
        }

        private void GeneratePokemon_Load(object sender, EventArgs e)
        {
            pbsLines.Text = gennedPokemon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(gennedPokemon);
        }
    }
}
