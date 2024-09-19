namespace Ex04.Menus.Test
{
    internal class InterfaceMenu
    {
        private Interfaces.MainMenu m_mainMenu;
        public InterfaceMenu()
        {
            m_mainMenu = new Interfaces.MainMenu("Interfaces Main Menu");

            Interfaces.Menu versionAndCapitals = new Interfaces.Menu("Version and Capitals");
            versionAndCapitals.AddItemToMenu(new Interfaces.ActionItem("Show Version", MenuOptions.displayVersion));
            versionAndCapitals.AddItemToMenu(new Interfaces.ActionItem("Count Capitals", MenuOptions.countCapitalLetters));

            Interfaces.Menu dateAndTime = new Interfaces.Menu("Show Date/Time");
            dateAndTime.AddItemToMenu(new Interfaces.ActionItem("Show Date", MenuOptions.PrintDate));
            dateAndTime.AddItemToMenu(new Interfaces.ActionItem("Show Time", MenuOptions.PrintTime));

            m_mainMenu.AddItemToMenu(versionAndCapitals);
            m_mainMenu.AddItemToMenu(dateAndTime);
        }
        public void ShowMenu()
        {
            m_mainMenu.Show();
        }
    }
}
