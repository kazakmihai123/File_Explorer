# Total Explorer

Total Explorer is a lightweight file manager developed in C# using Windows Forms. Inspired by **Total Commander** and the default **Windows File Explorer**, it provides a dual-pane interface for efficient file navigation and manipulation. It includes support for sorting, drag-and-drop, undo-redo history, and common file operations like copy, move, delete, and rename.

---

## ✨ Features

* 🔀 **Dual-panel UI** – Compare and transfer files between directories easily.
* 🧽 **Navigation History** – Undo/redo navigation using custom history stacks.
* 🔍 **Sorting Options** – Sort files by name, size, date, or extension (via Strategy Pattern).
* 📁 **File Operations** – Copy, move, rename, delete, and open files or folders.
* 🔁 **Drag-and-Drop** – Move files between panes using drag-and-drop.
* 💬 **Help Menu** – Integrated help viewer.
* 🧩 **Design Patterns Used**:

  * **Strategy** – For sorting methods (`ISortStrategy`, `SortByName`, `SortBySize`, etc.).
  * **Adapter** (planned) – For future compatibility with different file system providers.

---

## 🛠️ Technologies

* Language: **C#**
* Framework: **.NET 8.0**
* UI: **Windows Forms**
* Target Platform: **Windows x86 / x64**

---

## 🚀 Getting Started

### Prerequisites

* Windows 7 or later
* [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Run Locally

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/TotalExplorer.git
   cd TotalExplorer
   ```

2. Open the solution (`TotalExplorer.sln`) in **Visual Studio 2022** or later.

3. Build the solution by pressing `Ctrl + Shift + B`.

4. Run the application by pressing `F5` or clicking the **Start** button.

---

## 📂 Project Structure

```plaintext
TotalExplorer/
├── Sorting/
│   ├── ISortStrategy.cs
│   ├── SortByName.cs
│   ├── SortBySize.cs
│   ├── SortByExtension.cs
│   └── SortByDate.cs
├── ManagingFiles/
│   ├── IFileManager.cs
│   └── FileManager.cs
├── Forms/
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   └── Program.cs
├── Assets/
│   └── images/         # Contains icons for folders, files, etc.
├── Documentation/
│   └── IP_Documentation.doc
└── TotalExplorer.sln   # Visual Studio Solution File
```

---

## 👥 Team Members

* **Andrei Ciobanu** – [andrei.ciobanu4@student.tuiasi.ro](mailto:andrei.ciobanu4@student.tuiasi.ro)
* **Alin-Gabriel Timofte** – [alin-gabriel.timofte@student.tuiasi.ro](mailto:alin-gabriel.timofte@student.tuiasi.ro)
* **Mihai-Gabriel Rață** – [mihai-gabriel.rata@student.tuiasi.ro](mailto:mihai-gabriel.rata@student.tuiasi.ro)
* **Andrei Paladi** – [andrei.paladi@student.tuiasi.ro](mailto:andrei.paladi@student.tuiasi.ro)

---

## 🧚‍♂️ Testing

Unit testing is under development and will cover:

* Sorting strategies
* File manager operations (rename, delete, move, copy)
* Undo/redo logic

---

## 📜 License

This project is licensed under the [GNU General Public License](https://www.gnu.org/licenses/gpl-3.0.en.html) v3.0. See the `LICENSE` file for more details.

---

## 📘️ References

* [.NET C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)
* [Windows Forms Guide](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
* [Total Commander](https://www.ghisler.com/)
