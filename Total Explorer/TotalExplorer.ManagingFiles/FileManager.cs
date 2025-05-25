using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalExplorer.ManagingFiles
{
    public class FileManager : IFileManager
    {
        public List<string> GetFilesFromDirectory(string path)
        {
            return new List<string>(Directory.GetFiles(path));
        }

        public string GetFileName(string fullPath)
        {
            return Path.GetFileName(fullPath);
        }

        public string GetFileExtension(string fullPath)
        {
            return Path.GetExtension(fullPath);
        }

        public string GetFileDateTime(string fullPath)
        {
            return File.GetLastWriteTime(fullPath).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public string GetFileSize(string fullPath)
        {
            return new FileInfo(fullPath).Length.ToString();
        }

        public void Rename(string oldPath, string newName)
        {
            string directory = Path.GetDirectoryName(oldPath);
            string newPath = Path.Combine(directory, newName);

            if (File.Exists(oldPath))
                File.Move(oldPath, newPath);
            else if (Directory.Exists(oldPath))
                Directory.Move(oldPath, newPath);
            else
                throw new FileNotFoundException($"'{oldPath}' does not exist.");
        }

        public void Delete(string fullPath)
        {
            if (File.Exists(fullPath))
                File.Delete(fullPath);
            else if (Directory.Exists(fullPath))
                Directory.Delete(fullPath, true);
        }

        public void MoveFile(string sourcePath, string destinationPath)
        {
            if (!File.Exists(sourcePath))
                throw new FileNotFoundException($"'{sourcePath}' does not exist.");
            File.Move(sourcePath, destinationPath);
        }

        public void CopyFile(string sourcePath, string destinationPath)
        {
            if (!File.Exists(sourcePath))
                throw new FileNotFoundException($"'{sourcePath}' does not exist.");
            File.Copy(sourcePath, destinationPath, overwrite: true);
        }
    }
}
