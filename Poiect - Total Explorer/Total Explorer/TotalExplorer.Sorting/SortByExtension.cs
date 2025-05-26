/**************************************************************************
 *                                                                        *
 *  File:        SortByExtension.cs                                                *
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
    public class SortByExtension : ISortStrategy
    {
        /// <summary>
        /// Sorts a list of <see cref="FileItem"/> objects by file extension.
        /// </summary>
        /// <param name="files">The list of files to sort.</param>
        /// <param name="descending">
        /// Indicates whether the sorting should be in descending order.
        /// <c>true</c> = Z to A, <c>false</c> = A to Z (default).
        /// </param>
        /// <returns>A new list of <see cref="FileItem"/> objects sorted by extension.</returns>
        public List<FileItem> Sort(List<FileItem> files, bool descending = false)
        {
            return descending
                ? files.OrderByDescending(f => f.Extension).ToList()
                : files.OrderBy(f => f.Extension).ToList();
        }
    }
}
