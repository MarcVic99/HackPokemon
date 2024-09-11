namespace SuperGen
{
    partial class SpriteViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpriteViewer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animateSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.framesPerSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteBox = new SpriteStrip_Render.AnimatedSprite();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSpriteToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(296, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openSpriteToolStripMenuItem
            // 
            this.openSpriteToolStripMenuItem.Name = "openSpriteToolStripMenuItem";
            this.openSpriteToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.openSpriteToolStripMenuItem.Text = "Load Sprite";
            this.openSpriteToolStripMenuItem.Click += new System.EventHandler(this.openSpriteToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animateSpriteToolStripMenuItem,
            this.framesPerSecondToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // animateSpriteToolStripMenuItem
            // 
            this.animateSpriteToolStripMenuItem.CheckOnClick = true;
            this.animateSpriteToolStripMenuItem.Name = "animateSpriteToolStripMenuItem";
            this.animateSpriteToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.animateSpriteToolStripMenuItem.Text = "Animate sprite";
            this.animateSpriteToolStripMenuItem.Click += new System.EventHandler(this.animateSpriteToolStripMenuItem_Click);
            // 
            // framesPerSecondToolStripMenuItem
            // 
            this.framesPerSecondToolStripMenuItem.Name = "framesPerSecondToolStripMenuItem";
            this.framesPerSecondToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.framesPerSecondToolStripMenuItem.Text = "Frames Per Second";
            this.framesPerSecondToolStripMenuItem.Click += new System.EventHandler(this.framesPerSecondToolStripMenuItem_Click);
            // 
            // spriteBox
            // 
            this.spriteBox.BackColor = System.Drawing.Color.Transparent;
            this.spriteBox.FrameRate = 100;
            this.spriteBox.Location = new System.Drawing.Point(314, 257);
            this.spriteBox.Name = "spriteBox";
            this.spriteBox.Size = new System.Drawing.Size(150, 150);
            this.spriteBox.Sprite = null;
            this.spriteBox.TabIndex = 1;
            // 
            // SpriteViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 231);
            this.Controls.Add(this.spriteBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(255, 39);
            this.Name = "SpriteViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sprite Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animateSpriteToolStripMenuItem;
        private SpriteStrip_Render.AnimatedSprite spriteBox;
        private System.Windows.Forms.ToolStripMenuItem framesPerSecondToolStripMenuItem;
    }
}