using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Total_Explorer
{
    public partial class Form1 : Form
    {
        private int sortColumn1 = 0;
        private bool sortAscending1 = false;

        private int sortColumn2 = 0;
        private bool sortAscending2 = false;

        private Bitmap arrowUp;
        private Bitmap arrowDown;

        public Form1()
        {
            InitializeComponent();

            arrowUp = LoadImage("uparrow.png");
            arrowDown = LoadImage("downarrow.png");

            listView1.OwnerDraw = true;
            listView1.DrawColumnHeader += ListView_DrawColumnHeader;
            listView1.ColumnClick += ListView_ColumnClick;
            listView1.DrawItem += ListView_DrawItem;
            listView1.DrawSubItem += ListView_DrawSubItem;

            listView2.OwnerDraw = true;
            listView2.DrawColumnHeader += ListView_DrawColumnHeader;
            listView2.ColumnClick += ListView_ColumnClick;
            listView2.DrawItem += ListView_DrawItem;
            listView2.DrawSubItem += ListView_DrawSubItem;

        }

        private Bitmap LoadImage(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", fileName);
            return new Bitmap(path);
        }

        private int GetSortColumn(ListView lv)
        {
            if (lv == listView1) return sortColumn1;
            else if (lv == listView2) return sortColumn2;
            else return -1;
        }

        private void SetSortColumn(ListView lv, int value)
        {
            if (lv == listView1) sortColumn1 = value;
            else if (lv == listView2) sortColumn2 = value;
        }

        private bool GetSortAscending(ListView lv)
        {
            if (lv == listView1) return sortAscending1;
            else if (lv == listView2) return sortAscending2;
            else return true;
        }

        private void SetSortAscending(ListView lv, bool value)
        {
            if (lv == listView1) sortAscending1 = value;
            else if (lv == listView2) sortAscending2 = value;
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv == null) return;

            int currentSortColumn = GetSortColumn(lv);
            bool currentSortAscending = GetSortAscending(lv);

            if (e.Column == currentSortColumn)
                currentSortAscending = !currentSortAscending;
            else
            {
                currentSortColumn = e.Column;
                currentSortAscending = true;
            }

            SetSortColumn(lv, currentSortColumn);
            SetSortAscending(lv, currentSortAscending);

            lv.Refresh();
        }

        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv == null) return;

            int currentSortColumn = GetSortColumn(lv);
            bool currentSortAscending = GetSortAscending(lv);

            int arrowsize = 22;

            Rectangle textBounds = e.Bounds;

            if (e.ColumnIndex == currentSortColumn)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                textBounds.X += arrowsize + 4;
                textBounds.Width -= arrowsize + 4;

                int arrowX = e.Bounds.Left + 4;
                int arrowY = e.Bounds.Top + (e.Bounds.Height - arrowsize) / 2;
                Bitmap arrow = currentSortAscending ? arrowUp : arrowDown;
                e.Graphics.DrawImage(arrow, arrowX, arrowY, arrowsize, arrowsize);
            }

            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, textBounds, e.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            e.DrawDefault = false;
        }

        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "A lightweight file explorer inspired by Total Commander.\nFeatures dual-panel navigation and basic file operations.",
                "About Total Explorer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
