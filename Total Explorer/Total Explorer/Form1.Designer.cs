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
            listView2 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            backbutton = new Button();
            forwardbutton = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { NameColumn, ExtColumn, SizeColumn, DateColumn });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 77);
            listView1.Name = "listView1";
            listView1.Size = new Size(434, 762);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // NameColumn
            // 
            NameColumn.Text = "Name";
            NameColumn.Width = 250;
            // 
            // ExtColumn
            // 
            ExtColumn.Text = "Ext";
            // 
            // SizeColumn
            // 
            SizeColumn.Text = "Size";
            // 
            // DateColumn
            // 
            DateColumn.Text = "Date";
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView2.FullRowSelect = true;
            listView2.Location = new Point(507, 77);
            listView2.Name = "listView2";
            listView2.Size = new Size(434, 762);
            listView2.TabIndex = 1;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ext";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Size";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Date";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(953, 33);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(78, 29);
            aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "Help";
            // 
            // backbutton
            // 
            backbutton.Image = (Image)resources.GetObject("backbutton.Image");
            backbutton.Location = new Point(12, 36);
            backbutton.Name = "backbutton";
            backbutton.Size = new Size(35, 34);
            backbutton.TabIndex = 3;
            backbutton.UseVisualStyleBackColor = true;
            // 
            // forwardbutton
            // 
            forwardbutton.Image = (Image)resources.GetObject("forwardbutton.Image");
            forwardbutton.Location = new Point(53, 37);
            forwardbutton.Name = "forwardbutton";
            forwardbutton.Size = new Size(35, 34);
            forwardbutton.TabIndex = 4;
            forwardbutton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 851);
            Controls.Add(forwardbutton);
            Controls.Add(backbutton);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
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
        private ListView listView2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Button backbutton;
        private Button forwardbutton;
    }
}
