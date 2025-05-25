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
