/**************************************************************************
 *                                                                        *
 *  File:        FileItem.cs                                                *
 *  Copyright:   (c) 2025, Rata Mihai-Gabriel                             *
 *  E-mail:      mihai-gabriel.rata@student.tuiasi.ro                     *
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalExplorer.Sorting
{
    /// <summary>
    /// Represents a file or folder entry with displayable metadata for the file explorer.
    /// </summary>
    /// <remarks>
    /// Contains properties such as name, extension, size, and last modified date,
    /// which are used for listing and sorting items in the UI.
    /// </remarks>
    public class FileItem
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string LastModified { get; set; }
        public string Extension { get; set; }

        public FileItem(string name, string extension, string size, string lastModified)
        {
            Name = name;
            Extension = extension;
            Size = size;
            LastModified = lastModified;
        }
    }
}
