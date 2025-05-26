/**************************************************************************
 *                                                                        *
 *  File:        History.cs                                                *
 *  Copyright:   (c) 2025, Timofte Alin-Gabriel                           *
 *  E-mail:      alin-gabriel.timofte@student.tuiasi.ro                   *
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

namespace History
{
    /// <summary>
    /// Manages navigation history for directory browsing, enabling undo and redo functionality.
    /// </summary>
    /// <remarks>
    /// The <c>History</c> class tracks the current directory path and maintains two internal stacks:
    /// one for undo operations and one for redo. Each time a directory change is made,
    /// the current path is pushed to the undo stack. Undo operations move paths to the redo stack,
    /// and redo operations restore them back.
    /// </remarks>
    public class History
    {
        private string _currentPath;
        private Stack<string> _undoStack = new Stack<string>();
        private Stack<string> _redoStack = new Stack<string>();
        public History(string path)
        {
            _currentPath = path;
        }

        /// <summary>
        /// Indicates whether the redo stack is empty.
        /// </summary>
        /// <returns><c>true</c> if there are no redo actions available; otherwise, <c>false</c>.</returns>
        public bool RedoEmpty
        {
            get { return (_redoStack.Count == 0)? true : false; }
        }

        /// <summary>
        /// Indicates whether the undo stack is empty.
        /// </summary>
        /// <returns><c>true</c> if there are no undo actions available; otherwise, <c>false</c>.</returns>
        public bool UndoEmpty
        {
            get { return (_undoStack.Count == 0) ? true : false; }
        }

        /// <summary>
        /// Adds a new navigation action to the undo stack and clears the redo stack.
        /// </summary>
        /// <param name="path">The new directory path to navigate to.</param>
        /// <remarks>
        /// This method updates the current path and stores the previous one in the undo history,
        /// ensuring redo is reset after any new navigation.
        /// </remarks>
        public void AddAction(string path)
        {
            if (Directory.Exists(path))
            {
                _undoStack.Push(_currentPath);
                _currentPath = path;
                _redoStack.Clear();
            }
        }

        /// <summary>
        /// Reverts the last navigation action by popping from the undo stack and pushing to the redo stack.
        /// </summary>
        /// <returns>The previous path if available; otherwise, <c>null</c>.</returns>
        public string Undo()
        {
            if (_undoStack.Count > 0)
            {
                string lastPath = _undoStack.Pop();
                _redoStack.Push(_currentPath);
                _currentPath = lastPath;
                return lastPath;
            }
            return null;
        }

        /// <summary>
        /// Reapplies the last undone navigation action by popping from the redo stack and pushing to the undo stack.
        /// </summary>
        /// <returns>The redone path if available; otherwise, <c>null</c>.</returns>
        public string Redo()
        {
            if (_redoStack.Count > 0)
            {
                string path = _redoStack.Pop();
                _undoStack.Push(_currentPath);
                _currentPath = path;
                return path;
            }
            return null;
        }
    }
}