using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class Program
    {
        /// <summary>
        /// This program prompts the user to input 5 data types and then prints them to the screen both concatenated and individually
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /*
             Program uses Tryparse so that no exceptions will occur if incorrect input
             Otherwise, it's fairly straightforward
             Hope you enjoy!
             */
            Console.Write("Please enter an int: ");
            string inputInt = Console.ReadLine();
            int outNum;
            Int32.TryParse(inputInt,out outNum);

            Console.Write("Please enter an string: ");
            string inputString = Console.ReadLine();

            Console.Write("Please enter a char: ");
            string inputChar = Console.ReadLine();
            char outChar;
            Char.TryParse(inputChar, out outChar);

            Console.Write("Please enter a double: ");
            string inputDouble = Console.ReadLine();
            double outDouble;
            Double.TryParse(inputDouble, out outDouble);

            Console.Write("Please enter a bool (true/false): ");
            string inputBool = Console.ReadLine();
            bool outBool;
            bool.TryParse(inputBool, out outBool);

            Console.WriteLine();

            //prints the values individually
            Console.WriteLine("You entered the following values");
            Console.WriteLine(outNum);
            Console.WriteLine(inputString);
            Console.WriteLine(outChar);
            Console.WriteLine(outDouble);
            Console.WriteLine(outBool);

            //prints the values concatenated
            Console.WriteLine();
            Console.WriteLine(outNum + inputString + outChar + outDouble + outBool);

            Console.ReadLine();



        }
    }
}
