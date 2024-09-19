
namespace Ex04.Menus.Test
{
    internal class DelegateMenu
    {
        private Delegates.Menu m_mainMenu;
        public DelegateMenu()
        {
            m_mainMenu = new Delegates.Menu("Delegates Main Menu");

            Delegates.Menu versionAndCapitals = new Delegates.Menu("Version and Capitals");
            versionAndCapitals.AddOption("Show Version", MenuOptions.displayVersion);
            versionAndCapitals.AddOption("Count Capitals", MenuOptions.countCapitalLetters);

            Delegates.Menu dateAndTime = new Delegates.Menu("Show Date/Time");
            dateAndTime.AddOption("Show Date", MenuOptions.PrintDate);
            dateAndTime.AddOption("Show Time", MenuOptions.PrintTime);

            m_mainMenu.AddOption("Version and Capitals", versionAndCapitals);
            m_mainMenu.AddOption("Show Date/Time", dateAndTime);
        }
        public void ShowMenu()
        {
            m_mainMenu.Show();
        }
    }
}
