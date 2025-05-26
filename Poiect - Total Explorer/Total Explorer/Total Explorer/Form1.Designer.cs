namespace Total_Explorer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            listView1 = new ListView();
            NameColumn = new ColumnHeader();
            ExtColumn = new ColumnHeader();
            SizeColumn = new ColumnHeader();
            DateColumn = new ColumnHeader();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            listView2 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            forwardbutton1 = new Button();
            backbutton1 = new Button();
            forwardbutton2 = new Button();
            backbutton2 = new Button();
            copytorightbutton = new Button();
            copytoleftbutton = new Button();
            movetorightbutton = new Button();
            movetoleftbutton = new Button();
            delete1 = new Button();
            delete2 = new Button();
            buttonTips = new ToolTip(components);
            rename1 = new Button();
            renum2 = new Button();
            createfolderbutton1 = new Button();
            createfolderbutton2 = new Button();
            createfilebutton1 = new Button();
            createfilebutton2 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.AllowDrop = true;
            listView1.Columns.AddRange(new ColumnHeader[] { NameColumn, ExtColumn, SizeColumn, DateColumn });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(10, 78);
            listView1.Margin = new Padding(2);
            listView1.Name = "listView1";
            listView1.Size = new Size(657, 594);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            // 
            // NameColumn
            // 
            NameColumn.Text = "Name";
            NameColumn.Width = 300;
            // 
            // ExtColumn
            // 
            ExtColumn.Text = "Ext";
            ExtColumn.Width = 100;
            // 
            // SizeColumn
            // 
            SizeColumn.Text = "Size";
            SizeColumn.Width = 100;
            // 
            // DateColumn
            // 
            DateColumn.Text = "Date";
            DateColumn.Width = 150;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1406, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(52, 24);
            fileToolStripMenuItem.Text = "Files";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(120, 26);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(64, 24);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // listView2
            // 
            listView2.AllowDrop = true;
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView2.FullRowSelect = true;
            listView2.Location = new Point(739, 78);
            listView2.Margin = new Padding(2);
            listView2.Name = "listView2";
            listView2.Size = new Size(656, 596);
            listView2.TabIndex = 5;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            listView2.MouseDoubleClick += listView2_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ext";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Size";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Date";
            columnHeader4.Width = 150;
            // 
            // forwardbutton1
            // 
            forwardbutton1.AutoSize = true;
            forwardbutton1.Image = (Image)resources.GetObject("forwardbutton1.Image");
            forwardbutton1.Location = new Point(51, 36);
            forwardbutton1.Margin = new Padding(2);
            forwardbutton1.Name = "forwardbutton1";
            forwardbutton1.Size = new Size(38, 38);
            forwardbutton1.TabIndex = 4;
            buttonTips.SetToolTip(forwardbutton1, "Go forward");
            forwardbutton1.UseVisualStyleBackColor = true;
            forwardbutton1.Click += forwardbutton1_Click;
            // 
            // backbutton1
            // 
            backbutton1.AutoSize = true;
            backbutton1.Image = (Image)resources.GetObject("backbutton1.Image");
            backbutton1.Location = new Point(10, 36);
            backbutton1.Margin = new Padding(2);
            backbutton1.Name = "backbutton1";
            backbutton1.Size = new Size(38, 38);
            backbutton1.TabIndex = 3;
            buttonTips.SetToolTip(backbutton1, "Go back");
            backbutton1.UseVisualStyleBackColor = true;
            backbutton1.Click += backbutton1_Click;
            // 
            // forwardbutton2
            // 
            forwardbutton2.AutoSize = true;
            forwardbutton2.Image = (Image)resources.GetObject("forwardbutton2.Image");
            forwardbutton2.Location = new Point(781, 36);
            forwardbutton2.Margin = new Padding(2);
            forwardbutton2.Name = "forwardbutton2";
            forwardbutton2.Size = new Size(38, 38);
            forwardbutton2.TabIndex = 7;
            buttonTips.SetToolTip(forwardbutton2, "Go forward");
            forwardbutton2.UseVisualStyleBackColor = true;
            forwardbutton2.Click += forwardbutton2_Click;
            // 
            // backbutton2
            // 
            backbutton2.AutoSize = true;
            backbutton2.Image = (Image)resources.GetObject("backbutton2.Image");
            backbutton2.Location = new Point(739, 36);
            backbutton2.Margin = new Padding(2);
            backbutton2.Name = "backbutton2";
            backbutton2.Size = new Size(38, 38);
            backbutton2.TabIndex = 6;
            buttonTips.SetToolTip(backbutton2, "Go back");
            backbutton2.UseVisualStyleBackColor = true;
            backbutton2.Click += backbutton2_Click;
            // 
            // copytorightbutton
            // 
            copytorightbutton.AutoSize = true;
            copytorightbutton.Image = (Image)resources.GetObject("copytorightbutton.Image");
            copytorightbutton.Location = new Point(175, 36);
            copytorightbutton.Margin = new Padding(2);
            copytorightbutton.Name = "copytorightbutton";
            copytorightbutton.Size = new Size(38, 38);
            copytorightbutton.TabIndex = 8;
            buttonTips.SetToolTip(copytorightbutton, "Copy selected item from the left panel to the right panel.");
            copytorightbutton.UseVisualStyleBackColor = true;
            copytorightbutton.Click += copytorightbutton_Click;
            // 
            // copytoleftbutton
            // 
            copytoleftbutton.AutoSize = true;
            copytoleftbutton.Image = (Image)resources.GetObject("copytoleftbutton.Image");
            copytoleftbutton.Location = new Point(908, 37);
            copytoleftbutton.Margin = new Padding(2);
            copytoleftbutton.Name = "copytoleftbutton";
            copytoleftbutton.Size = new Size(38, 38);
            copytoleftbutton.TabIndex = 9;
            buttonTips.SetToolTip(copytoleftbutton, "Copy selected item from the right panel to the left panel.");
            copytoleftbutton.UseVisualStyleBackColor = true;
            copytoleftbutton.Click += copytoleftbutton_Click;
            // 
            // movetorightbutton
            // 
            movetorightbutton.AutoSize = true;
            movetorightbutton.Image = (Image)resources.GetObject("movetorightbutton.Image");
            movetorightbutton.Location = new Point(217, 36);
            movetorightbutton.Margin = new Padding(2);
            movetorightbutton.Name = "movetorightbutton";
            movetorightbutton.Size = new Size(38, 38);
            movetorightbutton.TabIndex = 10;
            buttonTips.SetToolTip(movetorightbutton, "Move selected item from the left panel to the right panel.");
            movetorightbutton.UseVisualStyleBackColor = true;
            movetorightbutton.Click += movetorightbutton_Click;
            // 
            // movetoleftbutton
            // 
            movetoleftbutton.AutoSize = true;
            movetoleftbutton.Image = (Image)resources.GetObject("movetoleftbutton.Image");
            movetoleftbutton.Location = new Point(950, 36);
            movetoleftbutton.Margin = new Padding(2);
            movetoleftbutton.Name = "movetoleftbutton";
            movetoleftbutton.Size = new Size(38, 38);
            movetoleftbutton.TabIndex = 11;
            buttonTips.SetToolTip(movetoleftbutton, "Move selected item from the right panel to the left panel.");
            movetoleftbutton.UseVisualStyleBackColor = true;
            movetoleftbutton.Click += movetoleftbutton_Click;
            // 
            // delete1
            // 
            delete1.AutoSize = true;
            delete1.Image = (Image)resources.GetObject("delete1.Image");
            delete1.Location = new Point(629, 36);
            delete1.Margin = new Padding(2);
            delete1.Name = "delete1";
            delete1.Size = new Size(38, 38);
            delete1.TabIndex = 12;
            buttonTips.SetToolTip(delete1, "Delete item");
            delete1.UseVisualStyleBackColor = true;
            delete1.Click += delete1_Click;
            // 
            // delete2
            // 
            delete2.AutoSize = true;
            delete2.Image = (Image)resources.GetObject("delete2.Image");
            delete2.Location = new Point(1357, 38);
            delete2.Margin = new Padding(0);
            delete2.Name = "delete2";
            delete2.Size = new Size(38, 38);
            delete2.TabIndex = 13;
            buttonTips.SetToolTip(delete2, "Delete item");
            delete2.UseVisualStyleBackColor = true;
            delete2.Click += delete2_Click;
            // 
            // rename1
            // 
            rename1.AutoSize = true;
            rename1.Image = (Image)resources.GetObject("rename1.Image");
            rename1.Location = new Point(259, 36);
            rename1.Margin = new Padding(2);
            rename1.Name = "rename1";
            rename1.Size = new Size(38, 38);
            rename1.TabIndex = 14;
            buttonTips.SetToolTip(rename1, "Rename item");
            rename1.UseVisualStyleBackColor = true;
            rename1.Click += rename1_Click;
            // 
            // renum2
            // 
            renum2.AutoSize = true;
            renum2.Image = (Image)resources.GetObject("renum2.Image");
            renum2.Location = new Point(992, 36);
            renum2.Margin = new Padding(2);
            renum2.Name = "renum2";
            renum2.Size = new Size(38, 38);
            renum2.TabIndex = 15;
            buttonTips.SetToolTip(renum2, "Rename item");
            renum2.UseVisualStyleBackColor = true;
            renum2.Click += renum2_Click;
            // 
            // createfolderbutton1
            // 
            createfolderbutton1.AutoSize = true;
            createfolderbutton1.Image = (Image)resources.GetObject("createfolderbutton1.Image");
            createfolderbutton1.Location = new Point(93, 36);
            createfolderbutton1.Margin = new Padding(2);
            createfolderbutton1.Name = "createfolderbutton1";
            createfolderbutton1.Size = new Size(38, 38);
            createfolderbutton1.TabIndex = 16;
            buttonTips.SetToolTip(createfolderbutton1, "Delete item");
            createfolderbutton1.UseVisualStyleBackColor = true;
            createfolderbutton1.Click += createfolderbutton1_Click;
            // 
            // createfolderbutton2
            // 
            createfolderbutton2.AutoSize = true;
            createfolderbutton2.Image = (Image)resources.GetObject("createfolderbutton2.Image");
            createfolderbutton2.Location = new Point(823, 36);
            createfolderbutton2.Margin = new Padding(2);
            createfolderbutton2.Name = "createfolderbutton2";
            createfolderbutton2.Size = new Size(38, 38);
            createfolderbutton2.TabIndex = 17;
            buttonTips.SetToolTip(createfolderbutton2, "Delete item");
            createfolderbutton2.UseVisualStyleBackColor = true;
            createfolderbutton2.Click += createfolderbutton2_Click;
            // 
            // createfilebutton1
            // 
            createfilebutton1.AutoSize = true;
            createfilebutton1.Image = (Image)resources.GetObject("createfilebutton1.Image");
            createfilebutton1.Location = new Point(135, 36);
            createfilebutton1.Margin = new Padding(2);
            createfilebutton1.Name = "createfilebutton1";
            createfilebutton1.Size = new Size(38, 38);
            createfilebutton1.TabIndex = 18;
            buttonTips.SetToolTip(createfilebutton1, "Delete item");
            createfilebutton1.UseVisualStyleBackColor = true;
            createfilebutton1.Click += createfilebutton1_Click;
            // 
            // createfilebutton2
            // 
            createfilebutton2.AutoSize = true;
            createfilebutton2.Image = (Image)resources.GetObject("createfilebutton2.Image");
            createfilebutton2.Location = new Point(865, 36);
            createfilebutton2.Margin = new Padding(2);
            createfilebutton2.Name = "createfilebutton2";
            createfilebutton2.Size = new Size(38, 38);
            createfilebutton2.TabIndex = 19;
            buttonTips.SetToolTip(createfilebutton2, "Delete item");
            createfilebutton2.UseVisualStyleBackColor = true;
            createfilebutton2.Click += createfilebutton2_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1406, 681);
            Controls.Add(createfilebutton2);
            Controls.Add(createfilebutton1);
            Controls.Add(createfolderbutton2);
            Controls.Add(createfolderbutton1);
            Controls.Add(renum2);
            Controls.Add(rename1);
            Controls.Add(delete2);
            Controls.Add(delete1);
            Controls.Add(movetoleftbutton);
            Controls.Add(movetorightbutton);
            Controls.Add(copytoleftbutton);
            Controls.Add(copytorightbutton);
            Controls.Add(forwardbutton2);
            Controls.Add(backbutton2);
            Controls.Add(listView2);
            Controls.Add(forwardbutton1);
            Controls.Add(backbutton1);
            Controls.Add(listView1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Total Explorer";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader NameColumn;
        private ColumnHeader ExtColumn;
        private ColumnHeader SizeColumn;
        private ColumnHeader DateColumn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ListView listView2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ToolStripMenuItem quitToolStripMenuItem;
        private Button forwardbutton1;
        private Button backbutton1;
        private Button forwardbutton2;
        private Button backbutton2;
        private Button copytorightbutton;
        private Button copytoleftbutton;
        private Button movetorightbutton;
        private Button movetoleftbutton;
        private Button delete1;
        private Button delete2;
        private ToolTip buttonTips;
        private Button rename1;
        private Button renum2;
        private Button createfolderbutton1;
        private Button createfolderbutton2;
        private Button createfilebutton1;
        private Button createfilebutton2;
    }
}
