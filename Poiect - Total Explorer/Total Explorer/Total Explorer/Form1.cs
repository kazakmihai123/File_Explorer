/**************************************************************************
 *                                                                        *
 *  File:        Form1.cs                                                 *
 *  Copyright:   (c) 2025, Ciobanu Andrei, Timofte Alin-Gabriel,          *
 *               Rata Mihai-Gabriel, Paladi Andrei                        *
 *  E-mail:      andrei.ciobanu4@student.tuiasi.ro                        *
 *               alin-gabriel.timofte@student.tuiasi.ro                   *
 *               mihai-gabriel.rata@student.tuiasi.ro                     *
 *               andrei.paladi@student.tuiasi.ro                          *
 *  Description:  Student at Faculty of Automatic Control and             *
 *               Computer Engineering                                     *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Runtime;
using System.Windows.Forms;
using TotalExplorer.ManagingFiles;
using TotalExplorer.Sorting;

namespace Total_Explorer
{
    public partial class Form1 : Form
    {
        private ImageList smallImageList;
        private IFileManager _manager1;
        private IFileManager _manager2;
        private string _directory1;
        private string _directory2;
        private List<FileItem> _fileItems1;
        private List<FileItem> _fileItems2;
        private ISortStrategy _strategy1;
        private ISortStrategy _strategy2;
        private History.History _history1;
        private History.History _history2;
        private int _sortColumn1 = 0;
        private bool _sortAscending1 = false;

        private int _sortColumn2 = 0;
        private bool _sortAscending2 = false;

        private Bitmap _arrowUp;
        private Bitmap _arrowDown;

        public Form1()
        {
            InitializeComponent();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            this.AutoScaleMode = AutoScaleMode.None;


            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            _arrowUp = LoadImage("images/uparrow.png");
            _arrowDown = LoadImage("images/downarrow.png");


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

            listView1.ItemDrag += ListView_ItemDrag;
            listView2.ItemDrag += ListView_ItemDrag;

            listView1.DragEnter += ListView_DragEnter;
            listView2.DragEnter += ListView_DragEnter;

            listView1.DragDrop += ListView_DragDrop;
            listView2.DragDrop += ListView_DragDrop;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeImageList();
            _directory1 = "E:\\";
            _manager1 = new FileManager();
            _fileItems1 = new List<FileItem>();
            _directory2 = "E:\\";
            _manager2 = new FileManager();
            _fileItems2 = new List<FileItem>();
            _history1 = new History.History(_directory1);
            _history2 = new History.History(_directory2);
            LoadFilesIntoForm(1);
            LoadFilesIntoForm(2);
        }

        /// <summary>
        /// Loads files and directories into the specified ListView panel.
        /// </summary>
        /// <param name="index">
        /// Panel index: 1 for the left panel (listView1), 2 for the right panel (listView2).
        /// </param>
        /// <remarks>
        /// This method:
        /// - Fetches all file paths from the current directory using IFileManager.
        /// - Creates FileItem objects with name, extension, size, and date.
        /// - Displays them in the UI.
        /// - Adds error handling to catch and show messages for inaccessible files or folders.
        /// </remarks>
        /// <exception cref="IOException">
        /// Thrown if the directory cannot be accessed.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// Thrown if access to the directory or files is denied.
        /// </exception>
        private void LoadFilesIntoForm(int index)
        {
            ListView listView = (index == 1) ? listView1 : listView2;

            List<string> itemNames = new List<string>();
            List<FileItem> fileItems;
            IFileManager manager;

            try
            {
                if (index == 1)
                {
                    manager = _manager1;
                    itemNames = _manager1.GetFilesFromDirectory(_directory1);
                    _fileItems1.Clear();
                    fileItems = _fileItems1;
                }
                else
                {
                    manager = _manager2;
                    itemNames = _manager2.GetFilesFromDirectory(_directory2);
                    _fileItems2.Clear();
                    fileItems = _fileItems2;
                }

                listView.Items.Clear();

                foreach (string item in itemNames)
                {
                    try
                    {
                        string path = item;
                        string name = manager.GetFileName(path);
                        string extension = manager.GetFileExtension(path);
                        string size = manager.GetFileSize(path);
                        string date = manager.GetFileDateTime(path);
                        fileItems.Add(new FileItem(name, extension, size, date));

                        ListViewItem listItem = new ListViewItem(name);
                        listItem.SubItems.Add(extension);
                        listItem.SubItems.Add(size);
                        listItem.SubItems.Add(date);
                        listView.Items.Add(listItem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading item: {item}\n\n{ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                RefreshList(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading directory contents.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the drag operation when an item is dragged from a ListView.
        /// </summary>
        /// <param name="sender">The ListView control from which the item is dragged.</param>
        /// <param name="e">Event data containing the item being dragged.</param>
        /// <remarks>
        /// - Builds the full path of the selected file or directory based on the panel.
        /// - Initiates a drag-and-drop operation with the full path as payload.
        /// - If the selected item is a directory ("&lt;DIR&gt;"), extension is ignored.
        /// - Displays a warning message if the operation fails.
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught if the file is inaccessible or locked, preventing the drag operation.
        /// </exception>
        private void ListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListView source = (ListView)sender;
            try
            {
                if (source.SelectedItems.Count > 0)
                {
                    string fileName = source.SelectedItems[0].SubItems[0].Text;
                    string extension = source.SelectedItems[0].SubItems[1].Text;
                    if (extension == "<DIR>")
                        extension = "";

                    string fullPath = (source == listView1 ? _directory1 : _directory2) + "\\" + fileName + extension;
                    DoDragDrop(fullPath, DragDropEffects.Move);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: You can't move this", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the DragEnter event when a dragged item enters a ListView control.
        /// </summary>
        /// <param name="sender">The ListView control receiving the drag.</param>
        /// <param name="e">Contains information about the drag event.</param>
        /// <remarks>
        /// - Enables the drag-and-drop effect only if the dragged data is of type text (file path).
        /// - If the data format is unsupported, disables the drop operation.
        /// </remarks>
        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Handles the DragDrop event when a file is dropped onto a ListView.
        /// </summary>
        /// <param name="sender">The ListView control that receives the dropped file.</param>
        /// <param name="e">Contains data about the drag-and-drop operation.</param>
        /// <remarks>
        /// - Extracts the full path of the dragged file from the drag data.
        /// - Determines the target directory based on which ListView received the drop.
        /// - Moves the file from source to destination if paths are different.
        /// - Refreshes both panels after the operation.
        /// - Displays a warning if the move fails (e.g., file locked, permission denied).
        /// </remarks>
        /// <exception cref="IOException">
        /// Thrown if the move operation fails due to file system errors.
        /// </exception>
        private void ListView_DragDrop(object sender, DragEventArgs e)
        {
            string sourcePath = (string)e.Data.GetData(DataFormats.Text);
            string destDirectory = (sender == listView1) ? _directory1 : _directory2;
            string fileName = Path.GetFileName(sourcePath);
            string destPath = Path.Combine(destDirectory, fileName);

            if (sourcePath == destPath)
                return;

            try
            {
                File.Move(sourcePath, destPath);
                LoadFilesIntoForm(1);
                LoadFilesIntoForm(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Refreshes the contents of the specified ListView (left or right panel)
        /// by reloading the current list of <see cref="FileItem"/> objects.
        /// </summary>
        /// <param name="index">
        /// Panel index: 1 for the left panel (listView1), 2 for the right panel (listView2).
        /// </param>
        /// <remarks>
        /// - Clears the ListView and adds a "[..]" entry for navigating up a directory level.
        /// - Iterates through all FileItem objects and adds them with formatted columns.
        /// - Assigns an icon based on file extension (folder, image, document, unknown).
        /// </remarks>
        private void RefreshList(int index)
        {

            ListView listView = (index == 1) ? listView1 : listView2;
            listView.Items.Clear();
            List<FileItem> fileItems;
            if (index == 1)
            {
                fileItems = _fileItems1;
            }
            else
            {
                fileItems = _fileItems2;
            }
            ListViewItem prevDir = new ListViewItem("[..]");
            listView.Items.Add(prevDir);
            foreach (FileItem item in fileItems)
            {
                ListViewItem listItem = new ListViewItem(item.Name);
                listItem.SubItems.Add(item.Extension);
                listItem.SubItems.Add(item.Size);
                listItem.SubItems.Add(item.LastModified);

                if (item.Extension == "<DIR>")
                    listItem.ImageKey = "folder";
                else if (item.Extension == ".jpg" || item.Extension == ".png" || item.Extension == ".jpeg" ||
                         item.Extension == ".bmp" || item.Extension == ".gif")
                    listItem.ImageKey = "image";
                else if (item.Extension == ".pdf" || item.Extension == ".doc" || item.Extension == ".txt")
                    listItem.ImageKey = "file";
                else
                    listItem.ImageKey = "question";

                listView.Items.Add(listItem);
            }
        }

        /// <summary>
        /// Initializes the image list used to display icons for files and folders in the ListView controls.
        /// </summary>
        /// <remarks>
        /// - Sets a fixed image size for consistency across both panels.
        /// - Loads icons for folders, images, documents, and unknown types from the "images" directory.
        /// - Assigns the image list to both listView1 and listView2.
        /// </remarks>
        /// <exception cref="FileNotFoundException">
        /// Thrown if any image file is missing or cannot be loaded.
        /// </exception>
        private void InitializeImageList()
        {
            smallImageList = new ImageList();
            smallImageList.ImageSize = new Size(20, 20);

            smallImageList.Images.Add("folder", LoadImage("images/folder.png"));
            smallImageList.Images.Add("image", LoadImage("images/picture.png"));
            smallImageList.Images.Add("file", LoadImage("images/file.png"));
            smallImageList.Images.Add("question", LoadImage("images/question.png"));

            listView1.SmallImageList = smallImageList;
            listView2.SmallImageList = smallImageList;
        }

        /// <summary>
        /// Handles the Back button click event for the left panel (listView1).
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Uses the undo stack from <see cref="_history1"/> to navigate to the previous directory.
        /// - Reloads the contents of the left ListView after navigation.
        /// - Displays a warning if the undo operation fails.
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and shown to the user if an error occurs during navigation.
        /// </exception>
        private void backbutton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_history1.UndoEmpty)
                {
                    _directory1 = _history1.Undo();
                    LoadFilesIntoForm(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the Forward button click event for the left panel (listView1).
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Retrieves the next directory path from the redo stack (<see cref="_history1"/>).
        /// - Updates the current directory and reloads the left panel content.
        /// - Catches and displays any exception that might occur during navigation.
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and shown to the user if an error occurs during redo.
        /// </exception>
        private void forwardbutton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_history1.RedoEmpty)
                {
                    _directory1 = _history1.Redo();
                    LoadFilesIntoForm(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the "Copy to right" button.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Copies the selected file or folder from the left panel to the current directory in the right panel.
        /// - Skips extension if the item is a directory.
        /// - Uses <see cref="_manager1"/> to perform the copy operation.
        /// - Refreshes both panels after the operation.
        /// - Displays a warning if the operation fails (e.g., file access issues, permission errors).
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and shown to the user if an error occurs during file copy.
        /// </exception>
        private void copytorightbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    string extension = listView1.SelectedItems[0].SubItems[1].Text;
                    if (extension == "<DIR>")
                        extension = "";
                    string sourcepath = _directory1 + "\\" + listView1.SelectedItems[0].SubItems[0].Text + extension;
                    string destinationPath = _directory2 + "\\" + listView1.SelectedItems[0].SubItems[0].Text + extension;
                    _manager1.CopyFile(sourcepath, destinationPath);
                    LoadFilesIntoForm(1);
                    LoadFilesIntoForm(2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void movetorightbutton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                try
                {
                    string extension = listView1.SelectedItems[0].SubItems[1].Text;
                    if (extension == "<DIR>")
                        extension = "";
                    string sourcepath = _directory1 + "\\" + listView1.SelectedItems[0].SubItems[0].Text + extension;
                    string destinationPath = _directory2 + "\\" + listView1.SelectedItems[0].SubItems[0].Text + extension;
                    _manager1.MoveFile(sourcepath, destinationPath);
                    LoadFilesIntoForm(1);
                    LoadFilesIntoForm(2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the click event for the "Move to right" button.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Moves the selected file or folder from the left panel to the current directory in the right panel.
        /// - Detects if the item is a directory by checking for the "&lt;DIR&gt;" marker.
        /// - Uses <see cref="_manager1"/> to execute the move operation.
        /// - Refreshes both panels after the move.
        /// - Catches and displays any exceptions that occur (e.g., file not found, access denied).
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and displayed if an error occurs during the file or folder move.
        /// </exception>
        private void rename1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    string extension = listView1.SelectedItems[0].SubItems[1].Text;
                    if (extension == "<DIR>")
                        extension = "";

                    string oldName = listView1.SelectedItems[0].SubItems[0].Text;
                    string newName = Microsoft.VisualBasic.Interaction.InputBox("Enter new name:", "Rename File/Folder", oldName);
                    if (string.IsNullOrWhiteSpace(newName))
                        return;

                    string sourcepath = _directory1 + "\\" + listView1.SelectedItems[0].SubItems[0].Text + extension;
                    _manager1.Rename(sourcepath, newName);
                    LoadFilesIntoForm(1);
                    LoadFilesIntoForm(2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the "Delete" button in the left panel.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Prompts the user for confirmation before deleting the selected file or folder.
        /// - Determines the full path of the selected item based on current directory and extension.
        /// - Uses <see cref="_manager1"/> to perform the delete operation.
        /// - If confirmed and successful, reloads both panels to reflect the change.
        /// - Displays a warning if an error occurs (e.g., access denied, item in use).
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and displayed if deletion fails due to any unexpected error.
        /// </exception>
        private void delete1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    string extension = listView1.SelectedItems[0].SubItems[1].Text;
                    if (extension == "<DIR>")
                        extension = "";
                    string sourcepath = _directory1 + "\\" + listView1.SelectedItems[0].SubItems[0].Text + extension;

                    DialogResult result = MessageBox.Show(
                            "Are you sure you want to delete that?\n\n" + sourcepath,
                            "Confirm deletion",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                    if (result == DialogResult.Yes)
                    {
                        _manager1.Delete(sourcepath);
                        LoadFilesIntoForm(1);
                        LoadFilesIntoForm(2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the Back button click event for the right panel (listView2).
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Navigates to the previous directory in the right panel using the undo stack (<see cref="_history2"/>).
        /// - Updates the current directory and reloads the file list.
        /// - Does nothing if the undo stack is empty.
        /// </remarks>
        private void backbutton2_Click(object sender, EventArgs e)
        {
            if (!_history2.UndoEmpty)
            {
                _directory2 = _history2.Undo();
                LoadFilesIntoForm(2);
            }
        }

        /// <summary>
        /// Handles the Forward button click event for the right panel (listView2).
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Retrieves the next directory from the redo stack (<see cref="_history2"/>).
        /// - Updates the current directory and reloads the right panel.
        /// - Does nothing if the redo stack is empty.
        /// </remarks>
        private void forwardbutton2_Click(object sender, EventArgs e)
        {
            if (!_history2.RedoEmpty)
            {
                _directory2 = _history2.Redo();
                LoadFilesIntoForm(2);
            }
        }

        /// <summary>
        /// Handles the click event for the "Copy to left" button.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Copies the selected file or folder from the right panel (listView2) to the current directory in the left panel.
        /// - If the selected item is a directory ("&lt;DIR&gt;"), the extension is excluded from the path.
        /// - Uses <see cref="_manager2"/> to perform the copy operation.
        /// - Refreshes both panels after the operation.
        /// - Displays a warning if the copy fails due to exceptions (e.g., access denied, file in use).
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and displayed if the copy operation fails unexpectedly.
        /// </exception>
        private void copytoleftbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView2.SelectedItems.Count > 0)
                {
                    string extension = listView2.SelectedItems[0].SubItems[1].Text;
                    if (extension == "<DIR>")
                        extension = "";
                    string sourcepath = _directory2 + "\\" + listView2.SelectedItems[0].SubItems[0].Text + extension;
                    string destinationPath = _directory1 + "\\" + listView2.SelectedItems[0].SubItems[0].Text + extension;
                    _manager2.CopyFile(sourcepath, destinationPath);
                    LoadFilesIntoForm(1);
                    LoadFilesIntoForm(2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the "Move to left" button.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Moves the selected file or folder from the right panel (listView2) to the current directory in the left panel.
        /// - Detects and removes the "<DIR>" extension for folders to construct valid paths.
        /// - Uses <see cref="_manager2"/> to perform the move operation.
        /// - Refreshes both panels after the move.
        /// - Displays a warning message if the move operation fails due to any exception (e.g., permission issues, locked files).
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and displayed if an unexpected error occurs during the move operation.
        /// </exception>
        private void movetoleftbutton_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                try
                {
                    string extension = listView2.SelectedItems[0].SubItems[1].Text;
                    if (extension == "<DIR>")
                        extension = "";
                    string sourcepath = _directory2 + "\\" + listView2.SelectedItems[0].SubItems[0].Text + extension;
                    string destinationPath = _directory1 + "\\" + listView2.SelectedItems[0].SubItems[0].Text + extension;
                    _manager2.MoveFile(sourcepath, destinationPath);
                    LoadFilesIntoForm(1);
                    LoadFilesIntoForm(2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the click event for the "Rename" button in the right panel (listView2).
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Prompts the user for a new name using an input dialog.
        /// - Builds the full source path based on the selected item and current directory.
        /// - Uses <see cref="_manager2"/> to rename the selected file or folder.
        /// - Ignores the operation if the new name is empty or whitespace.
        /// - Refreshes both panels after renaming.
        /// - Displays a warning if the rename operation fails due to an exception.
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and shown to the user if renaming fails unexpectedly.
        /// </exception>
        private void renum2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView2.SelectedItems.Count > 0)
                {
                    string extension = listView2.SelectedItems[0].SubItems[1].Text;
                    if (extension == "<DIR>")
                        extension = "";
                    string sourcepath = _directory2 + "\\" + listView2.SelectedItems[0].SubItems[0].Text + extension;

                    string oldName = listView2.SelectedItems[0].SubItems[0].Text;
                    string newName = Microsoft.VisualBasic.Interaction.InputBox("Enter new name:", "Rename File/Folder", oldName);
                    if (string.IsNullOrWhiteSpace(newName))
                        return;

                    _manager2.Rename(sourcepath, newName);

                    LoadFilesIntoForm(1);
                    LoadFilesIntoForm(2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the "Delete" button in the right panel (listView2).
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Prompts the user for confirmation before deleting the selected file or folder.
        /// - Builds the full path from the selected item's name and extension.
        /// - Uses <see cref="_manager2"/> to perform the deletion.
        /// - Refreshes both panels after deletion if confirmed.
        /// - Displays a warning if the delete operation fails due to exceptions (e.g., file locked or access denied).
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and shown to the user if an error occurs during deletion.
        /// </exception>
        private void delete2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView2.SelectedItems.Count > 0)
                {
                    string extension = listView2.SelectedItems[0].SubItems[1].Text;
                    if (extension == "<DIR>")
                        extension = "";
                    string sourcepath = _directory2 + "\\" + listView2.SelectedItems[0].SubItems[0].Text + extension;

                    DialogResult result = MessageBox.Show(
                            "Are you sure you want to delete that?\n\n" + sourcepath,
                            "Confirm deletion",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                    if (result == DialogResult.Yes)
                    {
                        _manager2.Delete(sourcepath);
                        LoadFilesIntoForm(1);
                        LoadFilesIntoForm(2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Loads an image from a specified relative or absolute file path.
        /// </summary>
        /// <param name="relativeOrFullPath">
        /// The file path to the image. Can be a full path or a path relative to the application's base directory.
        /// </param>
        /// <returns>
        /// A <see cref="Bitmap"/> object representing the loaded image.
        /// </returns>
        /// <remarks>
        /// If the provided path is relative, it is resolved against the application's base directory.
        /// Throws a <see cref="FileNotFoundException"/> if the image file does not exist.
        /// </remarks>
        /// <exception cref="FileNotFoundException">
        /// Thrown if the image file cannot be found at the resolved path.
        /// </exception>
        private Bitmap LoadImage(string relativeOrFullPath)
        {
            string path = Path.IsPathRooted(relativeOrFullPath)
                ? relativeOrFullPath
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeOrFullPath);

            if (!File.Exists(path))
                throw new FileNotFoundException("Image file not found at path: " + path);

            return new Bitmap(path);
        }

        /// <summary>
        /// Retrieves the current sort column index for the specified ListView.
        /// </summary>
        /// <param name="lv">The ListView control (listView1 or listView2).</param>
        /// <returns>
        /// The index of the currently sorted column for the specified panel,
        /// or -1 if the ListView is not recognized.
        /// </returns>
        private int GetSortColumn(ListView lv)
        {
            if (lv == listView1) return _sortColumn1;
            else if (lv == listView2) return _sortColumn2;
            else return -1;
        }

        /// <summary>
        /// Sets the sort column index for the specified ListView control.
        /// </summary>
        /// <param name="lv">The ListView control (listView1 or listView2).</param>
        /// <param name="value">The column index to set as the active sort column.</param>
        /// <remarks>
        /// Updates the internal state used to track which column is currently being sorted.
        /// </remarks>
        private void SetSortColumn(ListView lv, int value)
        {
            if (lv == listView1) _sortColumn1 = value;
            else if (lv == listView2) _sortColumn2 = value;
        }

        /// <summary>
        /// Retrieves the current sort order (ascending or descending) for the specified ListView.
        /// </summary>
        /// <param name="lv">The ListView control (listView1 or listView2).</param>
        /// <returns>
        /// <c>true</c> if the sort is ascending; <c>false</c> if descending;
        /// default is <c>true</c> for unrecognized controls.
        /// </returns>
        private bool GetSortAscending(ListView lv)
        {
            if (lv == listView1) return _sortAscending1;
            else if (lv == listView2) return _sortAscending2;
            else return true;
        }

        /// <summary>
        /// Sets the sort order (ascending or descending) for the specified ListView control.
        /// </summary>
        /// <param name="lv">The ListView control (listView1 or listView2).</param>
        /// <param name="value">
        /// <c>true</c> to set ascending sort order; <c>false</c> for descending.
        /// </param>
        /// <remarks>
        /// Stores the sort direction for use during sorting operations.
        /// </remarks>
        private void SetSortAscending(ListView lv, bool value)
        {
            if (lv == listView1) _sortAscending1 = value;
            else if (lv == listView2) _sortAscending2 = value;
        }

        /// <summary>
        /// Sorts the file items in the specified panel using the selected column and sort direction.
        /// </summary>
        /// <param name="index">1 for the left panel, 2 for the right panel.</param>
        /// <param name="currColumn">The column index to sort by: 0 = Name, 1 = Extension, 2 = Size, 3 = Date.</param>
        /// <param name="ascending">Determines the sort order: <c>true</c> for ascending, <c>false</c> for descending.</param>
        /// <remarks>
        /// - Selects and applies a sorting strategy based on the selected column.
        /// - Updates the corresponding file item list with the sorted result.
        /// - Uses the Strategy design pattern via <see cref="ISortStrategy"/> implementations.
        /// </remarks>
        private void SortItems(int index, int currColumn, bool ascending)
        {
            if (index == 1)
            {
                switch (currColumn)
                {
                    case 0:
                        _strategy1 = new SortByName();
                        break;
                    case 1:
                        _strategy1 = new SortByExtension();
                        break;
                    case 2:
                        _strategy1 = new SortBySize();
                        break;
                    case 3:
                        _strategy1 = new SortByDate();
                        break;
                    default:
                        break;
                }
                _fileItems1 = _strategy1.Sort(_fileItems1, ascending);
            }
            else
            {
                switch (currColumn)
                {
                    case 0:
                        _strategy2 = new SortByName();
                        break;
                    case 1:
                        _strategy2 = new SortByExtension();
                        break;
                    case 2:
                        _strategy2 = new SortBySize();
                        break;
                    case 3:
                        _strategy2 = new SortByDate();
                        break;
                    default:
                        break;
                }
                _fileItems2 = _strategy2.Sort(_fileItems2, ascending);
            }
        }

        /// <summary>
        /// Handles the column click event in a ListView to trigger sorting.
        /// </summary>
        /// <param name="sender">The ListView control where the column was clicked.</param>
        /// <param name="e">Contains information about the clicked column.</param>
        /// <remarks>
        /// - Determines which panel triggered the event (left or right).
        /// - Toggles sort direction if the same column is clicked again.
        /// - Otherwise, sets the new column as the active sort column with ascending order.
        /// - Sorts the items accordingly and refreshes the display.
        /// </remarks>
        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv == null) return;
            int index = (lv == listView1) ? 1 : 2;
            int currentSortColumn = GetSortColumn(lv);
            bool currentSortAscending = GetSortAscending(lv);

            if (e.Column == currentSortColumn)
            {
                currentSortAscending = !currentSortAscending;
            }
            else
            {
                currentSortColumn = e.Column;
                currentSortAscending = true;
            }

            SetSortColumn(lv, currentSortColumn);
            SetSortAscending(lv, currentSortAscending);
            SortItems(index, currentSortColumn, currentSortAscending);
            RefreshList(index);
            lv.Refresh();
        }

        /// <summary>
        /// Customizes the rendering of ListView column headers to include sort direction arrows.
        /// </summary>
        /// <param name="sender">The ListView control whose column header is being drawn.</param>
        /// <param name="e">Provides data for the <see cref="DrawListViewColumnHeaderEventArgs"/> event.</param>
        /// <remarks>
        /// - Highlights the currently sorted column and draws an arrow (up/down) indicating the sort direction.
        /// - Adjusts text positioning based on the arrow size.
        /// - Uses <see cref="_arrowUp"/> and <see cref="_arrowDown"/> bitmaps for visual feedback.
        /// - Disables default drawing to fully control appearance.
        /// </remarks>
        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv == null) return;


            int currentSortColumn = GetSortColumn(lv);
            bool currentSortAscending = GetSortAscending(lv);

            int arrowsize = 16;

            Rectangle textBounds = e.Bounds;

            if (e.ColumnIndex == currentSortColumn)
            {
                e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.Bounds);
                textBounds.X += arrowsize + 4;
                textBounds.Width -= arrowsize + 4;

                int arrowX = e.Bounds.Left + 4;
                int arrowY = e.Bounds.Top + (e.Bounds.Height - arrowsize) / 2;
                Bitmap arrow = currentSortAscending ? _arrowUp : _arrowDown;
                e.Graphics.DrawImage(arrow, arrowX, arrowY, arrowsize, arrowsize);
            }

            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, textBounds, e.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            e.DrawDefault = false;
        }

        /// <summary>
        /// Handles the drawing of a ListView item.
        /// </summary>
        /// <param name="sender">The ListView control that raised the event.</param>
        /// <param name="e">Provides data for the <see cref="DrawListViewItemEventArgs"/> event.</param>
        /// <remarks>
        /// This method uses default drawing behavior by setting <c>e.DrawDefault = true</c>.
        /// Custom drawing can be added if visual customization is needed.
        /// </remarks>
        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /// <summary>
        /// Handles the drawing of a subitem within a ListView row.
        /// </summary>
        /// <param name="sender">The ListView control that raised the event.</param>
        /// <param name="e">Provides data for the <see cref="DrawListViewSubItemEventArgs"/> event.</param>
        /// <remarks>
        /// - Enables default drawing behavior by setting <c>e.DrawDefault = true</c>.
        /// - Allows easy extension for custom subitem rendering if needed in the future.
        /// </remarks>
        private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /// <summary>
        /// Handles the click event for the "Quit" menu item.
        /// </summary>
        /// <param name="sender">The menu item that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Closes the application when the user selects "Quit" from the menu.
        /// </remarks>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the click event for the "About" menu item.
        /// </summary>
        /// <param name="sender">The menu item that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Displays an informational message box describing the application's purpose and features.
        /// </remarks>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "A lightweight file explorer inspired by Total Commander.\nFeatures dual-panel navigation and basic file operations.",
                "About Total Explorer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        /// <summary>
        /// Handles the double-click event on items in the left ListView (listView1).
        /// </summary>
        /// <param name="sender">The ListView control that received the double-click.</param>
        /// <param name="e">Mouse event data.</param>
        /// <remarks>
        /// - If the user double-clicks "[..]", navigates one level up in the directory hierarchy.
        /// - If the item is a directory ("&lt;DIR&gt;"), navigates into that directory and updates history.
        /// - If the item is a file, attempts to open it using the default system application.
        /// - Displays a warning message if an error occurs during navigation or file opening.
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and displayed if directory traversal or file execution fails unexpectedly.
        /// </exception>
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    if (listView1.SelectedItems[0].Index == 0 && listView1.SelectedItems[0].Text == "[..]")
                    {
                        int lastIndex = _directory1.LastIndexOf("\\");
                        if (lastIndex > 2)
                            _directory1 = _directory1.Substring(0, lastIndex);
                        _history1.AddAction(_directory1);
                        LoadFilesIntoForm(1);
                        return;
                    }
                    if (listView1.SelectedItems[0].SubItems[1].Text == "<DIR>")
                    {
                        _directory1 += "\\" + listView1.SelectedItems[0].Text;
                        _history1.AddAction(_directory1);
                        LoadFilesIntoForm(1);
                        RefreshList(1);
                    }
                    else
                    {
                        string filePath = _directory1 + "\\" + listView1.SelectedItems[0].Text + listView1.SelectedItems[0].SubItems[1].Text;
                        if (File.Exists(filePath))
                        {
                            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the double-click event on items in the right ListView (listView2).
        /// </summary>
        /// <param name="sender">The ListView control that received the double-click.</param>
        /// <param name="e">Mouse event data.</param>
        /// <remarks>
        /// - If the user double-clicks "[..]", navigates up one directory level in the right panel.
        /// - If the item is a directory ("&lt;DIR&gt;"), navigates into that directory and updates the history stack.
        /// - If the item is a file, attempts to open it with the default associated application.
        /// - Catches and displays any exceptions encountered during directory navigation or file execution.
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and displayed if an error occurs during path resolution or file opening.
        /// </exception>
        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listView2.SelectedItems.Count > 0)
                {
                    if (listView2.SelectedItems[0].Index == 0 && listView2.SelectedItems[0].Text == "[..]")
                    {
                        int lastIndex = _directory2.LastIndexOf("\\");
                        if (lastIndex > 2)
                            _directory2 = _directory2.Substring(0, lastIndex);
                        _history2.AddAction(_directory2);
                        LoadFilesIntoForm(2);
                        return;
                    }
                    if (listView2.SelectedItems[0].SubItems[1].Text == "<DIR>")
                    {
                        _directory2 += "\\" + listView2.SelectedItems[0].Text;
                        _history2.AddAction(_directory2);
                        LoadFilesIntoForm(2);
                        RefreshList(2);
                    }
                    else
                    {
                        string filePath = _directory2 + "\\" + listView2.SelectedItems[0].Text + listView2.SelectedItems[0].SubItems[1].Text;
                        if (File.Exists(filePath))
                        {
                            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the "Create Folder" button in the left panel.
        /// </summary>
        /// <param name="sender">The button control that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Prompts the user to enter a folder name using an input dialog.
        /// - If the input is valid (not empty or whitespace), creates the folder in the current left panel directory.
        /// - Uses <see cref="_manager1"/> to perform the folder creation.
        /// - Refreshes the left panel after creation.
        /// - Displays a warning if an error occurs during the operation.
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and shown to the user if folder creation fails unexpectedly.
        /// </exception>
        private void createfolderbutton1_Click(object sender, EventArgs e)
        {
            string folderName = Microsoft.VisualBasic.Interaction.InputBox("Enter folder name:", "Create Folder", "NewFolder");
            if (!string.IsNullOrWhiteSpace(folderName))
            {
                try
                {
                    _manager1.CreateFolder(Path.Combine(_directory1, folderName));
                    LoadFilesIntoForm(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the click event for the "Create File" button in the left panel.
        /// </summary>
        /// <param name="sender">The button control that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Prompts the user to enter a file name (including extension) using an input dialog.
        /// - If the input is valid (not null, empty, or whitespace), creates the file in the current left panel directory.
        /// - Uses <see cref="_manager1"/> to perform the file creation.
        /// - Refreshes the left panel after the file is created.
        /// - Displays a warning if the file creation fails due to an exception.
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and shown to the user if file creation fails unexpectedly.
        /// </exception>
        private void createfilebutton1_Click(object sender, EventArgs e)
        {
            string fileName = Microsoft.VisualBasic.Interaction.InputBox("Enter file name (with extension):", "Create File", "NewFile.txt");
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                try
                {
                    _manager1.CreateFile(Path.Combine(_directory1, fileName));
                    LoadFilesIntoForm(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the click event for the "Create Folder" button in the right panel.
        /// </summary>
        /// <param name="sender">The button control that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Prompts the user to enter a folder name using an input dialog.
        /// - If the name is valid, creates the folder in the current right panel directory.
        /// - Uses <see cref="_manager2"/> to perform the folder creation.
        /// - Refreshes the right panel after the folder is created.
        /// - Displays a warning if an error occurs during the operation.
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and shown to the user if folder creation fails unexpectedly.
        /// </exception>
        private void createfolderbutton2_Click(object sender, EventArgs e)
        {
            string folderName = Microsoft.VisualBasic.Interaction.InputBox("Enter folder name:", "Create Folder", "NewFolder");
            if (!string.IsNullOrWhiteSpace(folderName))
            {
                try
                {
                    _manager2.CreateFolder(Path.Combine(_directory2, folderName));
                    LoadFilesIntoForm(2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the click event for the "Create File" button in the right panel.
        /// </summary>
        /// <param name="sender">The button control that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Prompts the user to enter a file name (including extension) using an input dialog.
        /// - If the input is valid, creates the file in the current right panel directory.
        /// - Uses <see cref="_manager2"/> to perform the file creation.
        /// - Refreshes the right panel after the file is created.
        /// - Displays a warning if the file creation fails due to an exception.
        /// </remarks>
        /// <exception cref="Exception">
        /// Caught and shown to the user if file creation fails unexpectedly.
        /// </exception>
        private void createfilebutton2_Click(object sender, EventArgs e)
        {
            string fileName = Microsoft.VisualBasic.Interaction.InputBox("Enter file name (with extension):", "Create File", "NewFile.txt");
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                try
                {
                    _manager2.CreateFile(Path.Combine(_directory2, fileName));
                    LoadFilesIntoForm(2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the click event for the "Help" menu item.
        /// </summary>
        /// <param name="sender">The menu item that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// - Attempts to locate and open the application's help file ("help.chm") from the startup directory.
        /// - If the file exists, opens it using the default help viewer.
        /// - If not found, displays a warning message to the user.
        /// </remarks>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpFilePath = Path.Combine(Application.StartupPath, "help.chm");

            if (File.Exists(helpFilePath))
            {
                Help.ShowHelp(this, helpFilePath);
            }
            else
            {
                MessageBox.Show("Help file wasn't found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
