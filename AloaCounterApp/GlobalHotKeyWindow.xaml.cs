using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GlobalHotKeyWindow : Window
    {

        public delegate void WindowClosedEventHandler(object sender, EventArgs e);

        public event WindowClosedEventHandler WindowClosed;

        private List<string> keys { get; set; }

        private List<string> modifiers { get; set; }

        public GlobalHotKeyWindow()
        {
            InitializeComponent();
            SizeToContent = SizeToContent.WidthAndHeight;

            keys = Enum.GetNames(typeof(System.Windows.Input.Key)).ToList();

            foreach (String key in keys)
            {
                keysComboBox.Items.Add(key);
            }

            modifiers = Enum.GetNames(typeof(System.Windows.Input.ModifierKeys)).ToList();

            foreach (String modifier in modifiers)
            {
                modifiersComboBox.Items.Add(modifier);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.oldGlobalHotkey = "" + MainWindow.currentSession.globalHotKey;

            string newKey = keys.Where(k => k.Equals(keysComboBox.SelectedValue)).FirstOrDefault();
            string newModifier = modifiers.Where(m => m.Equals(modifiersComboBox.SelectedValue)).FirstOrDefault();

            if (newKey == null || newModifier == null)
            {
                System.IO.File.WriteAllText("../../../sessions/" + MainWindow.currentSession.name + "/globalHotKey.txt", "" + MainWindow.NO_HOTKEY + " " + MainWindow.NO_HOTKEY);
            }
            else
            {
                System.IO.File.WriteAllText("../../../sessions/" + MainWindow.currentSession.name + "/globalHotKey.txt", "" + newModifier + " " + newKey);
            }

            WindowClosedEventHandler handler = WindowClosed;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }

            Close();
        }

    }
}
