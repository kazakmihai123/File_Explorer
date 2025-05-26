/**************************************************************************
 *                                                                        *
 *  File:        SortByDate.cs                                                *
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
    public class SortByDate : ISortStrategy
    {
        /// <summary>
        /// Sorts a list of <see cref="FileItem"/> objects by last modified date.
        /// </summary>
        /// <param name="files">The list of files to sort.</param>
        /// <param name="descending">
        /// Indicates whether the sorting should be in descending order.
        /// <c>true</c> = newest first,
        /// <c>false</c> = oldest first (default).
        /// </param>
        /// <returns>
        /// A new sorted list of <see cref="FileItem"/> objects.
        /// </returns>
        public List<FileItem> Sort(List<FileItem> files, bool descending = false)
        {
            return descending
                ? files.OrderByDescending(f => f.LastModified).ToList()
                : files.OrderBy(f => f.LastModified).ToList();
        }
    }
}
