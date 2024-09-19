namespace Ex04.Menus.Interfaces
{
    public class MainMenu : Menu
    {
        public MainMenu(string i_MenuName) : base(i_MenuName) { }
        
        //This method exists because we were asked to have a Show method in this class.
        //Can do without it and just call Invoke() instead.
        public void Show() 
        {
            Invoke();
        }
    }
}
