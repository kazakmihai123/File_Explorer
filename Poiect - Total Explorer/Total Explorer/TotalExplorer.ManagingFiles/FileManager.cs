/**************************************************************************
 *                                                                        *
 *  File:        FileManager.cs                                                *
 *  Copyright:   (c) 2025, Paladi Andrei                                  *
 *  E-mail:      andrei.paladi@student.tuiasi.ro                          *
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalExplorer.ManagingFiles
{
    public class FileManager : IFileManager
    {
        /// <summary>
        /// Retrieves all file and directory paths from a given directory.
        /// </summary>
        /// <param name="path">The full path of the directory to scan.</param>
        /// <returns>
        /// A list of strings containing full paths to all files and subdirectories in the specified directory.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">
        /// Thrown if the application does not have permission to access the directory.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">
        /// Thrown if the specified directory does not exist.
        /// </exception>
        /// <exception cref="IOException">
        /// Thrown if an I/O error occurs while accessing the directory.
        /// </exception>
        public List<string> GetFilesFromDirectory(string path)
        {
            List<string> filesAndDirectories = new List<string>(Directory.GetFiles(path));
            filesAndDirectories.AddRange(Directory.GetDirectories(path));
            return filesAndDirectories;
        }

        /// <summary>
        /// Extracts the file or folder name without its extension from a full path.
        /// </summary>
        /// <param name="fullPath">The full path to the file or folder.</param>
        /// <returns>
        /// The name of the file or folder without the extension.
        /// </returns>
        public string GetFileName(string fullPath)
        {
            return Path.GetFileNameWithoutExtension(fullPath);
        }

        /// <summary>
        /// Returns the file extension of the specified path, or "&lt;DIR&gt;" if it is a directory.
        /// </summary>
        /// <param name="fullPath">The full path to the file or directory.</param>
        /// <returns>
        /// The file extension (e.g., ".txt") if the path refers to a file; otherwise, "&lt;DIR&gt;".
        /// </returns>
        public string GetFileExtension(string fullPath)
        {
            if (File.Exists(fullPath))
                return Path.GetExtension(fullPath);
            else
                return "<DIR>";
        }

        /// <summary>
        /// Returns the last modified date and time of a file or directory in a formatted string.
        /// </summary>
        /// <param name="fullPath">The full path to the file or directory.</param>
        /// <returns>
        /// A string representing the last write time in the format "yyyy-MM-dd HH:mm:ss".
        /// </returns>
        public string GetFileDateTime(string fullPath)
        {
            return File.GetLastWriteTime(fullPath).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Returns the size of the specified file in bytes as a string.
        /// </summary>
        /// <param name="fullPath">The full path to the file.</param>
        /// <returns>
        /// A string representing the size of the file in bytes, or an empty string if the path refers to a directory or does not exist.
        /// </returns>
        public string GetFileSize(string fullPath)
        {
            if (File.Exists(fullPath))
                return new FileInfo(fullPath).Length.ToString();
            else
                return "";
        }

        /// <summary>
        /// Renames a file or directory to the specified new name, preserving the original extension if it's a file.
        /// </summary>
        /// <param name="fullpath">The full path of the file or directory to rename.</param>
        /// <param name="newName">The new name to assign (without path).</param>
        /// <remarks>
        /// - If the path points to a file, the extension is preserved.
        /// - If the path points to a directory, only the name is changed.
        /// - Throws an exception if the path does not exist.
        /// </remarks>
        /// <exception cref="FileNotFoundException">
        /// Thrown if the specified path does not exist.
        /// </exception>
        public void Rename(string fullpath, string newName)
        {
            string directory = Path.GetDirectoryName(fullpath);
            string extension = Path.GetExtension(fullpath);
            string newPath = Path.Combine(directory, newName) + extension;

            if (File.Exists(fullpath))
                File.Move(fullpath, newPath);
            else if (Directory.Exists(fullpath))
                Directory.Move(fullpath, newPath);
            else
                throw new FileNotFoundException($"'{fullpath}' does not exist.");
        }

        /// <summary>
        /// Deletes the specified file or directory.
        /// </summary>
        /// <param name="fullPath">The full path of the file or directory to delete.</param>
        /// <remarks>
        /// - If the path points to a file, it is deleted directly.
        /// - If the path points to a directory, it is deleted recursively (including all contents).
        /// - If the path does not exist, no action is taken.
        /// </remarks>
        public void Delete(string fullPath)
        {
            if (File.Exists(fullPath))
                File.Delete(fullPath);
            else if (Directory.Exists(fullPath))
                Directory.Delete(fullPath, true);
        }

        /// <summary>
        /// Moves a file from a source path to a destination path.
        /// </summary>
        /// <param name="sourcePath">The full path of the file to be moved.</param>
        /// <param name="destinationPath">The destination path where the file will be moved.</param>
        /// <remarks>
        /// - Throws an exception if the source file does not exist.
        /// - If an error occurs during the move operation, the original exception message is wrapped and rethrown.
        /// </remarks>
        /// <exception cref="FileNotFoundException">
        /// Thrown if the source file does not exist.
        /// </exception>
        /// <exception cref="Exception">
        /// Thrown if an error occurs during the file move operation.
        /// </exception>
        public void MoveFile(string sourcePath, string destinationPath)
        {
            if (!File.Exists(sourcePath))
                throw new FileNotFoundException($"'{sourcePath}' does not exist.");

            string directory = Path.GetDirectoryName(destinationPath);
            string filename = Path.GetFileNameWithoutExtension(destinationPath);
            string extension = Path.GetExtension(destinationPath);

            string newDestination = destinationPath;

            try
            {
                File.Move(sourcePath, newDestination);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Copies a file from the source path to the destination path, automatically renaming if the file already exists.
        /// </summary>
        /// <param name="sourcePath">The full path of the file to be copied.</param>
        /// <param name="destinationPath">The desired destination path for the copied file.</param>
        /// <remarks>
        /// - If the destination file already exists, appends a numeric suffix to avoid overwriting (e.g., "file (1).txt").
        /// - Throws a <see cref="FileNotFoundException"/> if the source file does not exist.
        /// - Rethrows any other exceptions as a general <see cref="Exception"/> with the original message.
        /// </remarks>
        /// <exception cref="FileNotFoundException">
        /// Thrown if the source file does not exist.
        /// </exception>
        /// <exception cref="Exception">
        /// Thrown if an error occurs during the copy operation.
        /// </exception>
        public void CopyFile(string sourcePath, string destinationPath)
        {
            try
            {
                if (!File.Exists(sourcePath))
                    throw new FileNotFoundException($"'{sourcePath}' does not exist.");
                string directory = Path.GetDirectoryName(destinationPath);
                string filename = Path.GetFileNameWithoutExtension(destinationPath);
                string extension = Path.GetExtension(destinationPath);

                string newDestination = destinationPath;
                int counter = 1;

                while (File.Exists(newDestination))
                {
                    string newFileName = $"{filename} ({counter}){extension}";
                    newDestination = Path.Combine(directory, newFileName);
                    counter++;
                }

                File.Copy(sourcePath, newDestination);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new folder at the specified path. If a folder with the same name already exists,
        /// appends a numeric suffix to create a unique name (e.g., "NewFolder (1)").
        /// </summary>
        /// <param name="path">The desired full path of the folder to create.</param>
        /// <remarks>
        /// - Checks if the folder already exists and increments a counter until a unique folder name is found.
        /// - Uses <see cref="Directory.CreateDirectory(string)"/> to create the folder.
        /// </remarks>
        public void CreateFolder(string path)
        {
            string directory = Path.GetDirectoryName(path);
            string folderName = Path.GetFileName(path);

            string newPath = path;
            int counter = 1;

            while (Directory.Exists(newPath))
            {
                string newFolderName = $"{folderName} ({counter})";
                newPath = Path.Combine(directory, newFolderName);
                counter++;
            }

            Directory.CreateDirectory(newPath);
        }

        /// <summary>
        /// Creates a new file at the specified path. If a file with the same name already exists,
        /// appends a numeric suffix to create a unique file name (e.g., "NewFile (1).txt").
        /// </summary>
        /// <param name="path">The desired full path of the file to create, including extension.</param>
        /// <remarks>
        /// - If a file already exists at the given path, iterates with numeric suffixes until an available name is found.
        /// - Creates the file using <see cref="File.Create(string)"/> and immediately disposes it.
        /// </remarks>
        public void CreateFile(string path)
        {
            string directory = Path.GetDirectoryName(path);
            string filename = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);

            string newPath = path;
            int counter = 1;

            while (File.Exists(newPath))
            {
                string newFileName = $"{filename} ({counter}){extension}";
                newPath = Path.Combine(directory, newFileName);
                counter++;
            }

            using (File.Create(newPath)) { }
        }
    }
}