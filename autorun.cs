using Microsoft.Win32;
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

namespace PigUnlocker
{
    public partial class autorun : Form
    {
        public autorun()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillListViewWithStartupItems();
            FillListViewWithStartupItems2();
            LoadRegistryValues();
        }

        private void LoadRegistryValues()
        {
            listView3.Items.Clear();

            try
            {
                // Открытие раздела реестра
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon"))
                {
                    if (key != null)
                    {
                        // Получение значений Shell и Userinit
                        string shellValue = key.GetValue("Shell")?.ToString();
                        string userinitValue = key.GetValue("Userinit")?.ToString();

                        // Добавление Shell в ListView
                        if (shellValue != null)
                        {
                            ListViewItem shellItem = new ListViewItem("Shell");
                            shellItem.SubItems.Add(shellValue);
                            listView3.Items.Add(shellItem);
                        }

                        // Добавление Userinit в ListView
                        if (userinitValue != null)
                        {
                            ListViewItem userinitItem = new ListViewItem("Userinit");
                            userinitItem.SubItems.Add(userinitValue);
                            listView3.Items.Add(userinitItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при чтении реестра: " + ex.Message);
            }
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли выбранный элемент
            if (listView4.SelectedItems.Count > 0)
            {
                // Получаем выбранный элемент
                ListViewItem selectedItem = listView4.SelectedItems[0];

                // Получаем полный путь к файлу
                string filePath = selectedItem.SubItems[1].Text;

                try
                {
                    // Проверяем, существует ли файл перед попыткой удалить его
                    if (System.IO.File.Exists(filePath))
                    {
                        // Удаляем файл (ярлык) из автозагрузки
                        System.IO.File.Delete(filePath);

                        // Удаляем элемент из ListView
                        listView4.Items.Remove(selectedItem);

                        // Уведомляем пользователя об успешном удалении
                        MessageBox.Show("Элемент был успешно удален из автозагрузки.");
                    }
                    else
                    {
                        MessageBox.Show("Файл не существует: " + filePath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("У вас нет прав для удаления этого файла.");
                }
                catch (IOException ioEx)
                {
                    MessageBox.Show("Ошибка ввода/вывода: " + ioEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.");
            }
        }

        private void DeleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.");
                return;
            }

            var selectedItem = listView3.SelectedItems[0];
            string itemName = selectedItem.Text;

            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true))
                {
                    if (key != null)
                    {
                        string currentValue = key.GetValue(itemName)?.ToString();
                        if (currentValue != null)
                        {
                            string newValue = itemName == "Shell" ? RemoveNonExplorer(currentValue) : RemoveNonUserinit(currentValue);
                            key.SetValue(itemName, newValue);
                            MessageBox.Show($"Значение для {itemName} обновлено.");
                            LoadRegistryValues(); // Обновляем список после удаления
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании реестра: " + ex.Message);
            }
        }
        private string RemoveNonExplorer(string shellValue)
        {
            // Удаление всех элементов, кроме explorer.exe
            var values = shellValue.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var newValues = Array.FindAll(values, v => v.Trim().Equals("explorer.exe", StringComparison.OrdinalIgnoreCase));
            String shellvalue = "explorer.exe";
            if (newValues.Length == 0)
            {
                return shellvalue;
            }

            return string.Join(";", newValues);
        }

        private string RemoveNonUserinit(string userinitValue)
        {
            // Удаление всех элементов кроме C:\Windows\system32\userinit.exe
            var values = userinitValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var newValues = Array.FindAll(values, v => v.Trim().Equals(@"C:\Windows\system32\userinit.exe", StringComparison.OrdinalIgnoreCase));
            return string.Join(",", newValues);
        }

        private void contextMenuStrip3_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listView3.SelectedItems.Count == 0)
            {
                e.Cancel = true; // Отключаем меню, если ничего не выбрано
            }
        }

        //
        private void FillListViewWithStartupItems2()
        {
            listView2.Items.Clear(); // Очистка ListView перед добавлением новых элементов

            // Путь к ключам реестра
            string[] registryPaths = new string[]
            {
            @"Software\Microsoft\Windows\CurrentVersion\RunOnce",
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce"
            };

            // Открытие ключа для HKEY_CURRENT_USER
            AddStartupItemsToListView2(Registry.CurrentUser, registryPaths[0]);

            // Открытие ключа для HKEY_LOCAL_MACHINE
            AddStartupItemsToListView2(Registry.LocalMachine, registryPaths[1]);
        }

        private void AddStartupItemsToListView2(RegistryKey baseKey, string subKey)
        {
            using (RegistryKey runKey = baseKey.OpenSubKey(subKey))
            {
                if (runKey != null)
                {
                    // Получение всех значений из ключа Run
                    foreach (string valueName in runKey.GetValueNames())
                    {
                        string valueData = runKey.GetValue(valueName)?.ToString() ?? string.Empty;

                        // Создание нового элемента ListView
                        ListViewItem item = new ListViewItem(valueName); // Значение для первого столбца (Name)
                        item.SubItems.Add(valueData); // Значение для второго столбца (Registry Path)

                        // Добавление элемента в ListView
                        listView2.Items.Add(item);
                    }
                }
            }
        }
        //
        private void FillListViewWithStartupItems()
        {
            listView1.Items.Clear(); // Очистка ListView перед добавлением новых элементов

            // Путь к ключам реестра
            string[] registryPaths = new string[]
            {
            @"Software\Microsoft\Windows\CurrentVersion\Run",
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"
            };

            // Открытие ключа для HKEY_CURRENT_USER
            AddStartupItemsToListView(Registry.CurrentUser, registryPaths[0]);

            // Открытие ключа для HKEY_LOCAL_MACHINE
            AddStartupItemsToListView(Registry.LocalMachine, registryPaths[1]);
        }

        private void AddStartupItemsToListView(RegistryKey baseKey, string subKey)
        {
            using (RegistryKey runKey = baseKey.OpenSubKey(subKey))
            {
                if (runKey != null)
                {
                    // Получение всех значений из ключа Run
                    foreach (string valueName in runKey.GetValueNames())
                    {
                        string valueData = runKey.GetValue(valueName)?.ToString() ?? string.Empty;

                        // Создание нового элемента ListView
                        ListViewItem item = new ListViewItem(valueName); // Значение для первого столбца (Name)
                        item.SubItems.Add(valueData); // Значение для второго столбца (Registry Path)

                        // Добавление элемента в ListView
                        listView1.Items.Add(item);
                    }
                }
            }
        }
        private void ListView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Получение элемента, на котором кликнули правой кнопкой мыши
                ListViewItem item = listView1.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    listView1.SelectedItems.Clear(); // Снятие выделения, чтобы выделить только текущий элемент
                    item.Selected = true; // Выбор элемента
                    contextMenuStrip1.Show(listView1, e.Location); // Показ контекстного меню
                }
            }
        } //contextMenuStrip3
        private void ListView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Получение элемента, на котором кликнули правой кнопкой мыши
                ListViewItem item = listView2.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    listView2.SelectedItems.Clear(); // Снятие выделения, чтобы выделить только текущий элемент
                    item.Selected = true; // Выбор элемента
                    contextMenuStrip2.Show(listView2, e.Location); // Показ контекстного меню
                }
            }
        }
        private void ListView3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Получение элемента, на котором кликнули правой кнопкой мыши
                ListViewItem item = listView3.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    listView3.SelectedItems.Clear(); // Снятие выделения, чтобы выделить только текущий элемент
                    item.Selected = true; // Выбор элемента
                    contextMenuStrip3.Show(listView3, e.Location); // Показ контекстного меню
                }
            }
        }
        private void ListView5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Получение элемента, на котором кликнули правой кнопкой мыши
                ListViewItem item = listView4.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    listView4.SelectedItems.Clear(); // Снятие выделения, чтобы выделить только текущий элемент

                    item.Selected = true; // Выбор элемента

                    contextMenuStrip4.Show(listView4, e.Location); // Показ контекстного меню
                }
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedName = listView1.SelectedItems[0].Text; // Получаем имя выбранного элемента

                // Удаляем ключ из HKEY_CURRENT_USER
                DeleteRegistryValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Run", selectedName);
                // Удаляем ключ из HKEY_LOCAL_MACHINE (при необходимости)
                DeleteRegistryValue(Registry.LocalMachine, @"Software\Microsoft\Windows\CurrentVersion\Run", selectedName);

                // Обновляем ListView
                FillListViewWithStartupItems();
            }
        }

        private void deleteToolStripMenuItem_Click2(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                string selectedName = listView2.SelectedItems[0].Text; // Получаем имя выбранного элемента

                // Удаляем ключ из HKEY_CURRENT_USER
                DeleteRegistryValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\RunOnce", selectedName);
                // Удаляем ключ из HKEY_LOCAL_MACHINE (при необходимости)
                DeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce", selectedName);

                // Обновляем ListView
                FillListViewWithStartupItems2();
            }
        }
        private void DeleteRegistryValue(RegistryKey baseKey, string subKey, string valueName)
        {
            try
            {
                using (RegistryKey key = baseKey.OpenSubKey(subKey, writable: true))
                {
                    if (key != null)
                    {
                        // Пытаемся удалить значение из реестра
                        key.DeleteValue(valueName, throwOnMissingValue: false);
                        MessageBox.Show($"Successfully deleted {valueName} from {subKey}");
                    }
                    else
                    {
                        MessageBox.Show($"Key {subKey} not found.");
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Access denied: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting registry value: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView4.Items.Clear();

            // Определение пути к папке автозагрузки
            string startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            // Получаем все файлы в папке автозагрузки
            string[] startupFiles = System.IO.Directory.GetFiles(startupPath);

            // Заполняем ListView файлами
            foreach (string file in startupFiles)
            {
                // Получаем имя файла
                string fileName = System.IO.Path.GetFileName(file);

                // Создаем новый элемент ListView
                ListViewItem item = new ListViewItem(fileName);

                // Добавляем путь как подэлемент
                item.SubItems.Add(file);

                // Добавляем элемент в ListView
                listView4.Items.Add(item);
            }
        }

        private void deleteToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли выбранный элемент
            if (listView4.SelectedItems.Count > 0)
            {
                // Получаем выбранный элемент
                ListViewItem selectedItem = listView4.SelectedItems[0];
                // Получаем полный путь к файлу
                string filePath = selectedItem.SubItems[1].Text;

                MessageBox.Show("Попытка удалить файл: " + filePath);  // Отладочная информация

                try
                {
                    // Проверяем, существует ли файл перед попыткой удалить его
                    if (System.IO.File.Exists(filePath))
                    {
                        // Удаляем файл (ярлык) из автозагрузки
                        System.IO.File.Delete(filePath);

                        // Удаляем элемент из ListView
                        listView4.Items.Remove(selectedItem);

                        // Уведомляем пользователя об успешном удалении
                        MessageBox.Show("Элемент был успешно удален из автозагрузки.");
                    }
                    else
                    {
                        MessageBox.Show("Файл не существует: " + filePath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("У вас нет прав для удаления этого файла.");
                }
                catch (IOException ioEx)
                {
                    MessageBox.Show("Ошибка ввода/вывода: " + ioEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.");
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                string selectedName = listView2.SelectedItems[0].Text; // Получаем имя выбранного элемента

                // Удаляем ключ из HKEY_CURRENT_USER
                DeleteRegistryValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\RunOnce", selectedName);
                // Удаляем ключ из HKEY_LOCAL_MACHINE (при необходимости)
                DeleteRegistryValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce", selectedName);

                // Обновляем ListView
                FillListViewWithStartupItems2();
            }
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли выбранный элемент
            if (listView4.SelectedItems.Count > 0)
            {
                // Получаем выбранный элемент
                ListViewItem selectedItem = listView4.SelectedItems[0];
                // Получаем полный путь к файлу
                string filePath = selectedItem.SubItems[1].Text;

                MessageBox.Show("Попытка удалить файл: " + filePath);  // Отладочная информация

                try
                {
                    // Проверяем, существует ли файл перед попыткой удалить его
                    if (System.IO.File.Exists(filePath))
                    {
                        // Удаляем файл (ярлык) из автозагрузки
                        System.IO.File.Delete(filePath);

                        // Удаляем элемент из ListView
                        listView4.Items.Remove(selectedItem);

                        // Уведомляем пользователя об успешном удалении
                        MessageBox.Show("Элемент был успешно удален из автозагрузки.");
                    }
                    else
                    {
                        MessageBox.Show("Файл не существует: " + filePath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("У вас нет прав для удаления этого файла.");
                }
                catch (IOException ioEx)
                {
                    MessageBox.Show("Ошибка ввода/вывода: " + ioEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.");
            }
        }
    }
}
