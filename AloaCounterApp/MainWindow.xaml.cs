using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using KeyDownTester.Keys;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string NO_HOTKEY = "NOPENOPE";
        public static string NO_HOTKEY_STRING = "NOPENOPE NOPENOPE";

        public static string oldGlobalHotkey = "NOPENOPE NOPENOPE";

        //TO DO => check that the currentSession exits and manage the case where it does not.

        public static Session.Session currentSession = Session.Session.LoadCurrentSession(ReadStringFromTxt("../../../sessions/currentSession.txt"), true);

        public MainWindow()
        {
            InitializeComponent();
            SizeToContent = SizeToContent.WidthAndHeight;

            UpdateGlobalHotKeys(currentSession.globalHotKey);
            currentCounter.Content = "Current Counter : " + currentSession.name;

            Add(0);

            // need to setup the global hook. this can go in
            // App.xaml.cs's constructor if you want
            HotkeysManager.SetupSystemHook();
            HotkeysManager.RequiresModifierKey = false;

            // You can create a globalhotkey object and pass it like so
            //HotkeysManager.AddHotkey(new GlobalHotkey(ModifierKeys.Control, Key.S, () => { AddToList("Ctrl+S Fired"); }));

            // or do it like this. both end up doing the same thing, but this is probably simpler.
            HotkeysManager.AddHotkey(ModifierKeys.None, Key.NumPad9, () => { AddToList("NumPad9 Fired"); });
            HotkeysManager.RemoveHotkey(ModifierKeys.None, Key.NumPad9);

            //Change that name that is not legal on XAML
            timeButton.Content = "Counter <=> Time";

            //Closing the hook otherwise there's a risk of memory leak
            Closing += MainWindow_Closing;
        }

        public void AddToList(string content)
        {
            //A rajouter dans le xmal si je veux avoir un double check
            //hotkeysFired.Items.Add(content);
            Add(currentSession.nbToAdd);
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0)
            {
                MessageBox.Show("Child windows exists, you have to close them first");
                e.Cancel = true;
            }

            // Need to shutdown the hook. idk what happens if
            // you dont, but it might cause a memory leak.
            HotkeysManager.ShutdownSystemHook();
        }

        private void TimeButton_Click(object sender, RoutedEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0)
            {
                MessageBox.Show("Child windows exists, you have to close them first");
            }

            if (currentSession.name != "")
            {           
                currentSession = Session.Session.LoadCurrentSession(ReadStringFromTxt("../../../sessions/currentSession.txt"), false);
                currentCounter.Content = "Current Counter : " + currentSession.name;

                currentSession.timeDisplay = !currentSession.timeDisplay;
                int i = currentSession.timeDisplay ? 1 : 0;
                System.IO.File.WriteAllText("../../../sessions/" + currentSession.name + "/timeDisplay.txt", "" + i);
                Add(0);
            }
        }

        private void FontButton_Click(object sender, RoutedEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0)
            {
                MessageBox.Show("Child windows exists, you have to close them first");
            }

            if (currentSession.name != "")
            {
                currentSession = Session.Session.LoadCurrentSession(ReadStringFromTxt("../../../sessions/currentSession.txt"), false);
                currentCounter.Content = "Current Counter : " + currentSession.name;

                int font = currentSession.font;
                font = (font + 1) % 4;

                currentSession.font = font;
                System.IO.File.WriteAllText("../../../sessions/" + currentSession.name + "/font.txt", "" + font);
                Add(0);
            }
        }

        private void SizeButton_Click(object sender, RoutedEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0)
            {
                MessageBox.Show("Child windows exists, you have to close them first");
            }

            if (currentSession.name != "")
            {    
                currentSession = Session.Session.LoadCurrentSession(ReadStringFromTxt("../../../sessions/currentSession.txt"), false);
                currentCounter.Content = "Current Counter : " + currentSession.name;

                int size = currentSession.size;
                size = (size + 1) % 3;

                currentSession.size = size;
                System.IO.File.WriteAllText("../../../sessions/" + currentSession.name + "/size.txt", "" + size);

                Add(0);
            }
        }

        private void GlobalHotKey_Click(object sender, RoutedEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0) { MessageBox.Show("Child windows exists, you have to close them first");
            } else {
                if (currentSession.name != "")
                {
                    GlobalHotKeyWindow globalHotKeyWindow = new GlobalHotKeyWindow();
                    globalHotKeyWindow.Owner = this;
                    globalHotKeyWindow.WindowClosed += GlobalHotKeyWindow_Closed;
                    globalHotKeyWindow.Show();
                }
            }
        }
        private void GlobalHotKeyWindow_Closed(object sender, EventArgs e)
        {
            currentSession = Session.Session.LoadCurrentSession(ReadStringFromTxt("../../../sessions/currentSession.txt"), false);
            currentCounter.Content = "Current Counter : " + currentSession.name;

            UpdateGlobalHotKeys(currentSession.globalHotKey);

            Add(0);
        }

        private void LoadCounter_Click(object sender, RoutedEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0) { MessageBox.Show("Child windows exists, you have to close them first");
            } else {
                LoadCounterWindow LoadCounterWindow = new LoadCounterWindow();
                LoadCounterWindow.Owner = this;
                LoadCounterWindow.WindowClosed += LoadCounterWindow_Closed;
                LoadCounterWindow.Show();
            }
        }
        private void LoadCounterWindow_Closed(object sender, EventArgs e)
        {
            currentCounter.Content = "Current Counter : " + currentSession.name;
            UpdateGlobalHotKeys(currentSession.globalHotKey);
            UpdateSession(0, true);
        }

        private void NewCounter_Click(object sender, RoutedEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0) { MessageBox.Show("Child windows exists, you have to close them first");
            } else {
                NewCounterWindow NewCounterWindow = new NewCounterWindow();
                NewCounterWindow.Owner = this;
                NewCounterWindow.WindowClosed += NewCounterWindow_Closed;
                NewCounterWindow.Show();
            }
        }
        private void NewCounterWindow_Closed(object sender, EventArgs e)
        {
            currentSession = Session.Session.LoadCurrentSession(ReadStringFromTxt("../../../sessions/currentSession.txt"), false);
            currentCounter.Content = "Current Counter : " + currentSession.name;

            UpdateGlobalHotKeys(currentSession.globalHotKey);

            Add(0);
        }


        private void DeleteCounter_Click(object sender, RoutedEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0)
            {
                MessageBox.Show("Child windows exists, you have to close them first");
            }
            else
            {
                DeleteCounterWindow DeleteCounterWindow = new DeleteCounterWindow();
                DeleteCounterWindow.Owner = this;
                DeleteCounterWindow.WindowClosed += DeleteCounterWindow_Closed;
                DeleteCounterWindow.Show();
            }
        }
        private void DeleteCounterWindow_Closed(object sender, EventArgs e)
        {
            string[] oldGlobalHotKeys = oldGlobalHotkey.Split(" ");

            if (!(oldGlobalHotKeys[0].Equals(NO_HOTKEY) || oldGlobalHotKeys[1].Equals(NO_HOTKEY)))
            {
                HotkeysManager.RemoveHotkey(
                    (ModifierKeys)Enum.Parse(typeof(ModifierKeys), oldGlobalHotKeys[0]),
                    (Key)Enum.Parse(typeof(Key), oldGlobalHotKeys[1])
                    );

                currentGlobalHotKey.Content = "None + None";
            }

            currentSession = Session.Session.LoadCurrentSession(ReadStringFromTxt("../../../sessions/currentSession.txt"), false);
            currentCounter.Content = "Current Counter : " + currentSession.name;

            UpdateSession(0, true);
        }

        private void WhiteButton_Click(object sender, RoutedEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0)
            {
                MessageBox.Show("Child windows exists, you have to close them first");
            }
            else
            {
                counter.Foreground = new SolidColorBrush(Colors.White);
            }
            
        }

        private void BlackButton_Click(object sender, RoutedEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0)
            {
                MessageBox.Show("Child windows exists, you have to close them first");
            }
            else
            {
                counter.Foreground = new SolidColorBrush(Colors.Black);
            }
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0)
            {
                MessageBox.Show("Child windows exists, you have to close them first");
            }
            else
            {
                Add(currentSession.nbToAdd);
            }
            
        }

        private void SubButton_Click(object sender, RoutedEventArgs e)
        {
            //Prevent closing if child window is still open
            if (this.OwnedWindows.Count > 0)
            {
                MessageBox.Show("Child windows exists, you have to close them first");
            }
            else
            {
                Sub(currentSession.nbToAdd);
            }        
        }

        private void Add(int milliToAdd)
        {
            UpdateSession(milliToAdd, true);
        }

        private void Sub(int milliToAdd)
        {
            UpdateSession(milliToAdd, false);
        }

        private void UpdateSession(int milliToAdd, Boolean isAddition)
        {
            //count
            if (isAddition)
            {
                currentSession.count += milliToAdd;
            }
            else
            {
                currentSession.count -= milliToAdd;
            }
            currentSession.SaveSession(currentSession);

            //timeDisplay
            currentTimeORCounter.Content = currentSession.timeDisplay ? "Time" : "Counter";
            if (currentSession.timeDisplay)
            {
                TimeSpan time = TimeSpan.FromMilliseconds(currentSession.count);
                string str = time.ToString(@"d\D\ hh\H\ mm\m\ ss\.fff"); //string str = time.ToString(@"dd\D\ hh\H\ mm\m\ ss\.fff");
                counter.Content = str;
            }
            else
            {
                counter.Content = currentSession.count.ToString();
            }

            //font
            switch (currentSession.font)
            {
                case 0:
                    counter.FontFamily = new FontFamily("Sherwood");
                    currentFont.Content = "Sherwood";
                    break;
                case 1:
                    counter.FontFamily = new FontFamily("Arial Black");
                    currentFont.Content = "Arial Black";
                    break;
                case 2:
                    counter.FontFamily = new FontFamily("Calibri");
                    currentFont.Content = "Calibri";
                    break;
                case 3:
                    counter.FontFamily = new FontFamily("Segoe UI");
                    currentFont.Content = "Segoe UI";
                    break;
            }

            //size
            currentSize.Content = currentSession.size + 1;
            counter.FontSize = 18 * (currentSession.size + 2);
            counter.Height = 28 * (currentSession.size + 2);
            counter.Width = 290 * (currentSession.size + 2);
            SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void UpdateGlobalHotKeys(String newGlobalHotKey)
        {
            string[] newGlobalHotKeys = newGlobalHotKey.Split(" ");   
            string[] oldGlobalHotKeys = oldGlobalHotkey.Split(" ");

            if (!(oldGlobalHotKeys[0].Equals(NO_HOTKEY) || oldGlobalHotKeys[1].Equals(NO_HOTKEY)))
            {
                HotkeysManager.RemoveHotkey(
                    (ModifierKeys)Enum.Parse(typeof(ModifierKeys), oldGlobalHotKeys[0]),
                    (Key)Enum.Parse(typeof(Key), oldGlobalHotKeys[1])
                    );

                currentGlobalHotKey.Content = "None + None";
            }

            if (!(newGlobalHotKeys[0].Equals(NO_HOTKEY) || newGlobalHotKeys[1].Equals(NO_HOTKEY)))
            {
                HotkeysManager.AddHotkey(
                    (ModifierKeys)Enum.Parse(typeof(ModifierKeys), newGlobalHotKeys[0]),
                    (Key)Enum.Parse(typeof(Key), newGlobalHotKeys[1]),
                    () => { AddToList("HotKey Fired"); }
                    );
                 
                currentGlobalHotKey.Content = "" + newGlobalHotKeys[0] + " + " + newGlobalHotKeys[1];
            }
        }

        private static string ReadStringFromTxt(string path)
        {
            var str = new StreamReader(path);
            string strLine = str.ReadToEnd();
            str.Close();
            return strLine;
        }

    }
}
