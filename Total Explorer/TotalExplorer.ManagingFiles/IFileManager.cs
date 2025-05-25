using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalExplorer.ManagingFiles
{
    public interface IFileManager
    {
        List<string> GetFilesFromDirectory(string path);
        string GetFileName(string fullPath);
        string GetFileExtension(string fullPath);
        string GetFileDateTime(string fullPath);
        string GetFileSize(string fullPath);
        void Rename(string oldPath, string newName);
        void Delete(string fullPath);
        void MoveFile(string sourcePath, string destinationPath);
        void CopyFile(string sourcePath, string destinationPath);
    }
}
