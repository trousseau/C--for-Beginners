using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            double total = 5.00;
            char inputBuySell = 'a';
            bool exit = false;

            string[] menu = { "Apple", "Banana", "Orange", "Pear", "Mango", "Grape", "Cherry", "Plum", "Peach", "Lemon" };
            int[] init = new int[10];
            List<double> prices = new List<double>() { .75, .66, .78, .59, .56, .82, .67, .91, .70, .56 };
            List<int> myTotals = new List<int>(init);
            List<string> menuResults = new List<string>();

            printInstructions(total);

            do
            {
                do
                {
                    printTotals(menu, prices, myTotals);

                    Console.WriteLine();

                    Console.WriteLine("Enter 'b' to buy or 's' to sell");
                    inputBuySell = Console.ReadKey().KeyChar;

                    Console.WriteLine();

                    if (inputBuySell == 's')
                    {
                        sellItem(ref input, menu, menuResults, prices, ref total, ref myTotals);
                    }
                    else if (inputBuySell == 'b')
                    {
                        buyItem(ref input, menu, menuResults, prices, ref total, ref myTotals);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }
                } while (input != "quit" && total > 0.00 && total < 10.00);

                endGame(input, total, menuResults);
                exit = quitGame(ref myTotals, ref total);
            } while (exit == false);
        }

        static bool quitGame(ref List<int> myTotals, ref double total)
        {
            char input = 'a';
            bool exit = false;

            do
            {
                Console.Write("Would you like to play again? (y/n): ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine();
                if (input == 'y')
                {
                    for (int i = 0; i < myTotals.Count - 1; i++)
                    {
                        myTotals[i] = 0;
                    }
                    total = 5.00;

                    Console.WriteLine($"Total cash: {total:C}");
                    Console.WriteLine();

                    exit = true;
                    return false;
                }
                else if (input == 'n')
                {
                    exit = true;
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine();
                    continue;
                }
            } while (exit == false);
            return false;
        }

        private static void printInstructions(double total)
        {
            Console.WriteLine("           -----------------Welcome to Fruit Wars!-----------------");
            //Instructions for how to play
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}, here is how you play:");
            Console.WriteLine("You start with a certain amount of money and the object of the game is to reach $10.00");
            Console.WriteLine("You will need to buy and sell fruit to reach your goal. Watch the market, because the prices will change after each turn.");
            Console.WriteLine(new string('=', 75));
            Console.WriteLine();
            Console.WriteLine($"Starting Cash: {total:C}");
            Console.WriteLine();
        }

        private static void endGame(string input, double total, List<string> menuResults)
        {
            if (input == "quit")
            {
                Console.WriteLine();
                Console.WriteLine("Quitter! No wonder you lost...");
                Console.WriteLine();
                Console.WriteLine("You ordered: ");
                foreach (string menuItem in menuResults)
                {
                    Console.WriteLine($"{menuItem}");
                }
            }
            else if (total >= 10)
            {
                Console.WriteLine("You did it! You are the fruit kingpin!");
                Console.WriteLine();
                Console.WriteLine("You ordered: ");
                foreach (string menuItem in menuResults)
                {
                    Console.WriteLine($"{menuItem}");
                }
            }
            else
            {
                Console.WriteLine("You lost! You ran out of money!");
                Console.WriteLine();
                Console.WriteLine("You ordered: ");
                foreach (string menuItem in menuResults)
                {
                    Console.WriteLine($"{menuItem}");
                }
            }
            Console.WriteLine();
        }

        static void newPrices(ref List<double> prices)
        {
            Random random = new Random();
            for (int i = 0; i < prices.Count; i++)
            {
                prices[i] = random.NextDouble() * (1 - .50) + .5;
            }
        }

        static void buyItem(ref string input, string[] menu, List<string> menuResults, List<double> prices, ref double total, ref List<int> myTotals)
        {
            bool endLoop = false;
            int output;
            bool isNum;

            do
            {
                Console.WriteLine("Please select the item you wish to buy from the menu by entering a number or type \"quit\" to exit:");
                input = Console.ReadLine();
                //attempt to parse input and store bool
                isNum = int.TryParse(input, out output);

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
                    Console.WriteLine($"You bought a(n): {menu[output]}");
                    Console.WriteLine();
                    menuResults.Add(menu[output]);
                    myTotals[output] += 1;

                    total -= prices[output];

                    Console.WriteLine($"Total Cash: {total:C}");
                    Console.WriteLine();

                    newPrices(ref prices);
                    endLoop = true;
                }
                else
                {
                    break;
                }
            } while (endLoop == false);
        }

        static void sellItem(ref string input, string[] menu, List<string> menuResults, List<double> prices, ref double total, ref List<int> myTotals)
        {
            bool endLoop = false;
            int output;
            bool isNum;

            do
            {
                Console.WriteLine("Please select the item you wish to sell from the menu by entering a number or type \"quit\" to exit:");
                input = Console.ReadLine();
                //attempt to parse input and store bool
                isNum = int.TryParse(input, out output);

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
                    if (myTotals[output] <= 0)
                    {
                        Console.WriteLine("You have none to sell! Try again.");
                        Console.WriteLine();
                        break;
                    }
                    Console.WriteLine();
                    Console.WriteLine($"You sold a(n): {menu[output]}");
                    Console.WriteLine();
                    menuResults.Add(menu[output]);
                    total += prices[output];
                    myTotals[output] -= 1;

                    Console.WriteLine($"Total Cash: {total:C}");
                    Console.WriteLine();

                    newPrices(ref prices);

                    endLoop = true;
                }
                else
                {
                    break;
                }
            } while (endLoop == false);
        }

        static void printTotals(string[] menu, List<double> prices, List<int> myTotals)
        {
            Console.WriteLine("{0} - {1,-13} {2,-15} {3,-11} {4,-11}", "#", "Menu Item", "Current Price", "Amount", "Value");
            string seperator = new string('-', 75);
            Console.WriteLine(seperator);
            for (int i = 0; i < prices.Count; i++)
            {
                Console.WriteLine($"{i} - {menu[i],-13} {prices[i],-15:C} {myTotals[i],-11} {myTotals[i] * prices[i],-11:C}");
            }
        }
    }
}
