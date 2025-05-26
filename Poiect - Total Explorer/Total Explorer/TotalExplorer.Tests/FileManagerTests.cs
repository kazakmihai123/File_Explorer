/**************************************************************************
 *                                                                        *
 *  File:        FileManagerTests.cs                                                *
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
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TotalExplorer.ManagingFiles;

namespace TotalExplorer.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="FileManager"/> class.
    /// </summary>
    /// <remarks>
    /// Covers scenarios such as file/folder creation, deletion, renaming, copying, moving,
    /// and metadata extraction (name, extension, size, date).
    /// Also includes tests for error handling and edge cases.
    /// </remarks>
    [TestClass]
    public class FileManagerTests
    {
        private FileManager _manager;
        private string _baseDir;

        [TestInitialize]
        public void Setup()
        {
            _manager = new FileManager();
            _baseDir = Path.Combine(Path.GetTempPath(), "TotalExplorerTest");

            if (Directory.Exists(_baseDir))
                Directory.Delete(_baseDir, true);

            Directory.CreateDirectory(_baseDir);
        }

        [TestCleanup]
        public void Teardown()
        {
            if (Directory.Exists(_baseDir))
                Directory.Delete(_baseDir, true);
        }

        [TestMethod]
        public void GetFilesFromDirectory_ReturnsCorrectFiles()
        {
            string path = Path.Combine(_baseDir, "file.txt");
            File.WriteAllText(path, "test");

            var files = _manager.GetFilesFromDirectory(_baseDir);
            Assert.AreEqual(1, files.Count);
        }

        [TestMethod]
        public void GetFileName_ReturnsCorrectName()
        {
            string path = @"C:\folder\test.txt";
            Assert.AreEqual("test", _manager.GetFileName(path));
        }

        [TestMethod]
        public void GetFileExtension_ReturnsCorrectExtension()
        {
            string path = Path.Combine(_baseDir, "test.pdf");
            File.WriteAllText(path, "dummy");

            Assert.AreEqual(".pdf", _manager.GetFileExtension(path));
        }

        [TestMethod]
        public void GetFileSize_ReturnsNonZeroSize()
        {
            string path = Path.Combine(_baseDir, "file.txt");
            File.WriteAllText(path, "123456");
            string size = _manager.GetFileSize(path);
            Assert.IsTrue(long.Parse(size) > 0);
        }

        [TestMethod]
        public void GetFileDateTime_ReturnsValidDate()
        {
            string path = Path.Combine(_baseDir, "file.txt");
            File.WriteAllText(path, "data");
            string date = _manager.GetFileDateTime(path);
            Assert.IsTrue(date.Contains("-"));
        }

        [TestMethod]
        public void CreateFile_FileIsCreated()
        {
            string file = Path.Combine(_baseDir, "new.txt");
            _manager.CreateFile(file);
            Assert.IsTrue(File.Exists(file));
        }

        [TestMethod]
        public void CreateFolder_FolderIsCreated()
        {
            string folder = Path.Combine(_baseDir, "folder");
            _manager.CreateFolder(folder);
            Assert.IsTrue(Directory.Exists(folder));
        }

        [TestMethod]
        public void DeleteFile_FileIsDeleted()
        {
            string file = Path.Combine(_baseDir, "delete.txt");
            File.WriteAllText(file, "remove");
            _manager.Delete(file);
            Assert.IsFalse(File.Exists(file));
        }

        [TestMethod]
        public void DeleteDirectory_DirectoryIsDeleted()
        {
            string dir = Path.Combine(_baseDir, "subfolder");
            Directory.CreateDirectory(dir);
            _manager.Delete(dir);
            Assert.IsFalse(Directory.Exists(dir));
        }

        [TestMethod]
        public void RenameFile_FileIsRenamed()
        {
            string file = Path.Combine(_baseDir, "old.txt");
            File.WriteAllText(file, "content");
            _manager.Rename(file, "new");

            string newPath = Path.Combine(_baseDir, "new.txt");
            Assert.IsTrue(File.Exists(newPath));
        }

        [TestMethod]
        public void RenameDirectory_DirectoryIsRenamed()
        {
            string dir = Path.Combine(_baseDir, "dirOld");
            Directory.CreateDirectory(dir);
            _manager.Rename(dir, "dirNew");

            string newDir = Path.Combine(_baseDir, "dirNew");
            Assert.IsTrue(Directory.Exists(newDir));
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Rename_InvalidPath_Throws()
        {
            _manager.Rename(Path.Combine(_baseDir, "nope.txt"), "new.txt");
        }

        [TestMethod]
        public void CopyFile_FileIsCopied()
        {
            string source = Path.Combine(_baseDir, "copy.txt");
            string dest = Path.Combine(_baseDir, "copied.txt");
            File.WriteAllText(source, "copy");

            _manager.CopyFile(source, dest);
            Assert.IsTrue(File.Exists(dest));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CopyFile_SourceNotExists_Throws()
        {
            _manager.CopyFile("nope.txt", "dest.txt");
        }

        [TestMethod]
        public void MoveFile_FileIsMoved()
        {
            string source = Path.Combine(_baseDir, "move.txt");
            string dest = Path.Combine(_baseDir, "moved.txt");
            File.WriteAllText(source, "move");

            _manager.MoveFile(source, dest);
            Assert.IsTrue(File.Exists(dest));
            Assert.IsFalse(File.Exists(source));
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void MoveFile_SourceNotExists_Throws()
        {
            _manager.MoveFile("nope.txt", "dest.txt");
        }

        [TestMethod]
        public void GetFilesFromEmptyDirectory_ReturnsEmptyList()
        {
            string dir = Path.Combine(_baseDir, "empty");
            Directory.CreateDirectory(dir);

            var files = _manager.GetFilesFromDirectory(dir);
            Assert.AreEqual(0, files.Count);
        }

        [TestMethod]
        public void CreateFile_ThenGetSize()
        {
            string file = Path.Combine(_baseDir, "sizecheck.txt");
            File.WriteAllText(file, "1234");

            string size = _manager.GetFileSize(file);
            Assert.AreEqual("4", size);
        }

        [TestMethod]
        public void Delete_NonExistingFile_DoesNothing()
        {
            // should not throw exception
            _manager.Delete(Path.Combine(_baseDir, "notfound.txt"));
        }

        [TestMethod]
        public void Rename_FileToExistingName_Overwrites()
        {
            string file1 = Path.Combine(_baseDir, "file1.txt");
            string file2 = Path.Combine(_baseDir, "file2.txt");
            File.WriteAllText(file1, "one");
            File.WriteAllText(file2, "two");

            _manager.Delete(file2);
            _manager.Rename(file1, "file2");

            Assert.IsTrue(File.Exists(file2));
            Assert.IsFalse(File.Exists(file1));
        }
    }
}
