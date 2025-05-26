/**************************************************************************
 *                                                                        *
 *  File:        ISortStrategy.cs                                                *
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
    public interface ISortStrategy
    {
        List<FileItem> Sort(List<FileItem> files, bool descending = false);
    }
}
