using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PigUnlocker
{
    public partial class FileManager : Form
    {
        private string currentPath;
        private string previousPath;

        public FileManager()
        {
            InitializeComponent();
            LoadDrives();
            InitializeListView();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void InitializeListView()
        {
            listView1.Columns.Add("Имя", 200);
            listView1.Columns.Add("Размер", 100);
            listView1.Columns.Add("Дата изменения", 150);
            listView1.View = View.Details;
            listView1.AllowDrop = true;
            listView1.DragEnter += ListView1_DragEnter;
            listView1.DragDrop += ListView1_DragDrop;
        }

        private void ListView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void ListView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string filePath in files)
            {
                string destFile = Path.Combine(currentPath, Path.GetFileName(filePath));
                File.Copy(filePath, destFile, true);
            }
            LoadFiles(currentPath);
        }

        private void LoadDrives()
        {
            treeView1.Nodes.Clear();
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                TreeNode node = new TreeNode(drive.Name) { Tag = drive };
                treeView1.Nodes.Add(node);
                if (drive.IsReady)
                {
                    LoadDirectories(node);
                }
            }
        }

        private void LoadDirectories(TreeNode node)
        {
            try
            {
                node.Nodes.Clear();
                var directories = Directory.GetDirectories(node.Tag.ToString());
                foreach (var dir in directories)
                {
                    TreeNode newNode = new TreeNode(Path.GetFileName(dir)) { Tag = dir };
                    node.Nodes.Add(newNode);
                    LoadDirectories(newNode);
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            previousPath = currentPath; // Запоминаем предыдущий путь
            currentPath = e.Node.Tag.ToString();
            textBoxCurrentPath.Text = currentPath;
            LoadFiles(currentPath);
        }

        private void LoadFiles(string path)
        {
            listView1.Items.Clear();
            try
            {
                var directories = Directory.GetDirectories(path);
                foreach (var dir in directories)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    listView1.Items.Add(new ListViewItem(new[] { dirInfo.Name, "<DIR>", dirInfo.LastWriteTime.ToString() }) { Tag = dir });
                }

                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    listView1.Items.Add(new ListViewItem(new[] { fileInfo.Name, fileInfo.Length.ToString() + " байт", fileInfo.LastWriteTime.ToString() }) { Tag = file });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                if (Directory.Exists(selectedItem.Tag.ToString()))
                {
                    previousPath = currentPath; // Запоминаем предыдущий путь
                    var path = selectedItem.Tag.ToString();
                    LoadFiles(path);
                    textBoxCurrentPath.Text = path;
                }
                else if (File.Exists(selectedItem.Tag.ToString()))
                {
                    Process.Start(new ProcessStartInfo(selectedItem.Tag.ToString()) { UseShellExecute = true });
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var filePath = listView1.SelectedItems[0].Tag.ToString();
                if (File.Exists(filePath))
                {
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItemPath = listView1.SelectedItems[0].Tag.ToString();

                if (MessageBox.Show("Вы уверены, что хотите удалить этот элемент?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        // Проверяем, является ли элемент папкой или файлом
                        if (Directory.Exists(selectedItemPath))
                        {
                            // Удаляем папку (с её содержимым)
                            Directory.Delete(selectedItemPath, true);
                        }
                        else if (File.Exists(selectedItemPath))
                        {
                            // Удаляем файл
                            File.Delete(selectedItemPath);
                        }

                        // Обновляем список файлов/папок
                        LoadFiles(Path.GetDirectoryName(selectedItemPath));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var filePath = listView1.SelectedItems[0].Tag.ToString();
                Clipboard.SetText(filePath);
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = Clipboard.GetText();
            if (File.Exists(filePath))
            {
                string destFile = Path.Combine(currentPath, Path.GetFileName(filePath));
                File.Copy(filePath, destFile, true);
                LoadFiles(currentPath);
            }
            else if (Directory.Exists(filePath)) // Поддержка вставки папок
            {
                string destDir = Path.Combine(currentPath, Path.GetFileName(filePath));
                CopyDirectory(filePath, destDir);
                LoadFiles(currentPath);
            }
        }

        private void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);

            // Копируем все файлы в директории
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            // Рекурсивно копируем все поддиректории
            foreach (var directory in Directory.GetDirectories(sourceDir))
            {
                string newDestDir = Path.Combine(destDir, Path.GetFileName(directory));
                CopyDirectory(directory, newDestDir);
            }
        }

        private void свойстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var filePath = listView1.SelectedItems[0].Tag.ToString();
                if (File.Exists(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    string properties = $"Имя: {fileInfo.Name}\nРазмер: {fileInfo.Length} байт\nДата изменения: {fileInfo.LastWriteTime}";
                    MessageBox.Show(properties, "Свойства файла");
                }
                else if (Directory.Exists(filePath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(filePath);
                    string properties = $"Имя: {dirInfo.Name}\nПапка\nДата изменения: {dirInfo.LastWriteTime}";
                    MessageBox.Show(properties, "Свойства папки");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(previousPath))
            {
                currentPath = previousPath;
                textBoxCurrentPath.Text = currentPath;
                LoadFiles(currentPath);
                previousPath = Path.GetDirectoryName(currentPath); // Обновляем предыдущий путь
            }
        }

        private void textBoxCurrentPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(textBoxCurrentPath.Text))
                {
                    previousPath = currentPath; // Запоминаем предыдущий путь
                    currentPath = textBoxCurrentPath.Text;
                    LoadFiles(currentPath);
                    treeView1.Nodes.Clear();
                    LoadDrives(); // Обновляем дерево
                }
                else
                {
                    MessageBox.Show("Директория не существует!", "Ошибка");
                }
            }
        }
    }
}