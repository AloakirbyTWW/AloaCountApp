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
    public partial class DeleteCounterWindow : Window
    {

        public delegate void WindowClosedEventHandler(object sender, EventArgs e);

        public event WindowClosedEventHandler WindowClosed;

        private List<string> countersName { get; set; }

        public DeleteCounterWindow()
        {
            InitializeComponent();
            SizeToContent = SizeToContent.WidthAndHeight;

            countersName = Directory.GetDirectories("../../../sessions").Select(Path.GetFileName).ToList();
            foreach (string counterName in countersName)
            {
                comboBox.Items.Add(counterName);
            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            String counterName = countersName.Where(c => c.Equals(comboBox.SelectedValue)).FirstOrDefault();

            if (counterName != null)
            {
                MainWindow.oldGlobalHotkey = "" + MainWindow.currentSession.globalHotKey;
                Directory.Delete("../../../sessions/" + counterName, true);
                System.IO.File.WriteAllText("../../../sessions/currentSession.txt", "");

                WindowClosedEventHandler handler = WindowClosed;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }

            Close();
        }

    }
}
