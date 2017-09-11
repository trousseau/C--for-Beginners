using System;
using System.Collections.Generic;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            int output = 0;

            //initialize menu array
            string[] menu = { "Pancakes", "Eggs", "Bacon", "Home Fries", "Sausage", "French Toast", "Fruit", "Hash Browns", "Omelette", "Waffles" };

            //initialize generic list for storing ordered items
            List<string> menuResults = new List<string>();

            //main do while loop until user types "quit"
            do
            {
                //prompt user for input and display menu using for loop
                Console.WriteLine("Please select an item from the menu by entering a number or type \"quit\" to exit:");

                for (int i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine($"{i} - {menu[i]}");
                }

                input = Console.ReadLine();
                //attempt to parse input and store bool
                bool isNum = int.TryParse(input, out output);

                /*make sure input is int and within range
                 * if correct print menu item & store in generic list
                */
                if (input != "quit" && !isNum)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine();
                }
                else if (output < 0 || output > menu.Length - 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid number from the menu");
                    Console.WriteLine();
                }
                else if (input != "quit")
                {
                    Console.WriteLine();
                    Console.WriteLine($"You ordered: {menu[output]}");
                    Console.WriteLine();
                    menuResults.Add(menu[output]);
                }

            } while (input != "quit");

            //write final order summary
            Console.WriteLine();
            Console.WriteLine("You ordered: ");
            foreach (string menuItem in menuResults)
            {
                Console.WriteLine($"{menuItem}");
            }
            Console.ReadLine();
        }
    }
}
