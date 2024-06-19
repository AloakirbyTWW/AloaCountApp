using System;
using System.IO;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewCounterWindow : Window
    {

        public delegate void WindowClosedEventHandler(object sender, EventArgs e);

        public event WindowClosedEventHandler WindowClosed;

        public NewCounterWindow()
        {
            InitializeComponent();
            SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            String name = string.Concat(nameTextBox.Text.Split(Path.GetInvalidFileNameChars())).Replace(' ', '_').Replace('/', '_').Replace('.', '_');
            String strCount = countTextBox.Text;
            int count;
            String strNbToAdd = nbToAddTextBox.Text;
            int nbToAdd;

            if (int.TryParse(strNbToAdd, out nbToAdd) && int.TryParse(strCount, out count))
            {
                Session.Session.CreateSession(name, count, nbToAdd, 0, MainWindow.NO_HOTKEY_STRING, 0, 1);
      
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
