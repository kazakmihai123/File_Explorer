using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalExplorer.Sorting
{
    public class SortBySize : ISortStrategy
    {
        public List<FileItem> Sort(List<FileItem> files, bool descending = false)
        {
            return descending
                ? files.OrderByDescending(f => f.Size).ToList()
                : files.OrderBy(f => f.Size).ToList();
        }
    }
}
