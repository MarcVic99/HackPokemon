namespace MiscGen
{
    partial class TypeGen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeGen));
            this.typeBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.intNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.NumericUpDown();
            this.wnessBox = new System.Windows.Forms.ListBox();
            this.addWnessBtn = new System.Windows.Forms.Button();
            this.removeWnessBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.WnessTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.removeResBtn = new System.Windows.Forms.Button();
            this.addResBtn = new System.Windows.Forms.Button();
            this.resBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ResTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.removeSuperBtn = new System.Windows.Forms.Button();
            this.addSuperBtn = new System.Windows.Forms.Button();
            this.superBox = new System.Windows.Forms.ListBox();
            this.SuperTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.imBox = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.removeImmuneBtn = new System.Windows.Forms.Button();
            this.addImmuneBtn = new System.Windows.Forms.Button();
            this.ImTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.wnessNameBox = new System.Windows.Forms.TextBox();
            this.resNameBox = new System.Windows.Forms.TextBox();
            this.superNameBox = new System.Windows.Forms.TextBox();
            this.immuneNameBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internalNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byWeaknessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byResistancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bySuperEffectivenessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byImmunitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.overwriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTypestxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findInternalNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isSpecialType = new System.Windows.Forms.CheckBox();
            this.specialTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.idTip = new System.Windows.Forms.ToolTip(this.components);
            this.nameTip = new System.Windows.Forms.ToolTip(this.components);
            this.intNameTip = new System.Windows.Forms.ToolTip(this.components);
            this.typeTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.idBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(12, 25);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(74, 238);
            this.typeBox.TabIndex = 0;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(152, 46);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 4;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // intNameBox
            // 
            this.intNameBox.Location = new System.Drawing.Point(152, 71);
            this.intNameBox.Name = "intNameBox";
            this.intNameBox.Size = new System.Drawing.Size(100, 20);
            this.intNameBox.TabIndex = 6;
            this.intNameBox.TextChanged += new System.EventHandler(this.intNameBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Int. Name:";
            this.label3.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(152, 22);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(41, 20);
            this.idBox.TabIndex = 7;
            this.idBox.ValueChanged += new System.EventHandler(this.idBox_ValueChanged);
            // 
            // wnessBox
            // 
            this.wnessBox.FormattingEnabled = true;
            this.wnessBox.Location = new System.Drawing.Point(119, 120);
            this.wnessBox.Name = "wnessBox";
            this.wnessBox.Size = new System.Drawing.Size(74, 95);
            this.wnessBox.TabIndex = 8;
            // 
            // addWnessBtn
            // 
            this.addWnessBtn.Location = new System.Drawing.Point(119, 218);
            this.addWnessBtn.Name = "addWnessBtn";
            this.addWnessBtn.Size = new System.Drawing.Size(74, 23);
            this.addWnessBtn.TabIndex = 9;
            this.addWnessBtn.Text = "Add";
            this.addWnessBtn.UseVisualStyleBackColor = true;
            this.addWnessBtn.Click += new System.EventHandler(this.addWnessBtn_Click);
            // 
            // removeWnessBtn
            // 
            this.removeWnessBtn.Location = new System.Drawing.Point(119, 245);
            this.removeWnessBtn.Name = "removeWnessBtn";
            this.removeWnessBtn.Size = new System.Drawing.Size(74, 23);
            this.removeWnessBtn.TabIndex = 10;
            this.removeWnessBtn.Text = "Remove";
            this.removeWnessBtn.UseVisualStyleBackColor = true;
            this.removeWnessBtn.Click += new System.EventHandler(this.removeWnessBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Type:";
            this.label4.MouseHover += new System.EventHandler(this.label4_MouseHover);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Weaknesses";
            this.label5.MouseHover += new System.EventHandler(this.label5_MouseHover);
            // 
            // WnessTooltip
            // 
            this.WnessTooltip.AutoPopDelay = 5000;
            this.WnessTooltip.InitialDelay = 50;
            this.WnessTooltip.ReshowDelay = 10;
            this.WnessTooltip.ShowAlways = true;
            this.WnessTooltip.ToolTipTitle = "Weakness";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Type:";
            this.label6.MouseHover += new System.EventHandler(this.label6_MouseHover);
            // 
            // removeResBtn
            // 
            this.removeResBtn.Location = new System.Drawing.Point(245, 245);
            this.removeResBtn.Name = "removeResBtn";
            this.removeResBtn.Size = new System.Drawing.Size(74, 23);
            this.removeResBtn.TabIndex = 17;
            this.removeResBtn.Text = "Remove";
            this.removeResBtn.UseVisualStyleBackColor = true;
            this.removeResBtn.Click += new System.EventHandler(this.removeResBtn_Click);
            // 
            // addResBtn
            // 
            this.addResBtn.Location = new System.Drawing.Point(245, 218);
            this.addResBtn.Name = "addResBtn";
            this.addResBtn.Size = new System.Drawing.Size(74, 23);
            this.addResBtn.TabIndex = 16;
            this.addResBtn.Text = "Add";
            this.addResBtn.UseVisualStyleBackColor = true;
            this.addResBtn.Click += new System.EventHandler(this.addResBtn_Click);
            // 
            // resBox
            // 
            this.resBox.FormattingEnabled = true;
            this.resBox.Location = new System.Drawing.Point(245, 120);
            this.resBox.Name = "resBox";
            this.resBox.Size = new System.Drawing.Size(74, 95);
            this.resBox.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Resistances";
            this.label7.MouseHover += new System.EventHandler(this.label7_MouseHover);
            // 
            // ResTooltip
            // 
            this.ResTooltip.AutoPopDelay = 5000;
            this.ResTooltip.InitialDelay = 50;
            this.ResTooltip.ReshowDelay = 10;
            this.ResTooltip.ShowAlways = true;
            this.ResTooltip.ToolTipTitle = "Resistance";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(347, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Super Effective Against";
            this.label8.MouseHover += new System.EventHandler(this.label8_MouseHover);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(340, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Type:";
            this.label9.MouseHover += new System.EventHandler(this.label9_MouseHover);
            // 
            // removeSuperBtn
            // 
            this.removeSuperBtn.Location = new System.Drawing.Point(372, 245);
            this.removeSuperBtn.Name = "removeSuperBtn";
            this.removeSuperBtn.Size = new System.Drawing.Size(74, 23);
            this.removeSuperBtn.TabIndex = 23;
            this.removeSuperBtn.Text = "Remove";
            this.removeSuperBtn.UseVisualStyleBackColor = true;
            this.removeSuperBtn.Click += new System.EventHandler(this.removeSuperBtn_Click);
            // 
            // addSuperBtn
            // 
            this.addSuperBtn.Location = new System.Drawing.Point(372, 218);
            this.addSuperBtn.Name = "addSuperBtn";
            this.addSuperBtn.Size = new System.Drawing.Size(74, 23);
            this.addSuperBtn.TabIndex = 22;
            this.addSuperBtn.Text = "Add";
            this.addSuperBtn.UseVisualStyleBackColor = true;
            this.addSuperBtn.Click += new System.EventHandler(this.addSuperBtn_Click);
            // 
            // superBox
            // 
            this.superBox.FormattingEnabled = true;
            this.superBox.Location = new System.Drawing.Point(372, 120);
            this.superBox.Name = "superBox";
            this.superBox.Size = new System.Drawing.Size(74, 95);
            this.superBox.TabIndex = 21;
            // 
            // SuperTooltip
            // 
            this.SuperTooltip.AutoPopDelay = 5000;
            this.SuperTooltip.InitialDelay = 50;
            this.SuperTooltip.ReshowDelay = 10;
            this.SuperTooltip.ShowAlways = true;
            this.SuperTooltip.ToolTipTitle = "Super Effectiveness";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 290);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(74, 23);
            this.button5.TabIndex = 28;
            this.button5.Text = "Remove";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 266);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(74, 23);
            this.button6.TabIndex = 27;
            this.button6.Text = "Add";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // imBox
            // 
            this.imBox.FormattingEnabled = true;
            this.imBox.Location = new System.Drawing.Point(263, 42);
            this.imBox.Name = "imBox";
            this.imBox.Size = new System.Drawing.Size(74, 56);
            this.imBox.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(272, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Immunities";
            this.label10.MouseHover += new System.EventHandler(this.label10_MouseHover);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(427, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Type";
            this.label11.MouseHover += new System.EventHandler(this.label11_MouseHover);
            // 
            // removeImmuneBtn
            // 
            this.removeImmuneBtn.Location = new System.Drawing.Point(343, 50);
            this.removeImmuneBtn.Name = "removeImmuneBtn";
            this.removeImmuneBtn.Size = new System.Drawing.Size(74, 23);
            this.removeImmuneBtn.TabIndex = 32;
            this.removeImmuneBtn.Text = "Remove";
            this.removeImmuneBtn.UseVisualStyleBackColor = true;
            this.removeImmuneBtn.Click += new System.EventHandler(this.removeImmuneBtn_Click);
            // 
            // addImmuneBtn
            // 
            this.addImmuneBtn.Location = new System.Drawing.Point(343, 25);
            this.addImmuneBtn.Name = "addImmuneBtn";
            this.addImmuneBtn.Size = new System.Drawing.Size(74, 23);
            this.addImmuneBtn.TabIndex = 31;
            this.addImmuneBtn.Text = "Add";
            this.addImmuneBtn.UseVisualStyleBackColor = true;
            this.addImmuneBtn.Click += new System.EventHandler(this.addImmuneBtn_Click);
            // 
            // ImTooltip
            // 
            this.ImTooltip.AutoPopDelay = 5000;
            this.ImTooltip.InitialDelay = 50;
            this.ImTooltip.ReshowDelay = 10;
            this.ImTooltip.ShowAlways = true;
            this.ImTooltip.ToolTipTitle = "Immunity";
            // 
            // wnessNameBox
            // 
            this.wnessNameBox.Location = new System.Drawing.Point(120, 273);
            this.wnessNameBox.Name = "wnessNameBox";
            this.wnessNameBox.Size = new System.Drawing.Size(81, 20);
            this.wnessNameBox.TabIndex = 35;
            // 
            // resNameBox
            // 
            this.resNameBox.Location = new System.Drawing.Point(246, 273);
            this.resNameBox.Name = "resNameBox";
            this.resNameBox.Size = new System.Drawing.Size(81, 20);
            this.resNameBox.TabIndex = 36;
            // 
            // superNameBox
            // 
            this.superNameBox.Location = new System.Drawing.Point(373, 273);
            this.superNameBox.Name = "superNameBox";
            this.superNameBox.Size = new System.Drawing.Size(81, 20);
            this.superNameBox.TabIndex = 37;
            // 
            // immuneNameBox
            // 
            this.immuneNameBox.Location = new System.Drawing.Point(343, 78);
            this.immuneNameBox.Name = "immuneNameBox";
            this.immuneNameBox.Size = new System.Drawing.Size(81, 20);
            this.immuneNameBox.TabIndex = 38;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.moreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(477, 24);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byIDToolStripMenuItem,
            this.byNameToolStripMenuItem,
            this.byWeaknessesToolStripMenuItem,
            this.byResistancesToolStripMenuItem,
            this.bySuperEffectivenessesToolStripMenuItem,
            this.byImmunitiesToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // byIDToolStripMenuItem
            // 
            this.byIDToolStripMenuItem.Name = "byIDToolStripMenuItem";
            this.byIDToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.byIDToolStripMenuItem.Text = "By ID";
            this.byIDToolStripMenuItem.Click += new System.EventHandler(this.byIDToolStripMenuItem_Click);
            // 
            // byNameToolStripMenuItem
            // 
            this.byNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayNameToolStripMenuItem,
            this.internalNameToolStripMenuItem});
            this.byNameToolStripMenuItem.Name = "byNameToolStripMenuItem";
            this.byNameToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.byNameToolStripMenuItem.Text = "By Name";
            // 
            // displayNameToolStripMenuItem
            // 
            this.displayNameToolStripMenuItem.Name = "displayNameToolStripMenuItem";
            this.displayNameToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.displayNameToolStripMenuItem.Text = "Display Name";
            this.displayNameToolStripMenuItem.Click += new System.EventHandler(this.displayNameToolStripMenuItem_Click);
            // 
            // internalNameToolStripMenuItem
            // 
            this.internalNameToolStripMenuItem.Name = "internalNameToolStripMenuItem";
            this.internalNameToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.internalNameToolStripMenuItem.Text = "Internal Name";
            this.internalNameToolStripMenuItem.Click += new System.EventHandler(this.internalNameToolStripMenuItem_Click);
            // 
            // byWeaknessesToolStripMenuItem
            // 
            this.byWeaknessesToolStripMenuItem.Name = "byWeaknessesToolStripMenuItem";
            this.byWeaknessesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.byWeaknessesToolStripMenuItem.Text = "By Weaknesses";
            this.byWeaknessesToolStripMenuItem.Click += new System.EventHandler(this.byWeaknessesToolStripMenuItem_Click);
            // 
            // byResistancesToolStripMenuItem
            // 
            this.byResistancesToolStripMenuItem.Name = "byResistancesToolStripMenuItem";
            this.byResistancesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.byResistancesToolStripMenuItem.Text = "By Resistances";
            this.byResistancesToolStripMenuItem.Click += new System.EventHandler(this.byResistancesToolStripMenuItem_Click);
            // 
            // bySuperEffectivenessesToolStripMenuItem
            // 
            this.bySuperEffectivenessesToolStripMenuItem.Name = "bySuperEffectivenessesToolStripMenuItem";
            this.bySuperEffectivenessesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.bySuperEffectivenessesToolStripMenuItem.Text = "By Super Effectivenesses";
            this.bySuperEffectivenessesToolStripMenuItem.Click += new System.EventHandler(this.bySuperEffectivenessesToolStripMenuItem_Click);
            // 
            // byImmunitiesToolStripMenuItem
            // 
            this.byImmunitiesToolStripMenuItem.Name = "byImmunitiesToolStripMenuItem";
            this.byImmunitiesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.byImmunitiesToolStripMenuItem.Text = "By Immunities";
            this.byImmunitiesToolStripMenuItem.Click += new System.EventHandler(this.byImmunitiesToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem,
            this.exportToolStripMenuItem1,
            this.overwriteToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.exportToolStripMenuItem.Text = "Generate";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.exportToolStripMenuItem1.Text = "Export";
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
            // 
            // overwriteToolStripMenuItem
            // 
            this.overwriteToolStripMenuItem.Name = "overwriteToolStripMenuItem";
            this.overwriteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.overwriteToolStripMenuItem.Text = "Overwrite";
            this.overwriteToolStripMenuItem.Click += new System.EventHandler(this.overwriteToolStripMenuItem_Click);
            // 
            // moreToolStripMenuItem
            // 
            this.moreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTypestxtToolStripMenuItem,
            this.findInternalNameToolStripMenuItem,
            this.reloadDataToolStripMenuItem});
            this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            this.moreToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.moreToolStripMenuItem.Text = "More";
            // 
            // openTypestxtToolStripMenuItem
            // 
            this.openTypestxtToolStripMenuItem.Name = "openTypestxtToolStripMenuItem";
            this.openTypestxtToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.openTypestxtToolStripMenuItem.Text = "Open types.txt";
            this.openTypestxtToolStripMenuItem.Click += new System.EventHandler(this.openTypestxtToolStripMenuItem_Click);
            // 
            // findInternalNameToolStripMenuItem
            // 
            this.findInternalNameToolStripMenuItem.Name = "findInternalNameToolStripMenuItem";
            this.findInternalNameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findInternalNameToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.findInternalNameToolStripMenuItem.Text = "Find Internal Name";
            this.findInternalNameToolStripMenuItem.Click += new System.EventHandler(this.findInternalNameToolStripMenuItem_Click);
            // 
            // reloadDataToolStripMenuItem
            // 
            this.reloadDataToolStripMenuItem.Name = "reloadDataToolStripMenuItem";
            this.reloadDataToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.reloadDataToolStripMenuItem.Text = "Reload Data";
            this.reloadDataToolStripMenuItem.Click += new System.EventHandler(this.reloadDataToolStripMenuItem_Click);
            // 
            // isSpecialType
            // 
            this.isSpecialType.AutoSize = true;
            this.isSpecialType.Location = new System.Drawing.Point(97, 299);
            this.isSpecialType.Name = "isSpecialType";
            this.isSpecialType.Size = new System.Drawing.Size(146, 17);
            this.isSpecialType.TabIndex = 40;
            this.isSpecialType.Text = "The type is a special-type";
            this.isSpecialType.UseVisualStyleBackColor = true;
            this.isSpecialType.CheckedChanged += new System.EventHandler(this.isSpecialType_CheckedChanged);
            this.isSpecialType.MouseHover += new System.EventHandler(this.isSpecialType_MouseHover);
            // 
            // specialTooltip
            // 
            this.specialTooltip.AutoPopDelay = 5000;
            this.specialTooltip.InitialDelay = 50;
            this.specialTooltip.ReshowDelay = 10;
            this.specialTooltip.ShowAlways = true;
            this.specialTooltip.ToolTipTitle = "Special Type";
            // 
            // idTip
            // 
            this.idTip.AutoPopDelay = 5000;
            this.idTip.InitialDelay = 50;
            this.idTip.ReshowDelay = 10;
            this.idTip.ShowAlways = true;
            this.idTip.ToolTipTitle = "ID";
            // 
            // nameTip
            // 
            this.nameTip.AutoPopDelay = 5000;
            this.nameTip.InitialDelay = 50;
            this.nameTip.ReshowDelay = 10;
            this.nameTip.ShowAlways = true;
            this.nameTip.ToolTipTitle = "Name";
            // 
            // intNameTip
            // 
            this.intNameTip.AutoPopDelay = 5000;
            this.intNameTip.InitialDelay = 50;
            this.intNameTip.ReshowDelay = 10;
            this.intNameTip.ShowAlways = true;
            this.intNameTip.ToolTipTitle = "Internal Name";
            // 
            // typeTip
            // 
            this.typeTip.AutoPopDelay = 5000;
            this.typeTip.InitialDelay = 50;
            this.typeTip.ReshowDelay = 10;
            this.typeTip.ShowAlways = true;
            this.typeTip.ToolTipTitle = "Type";
            // 
            // TypeGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 318);
            this.Controls.Add(this.isSpecialType);
            this.Controls.Add(this.immuneNameBox);
            this.Controls.Add(this.superNameBox);
            this.Controls.Add(this.resNameBox);
            this.Controls.Add(this.wnessNameBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.removeImmuneBtn);
            this.Controls.Add(this.addImmuneBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.imBox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.removeSuperBtn);
            this.Controls.Add(this.addSuperBtn);
            this.Controls.Add(this.superBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.removeResBtn);
            this.Controls.Add(this.addResBtn);
            this.Controls.Add(this.resBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.removeWnessBtn);
            this.Controls.Add(this.addWnessBtn);
            this.Controls.Add(this.wnessBox);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.intNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(493, 367);
            this.MinimumSize = new System.Drawing.Size(493, 357);
            this.Name = "TypeGen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Type Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TypeGen_FormClosing);
            this.Load += new System.EventHandler(this.TypeGen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.idBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox typeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox intNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown idBox;
        private System.Windows.Forms.ListBox wnessBox;
        private System.Windows.Forms.Button addWnessBtn;
        private System.Windows.Forms.Button removeWnessBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip WnessTooltip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button removeResBtn;
        private System.Windows.Forms.Button addResBtn;
        private System.Windows.Forms.ListBox resBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip ResTooltip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button removeSuperBtn;
        private System.Windows.Forms.Button addSuperBtn;
        private System.Windows.Forms.ListBox superBox;
        private System.Windows.Forms.ToolTip SuperTooltip;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListBox imBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button removeImmuneBtn;
        private System.Windows.Forms.Button addImmuneBtn;
        private System.Windows.Forms.ToolTip ImTooltip;
        private System.Windows.Forms.TextBox wnessNameBox;
        private System.Windows.Forms.TextBox resNameBox;
        private System.Windows.Forms.TextBox superNameBox;
        private System.Windows.Forms.TextBox immuneNameBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem overwriteToolStripMenuItem;
        private System.Windows.Forms.CheckBox isSpecialType;
        private System.Windows.Forms.ToolTip specialTooltip;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byWeaknessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byResistancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bySuperEffectivenessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byImmunitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internalNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTypestxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findInternalNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadDataToolStripMenuItem;
        private System.Windows.Forms.ToolTip idTip;
        private System.Windows.Forms.ToolTip nameTip;
        private System.Windows.Forms.ToolTip intNameTip;
        private System.Windows.Forms.ToolTip typeTip;
    }
}