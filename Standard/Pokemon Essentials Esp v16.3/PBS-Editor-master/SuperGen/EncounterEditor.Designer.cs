namespace SuperGen
{
    partial class EncounterEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncounterEditor));
            this.mapBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.densityGrass = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.densityCaves = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.densitySurfing = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amountOfEncounterMethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overwriteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openencounterstxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.encBox = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.species = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.level1 = new System.Windows.Forms.NumericUpDown();
            this.level2 = new System.Windows.Forms.NumericUpDown();
            this.methodsBox = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.addMethodBtn = new System.Windows.Forms.Button();
            this.removeMethodBtn = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.method = new System.Windows.Forms.ComboBox();
            this.per1 = new System.Windows.Forms.Label();
            this.per2 = new System.Windows.Forms.Label();
            this.per3 = new System.Windows.Forms.Label();
            this.per4 = new System.Windows.Forms.Label();
            this.per5 = new System.Windows.Forms.Label();
            this.per6 = new System.Windows.Forms.Label();
            this.per7 = new System.Windows.Forms.Label();
            this.per8 = new System.Windows.Forms.Label();
            this.per9 = new System.Windows.Forms.Label();
            this.per10 = new System.Windows.Forms.Label();
            this.per11 = new System.Windows.Forms.Label();
            this.per12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.densityGrass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityCaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.densitySurfing)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.level1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.level2)).BeginInit();
            this.SuspendLayout();
            // 
            // mapBox
            // 
            this.mapBox.FormattingEnabled = true;
            this.mapBox.Location = new System.Drawing.Point(5, 29);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(120, 303);
            this.mapBox.TabIndex = 0;
            this.mapBox.SelectedIndexChanged += new System.EventHandler(this.encounterBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Density:";
            // 
            // densityGrass
            // 
            this.densityGrass.Location = new System.Drawing.Point(172, 66);
            this.densityGrass.Name = "densityGrass";
            this.densityGrass.Size = new System.Drawing.Size(41, 20);
            this.densityGrass.TabIndex = 6;
            this.densityGrass.ValueChanged += new System.EventHandler(this.densityGrass_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Grass";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Caves";
            // 
            // densityCaves
            // 
            this.densityCaves.Location = new System.Drawing.Point(219, 66);
            this.densityCaves.Name = "densityCaves";
            this.densityCaves.Size = new System.Drawing.Size(41, 20);
            this.densityCaves.TabIndex = 8;
            this.densityCaves.ValueChanged += new System.EventHandler(this.densityCaves_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Surfing";
            // 
            // densitySurfing
            // 
            this.densitySurfing.Location = new System.Drawing.Point(266, 66);
            this.densitySurfing.Name = "densitySurfing";
            this.densitySurfing.Size = new System.Drawing.Size(41, 20);
            this.densitySurfing.TabIndex = 10;
            this.densitySurfing.ValueChanged += new System.EventHandler(this.densitySurfing_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.moreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(397, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapIDToolStripMenuItem,
            this.mapNameToolStripMenuItem,
            this.amountOfEncounterMethodsToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // mapIDToolStripMenuItem
            // 
            this.mapIDToolStripMenuItem.Name = "mapIDToolStripMenuItem";
            this.mapIDToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.mapIDToolStripMenuItem.Text = "Map ID";
            this.mapIDToolStripMenuItem.Click += new System.EventHandler(this.mapIDToolStripMenuItem_Click);
            // 
            // mapNameToolStripMenuItem
            // 
            this.mapNameToolStripMenuItem.Name = "mapNameToolStripMenuItem";
            this.mapNameToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.mapNameToolStripMenuItem.Text = "Map Name";
            this.mapNameToolStripMenuItem.Click += new System.EventHandler(this.mapNameToolStripMenuItem_Click);
            // 
            // amountOfEncounterMethodsToolStripMenuItem
            // 
            this.amountOfEncounterMethodsToolStripMenuItem.Name = "amountOfEncounterMethodsToolStripMenuItem";
            this.amountOfEncounterMethodsToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.amountOfEncounterMethodsToolStripMenuItem.Text = "Amount of Encounter Methods";
            this.amountOfEncounterMethodsToolStripMenuItem.Click += new System.EventHandler(this.amountOfEncounterMethodsToolStripMenuItem_Click);
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
            // selectedToolStripMenuItem
            // 
            this.selectedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem1,
            this.exportToolStripMenuItem1});
            this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
            this.selectedToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.selectedToolStripMenuItem.Text = "Selected";
            // 
            // generateToolStripMenuItem1
            // 
            this.generateToolStripMenuItem1.Name = "generateToolStripMenuItem1";
            this.generateToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.generateToolStripMenuItem1.Text = "Generate";
            this.generateToolStripMenuItem1.Click += new System.EventHandler(this.generateToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.exportToolStripMenuItem1.Text = "Export";
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem2,
            this.exportToolStripMenuItem,
            this.overwriteToolStripMenuItem1});
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.allToolStripMenuItem.Text = "All";
            // 
            // generateToolStripMenuItem2
            // 
            this.generateToolStripMenuItem2.Name = "generateToolStripMenuItem2";
            this.generateToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.generateToolStripMenuItem2.Text = "Generate";
            this.generateToolStripMenuItem2.Click += new System.EventHandler(this.generateToolStripMenuItem2_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // overwriteToolStripMenuItem1
            // 
            this.overwriteToolStripMenuItem1.Name = "overwriteToolStripMenuItem1";
            this.overwriteToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.overwriteToolStripMenuItem1.Text = "Overwrite";
            this.overwriteToolStripMenuItem1.Click += new System.EventHandler(this.overwriteToolStripMenuItem1_Click);
            // 
            // moreToolStripMenuItem
            // 
            this.moreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openencounterstxtToolStripMenuItem,
            this.reloadDataToolStripMenuItem});
            this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            this.moreToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.moreToolStripMenuItem.Text = "More";
            // 
            // openencounterstxtToolStripMenuItem
            // 
            this.openencounterstxtToolStripMenuItem.Name = "openencounterstxtToolStripMenuItem";
            this.openencounterstxtToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.openencounterstxtToolStripMenuItem.Text = "Open encounters.txt";
            this.openencounterstxtToolStripMenuItem.Click += new System.EventHandler(this.openencounterstxtToolStripMenuItem_Click);
            // 
            // reloadDataToolStripMenuItem
            // 
            this.reloadDataToolStripMenuItem.Name = "reloadDataToolStripMenuItem";
            this.reloadDataToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.reloadDataToolStripMenuItem.Text = "Reload Data";
            this.reloadDataToolStripMenuItem.Click += new System.EventHandler(this.reloadDataToolStripMenuItem_Click);
            // 
            // mapName
            // 
            this.mapName.Location = new System.Drawing.Point(188, 26);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(86, 20);
            this.mapName.TabIndex = 15;
            this.mapName.TextChanged += new System.EventHandler(this.mapName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Map Name:";
            // 
            // encBox
            // 
            this.encBox.FormattingEnabled = true;
            this.encBox.Location = new System.Drawing.Point(271, 108);
            this.encBox.Name = "encBox";
            this.encBox.Size = new System.Drawing.Size(120, 160);
            this.encBox.TabIndex = 16;
            this.encBox.SelectedIndexChanged += new System.EventHandler(this.encBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 277);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Species:";
            // 
            // species
            // 
            this.species.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.species.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.species.FormattingEnabled = true;
            this.species.Location = new System.Drawing.Point(271, 291);
            this.species.Name = "species";
            this.species.Size = new System.Drawing.Size(120, 21);
            this.species.TabIndex = 21;
            this.species.SelectedIndexChanged += new System.EventHandler(this.species_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(265, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Level:";
            // 
            // level1
            // 
            this.level1.Location = new System.Drawing.Point(299, 315);
            this.level1.Name = "level1";
            this.level1.Size = new System.Drawing.Size(37, 20);
            this.level1.TabIndex = 24;
            this.level1.ValueChanged += new System.EventHandler(this.level1_ValueChanged);
            // 
            // level2
            // 
            this.level2.Location = new System.Drawing.Point(353, 315);
            this.level2.Name = "level2";
            this.level2.Size = new System.Drawing.Size(37, 20);
            this.level2.TabIndex = 25;
            this.level2.ValueChanged += new System.EventHandler(this.level2_ValueChanged);
            // 
            // methodsBox
            // 
            this.methodsBox.FormattingEnabled = true;
            this.methodsBox.Location = new System.Drawing.Point(134, 108);
            this.methodsBox.Name = "methodsBox";
            this.methodsBox.Size = new System.Drawing.Size(95, 134);
            this.methodsBox.TabIndex = 49;
            this.methodsBox.SelectedIndexChanged += new System.EventHandler(this.methodsBox_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(132, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Encounter Methods";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Encounters";
            // 
            // addMethodBtn
            // 
            this.addMethodBtn.Location = new System.Drawing.Point(134, 244);
            this.addMethodBtn.Name = "addMethodBtn";
            this.addMethodBtn.Size = new System.Drawing.Size(95, 23);
            this.addMethodBtn.TabIndex = 52;
            this.addMethodBtn.Text = "Add Method";
            this.addMethodBtn.UseVisualStyleBackColor = true;
            this.addMethodBtn.Click += new System.EventHandler(this.addMethodBtn_Click);
            // 
            // removeMethodBtn
            // 
            this.removeMethodBtn.Location = new System.Drawing.Point(134, 267);
            this.removeMethodBtn.Name = "removeMethodBtn";
            this.removeMethodBtn.Size = new System.Drawing.Size(95, 23);
            this.removeMethodBtn.TabIndex = 53;
            this.removeMethodBtn.Text = "Remove Method";
            this.removeMethodBtn.UseVisualStyleBackColor = true;
            this.removeMethodBtn.Click += new System.EventHandler(this.removeMethodBtn_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(159, 297);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(46, 13);
            this.label.TabIndex = 54;
            this.label.Text = "Method:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(340, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 56;
            this.label10.Text = "-";
            // 
            // method
            // 
            this.method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.method.FormattingEnabled = true;
            this.method.Location = new System.Drawing.Point(134, 312);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(94, 21);
            this.method.TabIndex = 57;
            // 
            // per1
            // 
            this.per1.AutoSize = true;
            this.per1.Location = new System.Drawing.Point(242, 110);
            this.per1.Name = "per1";
            this.per1.Size = new System.Drawing.Size(27, 13);
            this.per1.TabIndex = 58;
            this.per1.Text = "20%";
            // 
            // per2
            // 
            this.per2.AutoSize = true;
            this.per2.Location = new System.Drawing.Point(242, 123);
            this.per2.Name = "per2";
            this.per2.Size = new System.Drawing.Size(27, 13);
            this.per2.TabIndex = 59;
            this.per2.Text = "20%";
            // 
            // per3
            // 
            this.per3.AutoSize = true;
            this.per3.Location = new System.Drawing.Point(242, 136);
            this.per3.Name = "per3";
            this.per3.Size = new System.Drawing.Size(27, 13);
            this.per3.TabIndex = 60;
            this.per3.Text = "20%";
            // 
            // per4
            // 
            this.per4.AutoSize = true;
            this.per4.Location = new System.Drawing.Point(242, 149);
            this.per4.Name = "per4";
            this.per4.Size = new System.Drawing.Size(27, 13);
            this.per4.TabIndex = 61;
            this.per4.Text = "20%";
            // 
            // per5
            // 
            this.per5.AutoSize = true;
            this.per5.Location = new System.Drawing.Point(242, 162);
            this.per5.Name = "per5";
            this.per5.Size = new System.Drawing.Size(27, 13);
            this.per5.TabIndex = 62;
            this.per5.Text = "20%";
            // 
            // per6
            // 
            this.per6.AutoSize = true;
            this.per6.Location = new System.Drawing.Point(242, 175);
            this.per6.Name = "per6";
            this.per6.Size = new System.Drawing.Size(27, 13);
            this.per6.TabIndex = 63;
            this.per6.Text = "20%";
            // 
            // per7
            // 
            this.per7.AutoSize = true;
            this.per7.Location = new System.Drawing.Point(242, 188);
            this.per7.Name = "per7";
            this.per7.Size = new System.Drawing.Size(27, 13);
            this.per7.TabIndex = 64;
            this.per7.Text = "20%";
            // 
            // per8
            // 
            this.per8.AutoSize = true;
            this.per8.Location = new System.Drawing.Point(242, 201);
            this.per8.Name = "per8";
            this.per8.Size = new System.Drawing.Size(27, 13);
            this.per8.TabIndex = 65;
            this.per8.Text = "20%";
            // 
            // per9
            // 
            this.per9.AutoSize = true;
            this.per9.Location = new System.Drawing.Point(242, 214);
            this.per9.Name = "per9";
            this.per9.Size = new System.Drawing.Size(27, 13);
            this.per9.TabIndex = 66;
            this.per9.Text = "20%";
            // 
            // per10
            // 
            this.per10.AutoSize = true;
            this.per10.Location = new System.Drawing.Point(242, 228);
            this.per10.Name = "per10";
            this.per10.Size = new System.Drawing.Size(27, 13);
            this.per10.TabIndex = 67;
            this.per10.Text = "20%";
            // 
            // per11
            // 
            this.per11.AutoSize = true;
            this.per11.Location = new System.Drawing.Point(242, 241);
            this.per11.Name = "per11";
            this.per11.Size = new System.Drawing.Size(27, 13);
            this.per11.TabIndex = 68;
            this.per11.Text = "20%";
            // 
            // per12
            // 
            this.per12.AutoSize = true;
            this.per12.Location = new System.Drawing.Point(242, 254);
            this.per12.Name = "per12";
            this.per12.Size = new System.Drawing.Size(27, 13);
            this.per12.TabIndex = 69;
            this.per12.Text = "20%";
            // 
            // EncounterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 340);
            this.Controls.Add(this.per12);
            this.Controls.Add(this.per11);
            this.Controls.Add(this.per10);
            this.Controls.Add(this.per9);
            this.Controls.Add(this.per8);
            this.Controls.Add(this.per7);
            this.Controls.Add(this.per6);
            this.Controls.Add(this.per5);
            this.Controls.Add(this.per4);
            this.Controls.Add(this.per3);
            this.Controls.Add(this.per2);
            this.Controls.Add(this.per1);
            this.Controls.Add(this.method);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label);
            this.Controls.Add(this.removeMethodBtn);
            this.Controls.Add(this.addMethodBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.methodsBox);
            this.Controls.Add(this.level2);
            this.Controls.Add(this.level1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.species);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.encBox);
            this.Controls.Add(this.mapName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.densitySurfing);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.densityCaves);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.densityGrass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(413, 379);
            this.MinimumSize = new System.Drawing.Size(413, 379);
            this.Name = "EncounterEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encounter Editor";
            this.Load += new System.EventHandler(this.EncounterEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.densityGrass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityCaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.densitySurfing)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.level1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.level2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox mapBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown densityGrass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown densityCaves;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown densitySurfing;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openencounterstxtToolStripMenuItem;
        private System.Windows.Forms.TextBox mapName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overwriteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reloadDataToolStripMenuItem;
        private System.Windows.Forms.ListBox encBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox species;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown level1;
        private System.Windows.Forms.NumericUpDown level2;
        private System.Windows.Forms.ListBox methodsBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addMethodBtn;
        private System.Windows.Forms.Button removeMethodBtn;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox method;
        private System.Windows.Forms.Label per1;
        private System.Windows.Forms.Label per2;
        private System.Windows.Forms.Label per3;
        private System.Windows.Forms.Label per4;
        private System.Windows.Forms.Label per5;
        private System.Windows.Forms.Label per6;
        private System.Windows.Forms.Label per7;
        private System.Windows.Forms.Label per8;
        private System.Windows.Forms.Label per9;
        private System.Windows.Forms.Label per10;
        private System.Windows.Forms.Label per11;
        private System.Windows.Forms.Label per12;
        private System.Windows.Forms.ToolStripMenuItem mapIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amountOfEncounterMethodsToolStripMenuItem;
    }
}