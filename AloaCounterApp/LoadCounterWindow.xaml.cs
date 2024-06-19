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
    public partial class LoadCounterWindow : Window
    {

        public delegate void WindowClosedEventHandler(object sender, EventArgs e);

        public event WindowClosedEventHandler WindowClosed;

        private List<string> countersName { get; set; }

        public LoadCounterWindow()
        {
            InitializeComponent();
            SizeToContent = SizeToContent.WidthAndHeight;

            countersName = Directory.GetDirectories("../../../sessions").Select(Path.GetFileName).ToList();
            foreach (string counterName in countersName)
            {
                comboBox.Items.Add(counterName);
            }

        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            String counterName = countersName.Where(c => c.Equals(comboBox.SelectedValue)).FirstOrDefault();

            {
                MainWindow.currentSession = Session.Session.LoadNewSession(MainWindow.currentSession, counterName);

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
