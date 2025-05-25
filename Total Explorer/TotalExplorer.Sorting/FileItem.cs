using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalExplorer.Sorting
{
    public class FileItem
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTime LastModified { get; set; }
        public string Extension { get; set; }

        public FileItem(string fullName, long size, DateTime lastModified)
        {
            var dotIndex = fullName.LastIndexOf('.');
            if (dotIndex >= 0 && dotIndex < fullName.Length - 1)
            {
                Name = fullName.Substring(0, dotIndex);
                Extension = fullName.Substring(dotIndex + 1);
            }
            else
            {
                Name = fullName;
                Extension = "";
            }

            Size = size;
            LastModified = lastModified;
        }
    }
}
