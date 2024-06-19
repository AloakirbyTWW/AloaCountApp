using System;
using System.IO;
using WpfApp1;

namespace Session
{
    /// <summary>
    /// A session of a counter
    /// </summary>
    public class Session
    {
        /// <summary>
        /// The name of the session
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The current count of the session saved and loaded when the session is closed and opened
        /// </summary>
        public long count { get; set; }

        /// <summary>
        /// The number to add to the session count at ech increment
        /// </summary>
        public int nbToAdd { get; set; }

        /// <summary>
        /// True if the counter must display a time in millieSeconds and not simply a number
        /// </summary>
        public bool timeDisplay { get; set; }

        /// <summary>
        /// Global hotkey that increment the counter
        /// </summary>
        public string globalHotKey { get; set; }

        /// <summary>
        /// Font of the counter
        /// </summary>
        public int font { get; set; }

        /// <summary>
        /// Size of the counter
        /// </summary>
        public int size { get; set; }

        /// <summary>
        /// Return the current session
        /// </summary>
        public static Session LoadCurrentSession(string currentSessionName, bool firstLoad)
        {
            if (currentSessionName == "")
            {
                return new Session("", 0, 1, false, MainWindow.NO_HOTKEY_STRING, 0, 1);
            }
            else
            {
                return LoadSession(currentSessionName, firstLoad);
            }
        }

        /// <summary>
        /// Return the new session if it exits and change the current session to that new one
        /// </summary>
        public static Session LoadNewSession(Session currentSession, string name)
        {
            if (!SessionExists(name))
            {
                return currentSession;
            }
            else
            {
                return LoadSession(name, false);
            }
        }

        /// <summary>
        /// Return the new session if it exits and change the current session to that new one
        /// </summary>
        public static void CreateSession(string name, long count, int nbToAdd, int timeDisplay, string globalHotKey, int font, int size)
        {
            System.IO.Directory.CreateDirectory("../../../sessions/" + name);
            System.IO.File.CreateText("../../../sessions/" + name + "/count.txt").Close();
            System.IO.File.CreateText("../../../sessions/" + name + "/nbToAdd.txt").Close();
            System.IO.File.CreateText("../../../sessions/" + name + "/timeDisplay.txt").Close();
            System.IO.File.CreateText("../../../sessions/" + name + "/globalHotKey.txt").Close();
            System.IO.File.CreateText("../../../sessions/" + name + "/font.txt").Close();
            System.IO.File.CreateText("../../../sessions/" + name + "/size.txt").Close();

            System.IO.File.WriteAllText("../../../sessions/" + name + "/count.txt", "" + count);
            System.IO.File.WriteAllText("../../../sessions/" + name + "/nbToAdd.txt", "" + nbToAdd);
            System.IO.File.WriteAllText("../../../sessions/" + name + "/timeDisplay.txt", "" + timeDisplay);
            System.IO.File.WriteAllText("../../../sessions/" + name + "/globalHotKey.txt", "" + globalHotKey);
            System.IO.File.WriteAllText("../../../sessions/" + name + "/font.txt", "" + font);
            System.IO.File.WriteAllText("../../../sessions/" + name + "/size.txt", "" + size);

            System.IO.File.WriteAllText("../../../sessions/currentSession.txt", "" + name);
        }

        /// <summary>
        /// Save the session count, 
        /// </summary>
        public void SaveSession(Session session)
        {    
            if (MainWindow.currentSession.name == "")
            {
                return;
            }
            else
            {
                System.IO.File.WriteAllText("../../../sessions/" + session.name + "/count.txt", "" + session.count);
            }
        }

        /// <summary>
        /// Initiates a new session with the given name, number, nbToAdd, 
        /// </summary>
        /// <param name="name">The session name</param>
        /// <param name="count">The saved count or time in 1000 of seconds</param>
        /// <param name="nbToAdd">The number to add at each incrementation</param>
        /// <param name="globalHotKey" >The global HotKey that increment the counter when pressed</param>
        /// <param name="font" >The font of the counter</param>
        /// <param name="size" >The size of the counter and window</param>
        /// </param>
        public Session(string name, long count, int nbToAdd, bool timeDisplay, string globalHotKey, int font, int size)
        {
            this.name = name;
            this.count = count;
            this.nbToAdd = nbToAdd;
            this.timeDisplay = timeDisplay;
            this.globalHotKey = globalHotKey;
            this.font = font;
            this.size = size;
        }


        //========= HELPERS =========

        private static Session LoadSession(string sessionName, bool firstLoad)
        {
            long count = ReadNumberFromTxt("../../../sessions/" + sessionName + "/count.txt");
            int nbToAdd = (int)ReadNumberFromTxt("../../../sessions/" + sessionName + "/nbToAdd.txt");

            var str = new StreamReader("../../../sessions/" + sessionName + "/globalHotKey.txt");
            string newGlobalHotKey = str.ReadToEnd();
            str.Close();

            if (!firstLoad)
            {
                MainWindow.oldGlobalHotkey = "" + MainWindow.currentSession.globalHotKey;
            }

            int font = (int)ReadNumberFromTxt("../../../sessions/" + sessionName + "/font.txt");
            int size = (int)ReadNumberFromTxt("../../../sessions/" + sessionName + "/size.txt");

            System.IO.File.WriteAllText("../../../sessions/currentSession.txt", "" + sessionName);

            return new Session(sessionName, count, nbToAdd, ReadNumberFromTxt("../../../sessions/" + sessionName + "/timeDisplay.txt") == 1, newGlobalHotKey, font, size);
        }

        private static long ReadNumberFromTxt(string path)
        {
            var str = new StreamReader(path);
            string strLine = str.ReadToEnd();
            str.Close();
            return long.Parse(strLine);
        }

        private static bool SessionExists(string sessionName)
        {
            return
                Directory.Exists("../../../sessions/" + sessionName) &&
                File.Exists("../../../sessions/" + sessionName + "/count.txt") &&
                File.Exists("../../../sessions/" + sessionName + "/nbToAdd.txt") &&
                File.Exists("../../../sessions/" + sessionName + "/timeDisplay.txt") &&
                File.Exists("../../../sessions/" + sessionName + "/globalHotKey.txt") &&
                File.Exists("../../../sessions/" + sessionName + "/font.txt") &&
                File.Exists("../../../sessions/" + sessionName + "/size.txt");
        }

    }
}
