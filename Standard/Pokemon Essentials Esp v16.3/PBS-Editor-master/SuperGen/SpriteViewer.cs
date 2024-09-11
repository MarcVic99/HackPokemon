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
    public partial class SpriteViewer : Form
    {
        private Image thisImage = null;

        public SpriteViewer()
        {
            InitializeComponent();
        }

        private void openSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose a sprite";
            ofd.InitialDirectory = "Graphics";
            ofd.Filter = "PNG Files (*.png)|*.png|"
                + "All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                thisImage = Image.FromFile(ofd.FileName);
                spriteBox.Sprite = thisImage;
                spriteBox.Frame_Height = thisImage.Height;
                spriteBox.Frame_Width = thisImage.Width;
                spriteBox.FrameRate = 22;
                spriteBox.Height = thisImage.Height;
                spriteBox.Width = thisImage.Width;
                spriteBox.Location = new Point(0, 30);
                Width = thisImage.Width + 16;
                Height = thisImage.Height + 69;
                animateSpriteToolStripMenuItem_Click(sender, e);
            }
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void animateSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (animateSpriteToolStripMenuItem.Checked)
            {
                spriteBox.Frame_Width = spriteBox.Frame_Height;
                Width = spriteBox.Frame_Height + 16;
            }
            else
            {
                spriteBox.Frame_Width = thisImage.Width;
                Width = thisImage.Width + 16;
            }
        }

        private void framesPerSecondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberInput ni = new NumberInput();
            ni.ShowDialog();
            spriteBox.FrameRate = ni.value;
        }
    }
}
