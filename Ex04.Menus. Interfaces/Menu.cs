using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class Menu : IMenu
    {
        private readonly string r_Name;
        private uint m_Level;
        private List<IMenuItem> m_MenuItems;
        public string GetName() { return r_Name; }

        public Menu(string i_Name)
        {
            r_Name = i_Name;
            m_Level = 1; //As default, menus aren't part of a sub-menu. Level will be adjusted if menu becomes a sub-menu
            m_MenuItems = new List<IMenuItem>();
        }
        public void SetLevel(uint i_Level)
        {
            m_Level = i_Level;
        }

        public void AddItemToMenu(IMenuItem i_MenuItemToAdd)
        {
            i_MenuItemToAdd.SetLevel(m_Level+1);
            m_MenuItems.Add(i_MenuItemToAdd);
        }

        private void printMenu()
        {
            const string k_underline = "-------------------------";

            Console.WriteLine($"  << Menu level: {m_Level} >>");
            Console.WriteLine($"**{r_Name}**");
            Console.WriteLine(k_underline);
            Console.WriteLine("Choose an option:");


            for (int itemIndex = 0; itemIndex < m_MenuItems.Count; itemIndex++)
            {
                Console.WriteLine($"{itemIndex + 1} -> {m_MenuItems[itemIndex].GetName()}");

            }

            Console.WriteLine($"0 -> {(m_Level == 1 ? "Exit" : "Back")}");
            Console.WriteLine(k_underline);
            Console.WriteLine($"Enter your request: " +
                $"(1 to {m_MenuItems.Count} or press '0' to {(m_Level == 1 ? "Exit" : "Back")}).");
        }

        private bool checkUserInput(string i_UserInput, out string o_ErrorMsg)
        {
            o_ErrorMsg = "";
            bool isInputValid = int.TryParse(i_UserInput, out int userInputAsInt);

            if (!isInputValid)
            {
                o_ErrorMsg = "Input is not a number.";
            }
            else if (userInputAsInt > m_MenuItems.Count || userInputAsInt < 0)
            {
                o_ErrorMsg = "Input out of range.";
                isInputValid = false;
            }

            return isInputValid;
        }

        public void Invoke()
        {
            bool validInput;

            Console.Clear();
            while (true)
            {
                printMenu();

                string userInput = Console.ReadLine();

                validInput = checkUserInput(userInput, out string errorMsg);
                if (!validInput)
                {
                    Console.Clear();
                    Console.WriteLine($"{errorMsg} Try again.");
                    Console.WriteLine();
                }
                else
                {
                    int userInputAsInt = int.Parse(userInput);

                    if (userInputAsInt == 0)
                    {
                        break;
                    }

                    IMenuItem chosenItem = m_MenuItems[userInputAsInt - 1];

                    chosenItem.Invoke();
                    Console.Clear();
                }
            }
        }
    }
}
