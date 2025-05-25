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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { NameColumn, ExtColumn, SizeColumn, DateColumn });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 98);
            listView1.Name = "listView1";
            listView1.Size = new Size(755, 741);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // NameColumn
            // 
            NameColumn.Text = "Name";
            NameColumn.Width = 300;
            // 
            // ExtColumn
            // 
            ExtColumn.Text = "Ext";
            ExtColumn.Width = 150;
            // 
            // SizeColumn
            // 
            SizeColumn.Text = "Size";
            SizeColumn.Width = 150;
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
            menuStrip1.Size = new Size(1579, 33);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(62, 29);
            fileToolStripMenuItem.Text = "Files";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(148, 34);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(78, 29);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "Help";
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView2.FullRowSelect = true;
            listView2.Location = new Point(812, 98);
            listView2.Name = "listView2";
            listView2.Size = new Size(755, 741);
            listView2.TabIndex = 5;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ext";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Size";
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Date";
            columnHeader4.Width = 150;
            // 
            // forwardbutton1
            // 
            forwardbutton1.Image = (Image)resources.GetObject("forwardbutton1.Image");
            forwardbutton1.Location = new Point(64, 49);
            forwardbutton1.Name = "forwardbutton1";
            forwardbutton1.Size = new Size(46, 43);
            forwardbutton1.TabIndex = 4;
            forwardbutton1.UseVisualStyleBackColor = true;
            // 
            // backbutton1
            // 
            backbutton1.Image = (Image)resources.GetObject("backbutton1.Image");
            backbutton1.Location = new Point(12, 50);
            backbutton1.Name = "backbutton1";
            backbutton1.Size = new Size(46, 43);
            backbutton1.TabIndex = 3;
            backbutton1.UseVisualStyleBackColor = true;
            // 
            // forwardbutton2
            // 
            forwardbutton2.Image = (Image)resources.GetObject("forwardbutton2.Image");
            forwardbutton2.Location = new Point(863, 50);
            forwardbutton2.Name = "forwardbutton2";
            forwardbutton2.Size = new Size(45, 42);
            forwardbutton2.TabIndex = 7;
            forwardbutton2.UseVisualStyleBackColor = true;
            // 
            // backbutton2
            // 
            backbutton2.Image = (Image)resources.GetObject("backbutton2.Image");
            backbutton2.Location = new Point(812, 51);
            backbutton2.Name = "backbutton2";
            backbutton2.Size = new Size(45, 42);
            backbutton2.TabIndex = 6;
            backbutton2.UseVisualStyleBackColor = true;
            // 
            // copytorightbutton
            // 
            copytorightbutton.Image = (Image)resources.GetObject("copytorightbutton.Image");
            copytorightbutton.Location = new Point(116, 50);
            copytorightbutton.Name = "copytorightbutton";
            copytorightbutton.Size = new Size(46, 43);
            copytorightbutton.TabIndex = 8;
            copytorightbutton.UseVisualStyleBackColor = true;
            // 
            // copytoleftbutton
            // 
            copytoleftbutton.Image = (Image)resources.GetObject("copytoleftbutton.Image");
            copytoleftbutton.Location = new Point(914, 51);
            copytoleftbutton.Name = "copytoleftbutton";
            copytoleftbutton.Size = new Size(46, 43);
            copytoleftbutton.TabIndex = 9;
            copytoleftbutton.UseVisualStyleBackColor = true;
            // 
            // movetorightbutton
            // 
            movetorightbutton.Image = (Image)resources.GetObject("movetorightbutton.Image");
            movetorightbutton.Location = new Point(168, 51);
            movetorightbutton.Name = "movetorightbutton";
            movetorightbutton.Size = new Size(46, 43);
            movetorightbutton.TabIndex = 10;
            movetorightbutton.UseVisualStyleBackColor = true;
            // 
            // movetoleftbutton
            // 
            movetoleftbutton.Image = (Image)resources.GetObject("movetoleftbutton.Image");
            movetoleftbutton.Location = new Point(966, 51);
            movetoleftbutton.Name = "movetoleftbutton";
            movetoleftbutton.Size = new Size(46, 43);
            movetoleftbutton.TabIndex = 11;
            movetoleftbutton.UseVisualStyleBackColor = true;
            // 
            // delete1
            // 
            delete1.Image = (Image)resources.GetObject("delete1.Image");
            delete1.Location = new Point(220, 51);
            delete1.Name = "delete1";
            delete1.Size = new Size(46, 43);
            delete1.TabIndex = 12;
            delete1.UseVisualStyleBackColor = true;
            // 
            // delete2
            // 
            delete2.Image = (Image)resources.GetObject("delete2.Image");
            delete2.Location = new Point(1018, 51);
            delete2.Name = "delete2";
            delete2.Size = new Size(46, 43);
            delete2.TabIndex = 13;
            delete2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1579, 851);
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
    }
}
