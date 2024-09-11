namespace SuperGen
{
    partial class TMEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMEditor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTmtxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmBox = new System.Windows.Forms.ListBox();
            this.addTMBtn = new System.Windows.Forms.Button();
            this.removeTMBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tmMoveBox = new System.Windows.Forms.ComboBox();
            this.speciesBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.removeSpeciesBtn = new System.Windows.Forms.Button();
            this.addSpeciesBtn = new System.Windows.Forms.Button();
            this.pokeBox = new System.Windows.Forms.ListBox();
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overwriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem,
            this.moreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(247, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedToolStripMenuItem,
            this.allToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.generateToolStripMenuItem.Text = "Generate";
            // 
            // moreToolStripMenuItem
            // 
            this.moreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTmtxtToolStripMenuItem,
            this.reloadDataToolStripMenuItem});
            this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            this.moreToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.moreToolStripMenuItem.Text = "More";
            // 
            // openTmtxtToolStripMenuItem
            // 
            this.openTmtxtToolStripMenuItem.Name = "openTmtxtToolStripMenuItem";
            this.openTmtxtToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openTmtxtToolStripMenuItem.Text = "Open tm.txt";
            this.openTmtxtToolStripMenuItem.Click += new System.EventHandler(this.openTmtxtToolStripMenuItem_Click);
            // 
            // reloadDataToolStripMenuItem
            // 
            this.reloadDataToolStripMenuItem.Name = "reloadDataToolStripMenuItem";
            this.reloadDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reloadDataToolStripMenuItem.Text = "Reload data";
            this.reloadDataToolStripMenuItem.Click += new System.EventHandler(this.reloadDataToolStripMenuItem_Click);
            // 
            // tmBox
            // 
            this.tmBox.FormattingEnabled = true;
            this.tmBox.Location = new System.Drawing.Point(6, 27);
            this.tmBox.Name = "tmBox";
            this.tmBox.Size = new System.Drawing.Size(114, 355);
            this.tmBox.TabIndex = 1;
            this.tmBox.SelectedIndexChanged += new System.EventHandler(this.tmBox_SelectedIndexChanged);
            // 
            // addTMBtn
            // 
            this.addTMBtn.Location = new System.Drawing.Point(6, 384);
            this.addTMBtn.Name = "addTMBtn";
            this.addTMBtn.Size = new System.Drawing.Size(114, 23);
            this.addTMBtn.TabIndex = 2;
            this.addTMBtn.Text = "Add Move";
            this.addTMBtn.UseVisualStyleBackColor = true;
            this.addTMBtn.Click += new System.EventHandler(this.addTMBtn_Click);
            // 
            // removeTMBtn
            // 
            this.removeTMBtn.Location = new System.Drawing.Point(6, 407);
            this.removeTMBtn.Name = "removeTMBtn";
            this.removeTMBtn.Size = new System.Drawing.Size(114, 23);
            this.removeTMBtn.TabIndex = 3;
            this.removeTMBtn.Text = "Remove Move";
            this.removeTMBtn.UseVisualStyleBackColor = true;
            this.removeTMBtn.Click += new System.EventHandler(this.removeTMBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Move:";
            // 
            // tmMoveBox
            // 
            this.tmMoveBox.FormattingEnabled = true;
            this.tmMoveBox.Location = new System.Drawing.Point(6, 449);
            this.tmMoveBox.Name = "tmMoveBox";
            this.tmMoveBox.Size = new System.Drawing.Size(114, 21);
            this.tmMoveBox.TabIndex = 5;
            // 
            // speciesBox
            // 
            this.speciesBox.FormattingEnabled = true;
            this.speciesBox.Location = new System.Drawing.Point(126, 449);
            this.speciesBox.Name = "speciesBox";
            this.speciesBox.Size = new System.Drawing.Size(114, 21);
            this.speciesBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Species:";
            // 
            // removeSpeciesBtn
            // 
            this.removeSpeciesBtn.Location = new System.Drawing.Point(126, 407);
            this.removeSpeciesBtn.Name = "removeSpeciesBtn";
            this.removeSpeciesBtn.Size = new System.Drawing.Size(114, 23);
            this.removeSpeciesBtn.TabIndex = 8;
            this.removeSpeciesBtn.Text = "Remove Species";
            this.removeSpeciesBtn.UseVisualStyleBackColor = true;
            this.removeSpeciesBtn.Click += new System.EventHandler(this.removeSpeciesBtn_Click);
            // 
            // addSpeciesBtn
            // 
            this.addSpeciesBtn.Location = new System.Drawing.Point(126, 384);
            this.addSpeciesBtn.Name = "addSpeciesBtn";
            this.addSpeciesBtn.Size = new System.Drawing.Size(114, 23);
            this.addSpeciesBtn.TabIndex = 7;
            this.addSpeciesBtn.Text = "Add Species";
            this.addSpeciesBtn.UseVisualStyleBackColor = true;
            this.addSpeciesBtn.Click += new System.EventHandler(this.addSpeciesBtn_Click);
            // 
            // pokeBox
            // 
            this.pokeBox.FormattingEnabled = true;
            this.pokeBox.Location = new System.Drawing.Point(126, 27);
            this.pokeBox.Name = "pokeBox";
            this.pokeBox.Size = new System.Drawing.Size(114, 355);
            this.pokeBox.TabIndex = 6;
            // 
            // selectedToolStripMenuItem
            // 
            this.selectedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem2,
            this.exportToolStripMenuItem1});
            this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
            this.selectedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.selectedToolStripMenuItem.Text = "Selected";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem1,
            this.exportToolStripMenuItem,
            this.overwriteToolStripMenuItem});
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.allToolStripMenuItem.Text = "All";
            // 
            // generateToolStripMenuItem1
            // 
            this.generateToolStripMenuItem1.Name = "generateToolStripMenuItem1";
            this.generateToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.generateToolStripMenuItem1.Text = "Generate";
            this.generateToolStripMenuItem1.Click += new System.EventHandler(this.generateToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // overwriteToolStripMenuItem
            // 
            this.overwriteToolStripMenuItem.Name = "overwriteToolStripMenuItem";
            this.overwriteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.overwriteToolStripMenuItem.Text = "Overwrite";
            this.overwriteToolStripMenuItem.Click += new System.EventHandler(this.overwriteToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem2
            // 
            this.generateToolStripMenuItem2.Name = "generateToolStripMenuItem2";
            this.generateToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.generateToolStripMenuItem2.Text = "Generate";
            this.generateToolStripMenuItem2.Click += new System.EventHandler(this.generateToolStripMenuItem2_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem1.Text = "Export";
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
            // 
            // TMEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 478);
            this.Controls.Add(this.speciesBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.removeSpeciesBtn);
            this.Controls.Add(this.addSpeciesBtn);
            this.Controls.Add(this.pokeBox);
            this.Controls.Add(this.tmMoveBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeTMBtn);
            this.Controls.Add(this.addTMBtn);
            this.Controls.Add(this.tmBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TMEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TM Editor";
            this.Load += new System.EventHandler(this.TMEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTmtxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadDataToolStripMenuItem;
        private System.Windows.Forms.ListBox tmBox;
        private System.Windows.Forms.Button addTMBtn;
        private System.Windows.Forms.Button removeTMBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tmMoveBox;
        private System.Windows.Forms.ComboBox speciesBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeSpeciesBtn;
        private System.Windows.Forms.Button addSpeciesBtn;
        private System.Windows.Forms.ListBox pokeBox;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overwriteToolStripMenuItem;
    }
}