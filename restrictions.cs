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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PigUnlocker
{
    public partial class restrictions : Form
    {
        public restrictions()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            CheckDebuggerSettings();
            CheckRestrictions();
        }
        private void ListView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = listView1.HitTest(e.Location);
                if (hitTest.Item != null) // Если элемент был нажат
                {
                    listView1.SelectedItems.Clear(); // Снимаем выделение
                    hitTest.Item.Selected = true; // Выделяем элемент
                    contextMenuStrip1.Show(listView1, e.Location); // Показываем меню
                }
            }
        }
        private void CopyLocation_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string registryPath = listView1.SelectedItems[0].SubItems[2].Text; // Получаем путь
                Clipboard.SetText(registryPath); // Копируем в буфер обмена
                MessageBox.Show("Registry path copied to clipboard!");
            }
        }

        private void CheckDebuggerSettings()
        {
            const string debuggerKeyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options";

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(debuggerKeyPath))
            {
                if (key != null)
                {
                    string[] subkeys = key.GetSubKeyNames();
                    foreach (string subkey in subkeys)
                    {
                        using (RegistryKey subkeyHandle = key.OpenSubKey(subkey))
                        {
                            string debuggerValue = subkeyHandle.GetValue("Debugger") as string;
                            if (debuggerValue != null)
                            {
                                string fullRegistryPath = $"{debuggerKeyPath}\\{subkey}";
                                listView1.Items.Add(new ListViewItem(new[] { subkey, debuggerValue, fullRegistryPath }));
                            }
                        }
                    }
                }
            }
        }

        private void CheckRestrictions()
        {
            string[] restrictions = new[]
            {
        // Существующие ограничения
        "DisableTaskMgr",                // Блокирует Диспетчер задач
        "NoControlPanel",                 // Блокирует Панель управления
        "DisableRegistryTools",           // Блокирует Редактор реестра
        "NoRun",                          // Блокирует выполнение программ
        "NoFolderOptions",                // Блокирует параметры папок
        "NoFileMenu",                     // Блокирует пункт "Файл"
        "NoToolbarsOnTaskbar",           // Блокирует панели инструментов
        "NoClose",                        // Блокирует закрытие приложений
        "NoDesktop",                      // Блокирует рабочий стол
        "NoInternetIcon",                 // Блокирует значок Интернета на рабочем столе
        "HideFileExt",                   // Скрывает расширения файлов
        "NoViewOnDesktop",               // Блокирует отображение значков
        "NoWindowsUpdateAlert",           // Блокирует уведомления об обновлениях
        "DisableCMD",                    // Блокирует командную строку
        "NoSharedDocuments",              // Блокировка доступа к общим документам
        "NoNetworkConnections",           // Блокирует доступ к сетевым подключениям
        "DisableTaskbarContextMenu",     // Блокирует контекстное меню панели задач
        "NoThemes",                       // Блокирует изменение тем
        "NoActiveDesktop",                // Блокирует использование активного рабочего стола
        "NoManageMyComputerVerb",         // Блокирует управление компьютером
        "NoChangeStartMenu",              // Блокирует изменение меню «Пуск»
        "NoHelp",                         // Блокирует доступ к справке
        "NoWindowsUpdate",                // Блокирует доступ к обновлениям Windows
        "DisableChangePassword",           // Блокирует изменение пароля
        "DisableLogoff",                 // Блокирует выход
        "NoUserSwitching",               // Блокирует переключение пользователей
        "NoFileSendTo",                  // Блокирует "Отправить" в контекстном меню
        "DisableFolderOptions",           // Блокирует доступ к параметрам папок
        "NoAutoRun",                     // Отключает автозапуск для дисков
        "NoTaskSwitch",                  // Блокирует переключение задач
        "DisableChangeScreenSaver",       // Блокирует изменение заставки
        "NoFileAssociations",             // Блокирует изменение ассоциации файлов
        "NoDeviceManager",                // Блокирует доступ к Диспетчеру устройств
        "NoUpdates",                      // Блокирует доступ к обновлениям Windows
        "NoInternetSettings",             // Блокирует доступ к настройкам Интернета
        "NoPrinter",                      // Блокирует управление принтерами
        "NoNewTask",                     // Блокирует создание новых задач
        "NoTaskbar",                      // Блокирует панель задач
        "NoNetworkDrive",                 // Блокирует доступ к сетевым дискам
        "DisableBluetooth",               // Отключает Bluetooth
        "NoRemoteAccess",                 // Блокирует удаленный доступ
        "NoFolderSharing",                // Блокирует совместное использование папок
        "NoWindowsMediaPlayer",           // Блокирует доступ к Windows Media Player
        "HideComputerIcon",               // Скрывает значок "Компьютер"
        "HideMyDocuments",                // Скрывает значок "Мои документы"
        "HideNetworkIcon",                // Скрывает значок "Сеть"
        "NoAccessTaskManager",            // Блокирует доступ к диспетчеру задач
        "DisableAppNotifications",         // Отключает уведомления приложений
        "NoAccessControlPanel",            // Блокирует доступ к Панели управления
        "NoSettings",                     // Блокирует доступ к настройкам Windows
        "DisableShutdown",                // Блокирует завершение работы
        "NoWindowsExplorer",               // Блокирует Проводник Windows
        "NoDefender",                     // Отключает Windows Defender
        "NoTaskManagerLaunch",            // Блокирует запуск Диспетчера задач
        "NoWindowsSearch",                // Блокирует поиск Windows
        "DisableOnScreenKeyboard",        // Блокирует экранную клавиатуру
        "NoRemoteDesktop",                 // Блокирует удаленный рабочий стол
        "DisableFileTransfer",            // Блокирует передачу файлов
        "NoScreenCapturing",              // Блокирует захват экрана
        "NoActiveX",                      // Блокирует ActiveX
        "NoFlash",                        // Блокирует Flash
        "NoAdvTelemetry",                 // Блокирует отправку телеметрии
        "NoBrowser",                      // Блокирует веб-браузеры
        "NoRemoteDesktopAccess",          // Блокирует доступ к удаленному рабочему столу
        "NoRemoteAssistance",             // Блокирует удаленную помощь
        "DisableWindowsStore",            // Блокирует Windows Store
        "NoCustomThemes",                 // Запрещает использование индивидуальных тем
        "NoExternalDriveAccess",          // Блокирует доступ к внешним дискам
        "DisableUSBStorage",              // Блокирует доступ к USB-накопителям
        "DisableTaskScheduler",           // Блокирует Планировщик задач
        "NoScriptExecution",              // Блокирует выполнение скриптов
        "DisableAccessibilityOptions",     // Блокирует параметры доступности
        "EnableLUA",
        "TaskbarNoPinnedItems",
        "dontdisplaylastusername",
        "HideClock",
        "HideSCAVolume",
        "NoTrayItemsDisplay"
        
        // (Добавьте дополнительные ограничения по желанию)
    };

            var policyPaths = new[]
            {
        @"Software\Microsoft\Windows\CurrentVersion\Policies\System",
        @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer",
        @"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate",
        @"Software\Policies\Microsoft\Windows\System",
        @"Software\Policies\Microsoft\Windows\Installer", // Для установки программ
        @"Software\Microsoft\Windows\CurrentVersion\Policies\Reboot", // Политики перезагрузки
        @"Software\Policies\Microsoft\Windows\Explorer", // Политики Проводника
        @"Software\Policies\Microsoft\Windows\Authentication", // Политики аутентификации
        @"Software\Microsoft\Windows\CurrentVersion\Policies\System\Scripts", // Политики скриптов
        @"Software\Policies\Microsoft\Windows\Defender", // Политики Windows Defender
        @"Software\Policies\Microsoft\Windows\Firewall", // Политики брандмауэра
        @"Software\Microsoft\Windows\CurrentVersion\Policies\Uninstall", // Политики удаления
        @"Software\Policies\Microsoft\Windows\System" // Политики системы
    };

            foreach (var path in policyPaths)
            {
                using (var key = Registry.CurrentUser.OpenSubKey(path, writable: false) ??
                                 Registry.LocalMachine.OpenSubKey(path, writable: false))
                {
                    if (key != null)
                    {
                        foreach (var restriction in restrictions)
                        {
                            var value = key.GetValue(restriction);
                            if (value != null && value.Equals(1))
                            {
                                // Добавляем элемент в ListView
                                listView1.Items.Add(new ListViewItem(new[] { restriction, value.ToString(), $"{path}\\{restriction}" }));
                            }
                        }
                    }
                }
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбран элемент в ListView
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                string itemName = selectedItem.Text; // Имя ограничения или дебаггера
                string path = selectedItem.SubItems[2].Text; // Полный путь к ключу
                // Проверяем, является ли элемент ограничением или дебаггером
                if (path.Contains(@"Policies"))
                {
                    // Удаление ограничения
                    var keyPath = path.Substring(0, path.LastIndexOf('\\')); // Извлекаем путь без имени параметра
                    var keyName = path.Substring(path.LastIndexOf('\\') + 1); // Имя параметра

                    // Открываем ключ реестра с возможностью записи
                    using (var key = Registry.CurrentUser.OpenSubKey(keyPath, writable: true) ??
                                     Registry.LocalMachine.OpenSubKey(keyPath, writable: true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue(keyName, false);
                            MessageBox.Show($"Параметр '{itemName}' был удален из реестра.");
                            listView1.Items.Remove(selectedItem);
                        }
                        else
                        {
                            MessageBox.Show("Ключ не существует.");
                        }
                    }
                }
                else
                {
                    // Удаление дебаггера
                    var debuggerKeyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options";
                    var subkey = itemName; // Имя дебаггера

                    using (var key = Registry.LocalMachine.OpenSubKey(debuggerKeyPath, writable: true))
                    {
                        if (key != null)
                        {
                            key.DeleteSubKey(subkey, false);
                            MessageBox.Show($"Дебаггер '{itemName}' был удален из реестра.");
                            listView1.Items.Remove(selectedItem);
                        }
                        else
                        {
                            MessageBox.Show("Ключ не существует.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.");
            }
        }
    }
}