namespace Ex04.Menus.Delegates
{
    public delegate void MenuItemChoiceEventHandler();

    public class MenuItem
    {
        public event MenuItemChoiceEventHandler OnChoice;
        private readonly string r_Name;

        public string Name { get => r_Name; }

        public MenuItem(string i_Name)
        {
            r_Name = i_Name;
        }

        public void Show()
        {
          OnChoice?.Invoke();
        }
    }
}




