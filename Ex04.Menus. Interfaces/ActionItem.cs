using System;

namespace Ex04.Menus.Interfaces
{
    public class ActionItem : IActionItem
    {
        private readonly Action r_Action;
        private readonly string r_Name;

        public ActionItem(string i_Name, Action i_Action)
        {
            r_Name = i_Name;
            r_Action = i_Action;
        }
        
        public string GetName()
        {
            return r_Name;
        }

        public void Invoke()
        {
            r_Action.Invoke();
            PauseBeforeClearScreen();
        }

        public void PauseBeforeClearScreen()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public void SetLevel(uint i_Level) {}
    }
}
