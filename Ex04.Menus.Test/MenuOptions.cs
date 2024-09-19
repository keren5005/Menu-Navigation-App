using System;
using System.Globalization;

namespace Ex04.Menus.Test
{
    internal class MenuOptions
    {
        private const string k_Version = "24.2.4.9504";

        internal static void PrintDate()
        {
            var language = new CultureInfo("en-US");

            Console.WriteLine("Today's date is " + DateTime.Now.ToString("dddd, MMM dd yyyy", language));
        }

        internal static void PrintTime()
        {
            Console.WriteLine("The Hour is: " + DateTime.Now.ToString("HH:mm:ss"));
        }

        internal static void displayVersion()
        {
            Console.WriteLine($"App Version: {k_Version}");
        }

        internal static void countCapitalLetters()
        {
            Console.WriteLine("Please enter your sentence:");
            string sentence = Console.ReadLine();
            int capitalLettersFound = 0;

            foreach (char c in sentence)
            {
                if (char.IsUpper(c))
                {
                    capitalLettersFound++;
                }
            }

            Console.WriteLine("I wonder how many Capital Letters are in this sentence...");
            Console.WriteLine($"There are {capitalLettersFound} capitals in your sentence.");
        }

    }
}
