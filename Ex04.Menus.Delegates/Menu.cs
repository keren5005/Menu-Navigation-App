using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class Menu
    {
        private readonly List<MenuItem> r_SubMenuItems;
        private int m_Level;
        private readonly string r_Name;

        public string Name { get => r_Name; }
        public int Level { get => m_Level; set => m_Level = value; }

        public Menu(string i_MenuName)
        {
            r_Name = i_MenuName;
            r_SubMenuItems = new List<MenuItem>();
            m_Level = 1;
        }

        public void Show()
        {
            bool isValid;

            while(true)
            {
                printMenu();

                string userInput = Console.ReadLine();

                isValid = checkUserInput(userInput);
                if (isValid)
                {
                    int selectedIndex = int.Parse(userInput);

                    if (selectedIndex == 0)
                    {
                        Console.Clear();
                        break;
                    }

                    MenuItem selectedMenuItem = r_SubMenuItems[selectedIndex - 1];
                    selectedMenuItem.Show();
                }
            }
        }

        private void printMenu()
        {
            const string k_underline = "-------------------------";

            Console.WriteLine($"  << Menu level: {Level} >>");
            Console.WriteLine($"**{Name}**");
            Console.WriteLine(k_underline);
            Console.WriteLine("Choose an option:");

            int counter = 0;

            foreach (MenuItem menuItem in r_SubMenuItems)
            {
                Console.WriteLine($"{++counter} -> {menuItem.Name}");
            }

            Console.WriteLine($"0 -> {(Level == 1 ? "Exit" : "Back")}");
            Console.WriteLine(k_underline);
            Console.WriteLine($"Enter your request: " +
                $"(1 to {counter} or press '0' to {(Level == 1 ? "Exit" : "Back")}).");
        }

        private bool checkUserInput(string i_UserInput)
        {
            bool isInputValid = int.TryParse(i_UserInput, out int selectedIndex);

            if (!isInputValid)
            {
                Console.Clear();
                Console.WriteLine("Input is not a number. Try again.");
                Console.WriteLine();
            }
            else if (0 > selectedIndex || selectedIndex > r_SubMenuItems.Count)
            {
                Console.Clear();
                Console.WriteLine("Input out of range. Try again.");
                Console.WriteLine();
                isInputValid = false;
            }

            return isInputValid;
        }

        public void AddOption(string i_MenuName, MenuItemChoiceEventHandler i_Action)
        {
            MenuItem menuItem = new MenuItem(i_MenuName);
            
            menuItem.OnChoice += i_Action;
            menuItem.OnChoice += pauseBeforeClearScreen;
            menuItem.OnChoice += Console.Clear;
            r_SubMenuItems.Add(menuItem);
        }

        public void AddOption(string i_MenuName, Menu i_SubMenu)
        {
            MenuItem menuItem = new MenuItem(i_MenuName);
            
            i_SubMenu.Level = Level + 1;
            menuItem.OnChoice += Console.Clear;
            menuItem.OnChoice += i_SubMenu.Show;
            r_SubMenuItems.Add(menuItem);
        }

        private void pauseBeforeClearScreen()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

    }
}

