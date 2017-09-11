using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo en_US = CultureInfo.GetCultureInfo("en-US");

            //initialize array with employee values
            string[,] employees =
            {
                {"Anderson","John","1","1/17/2010","$80,000.45","Development" },
                {"Smith","Janet","15678","5/14/2014","$50,000.31","Human Resources" },
                {"Davis","Mark","23808","8/26/2012","$65,000.07","Marketing" },
                {"Sampson","Melanie", "729348","2/12/2011","$85,000.91","Accounting" }
            };

            //initialize generic list to store formatted strings
            List<string> formattedEmployees = new List<string>();

            //Write header and seperator
            Console.WriteLine("{0,-8} {1,-8} {2,-11} {3,-15} {4,-12} {5,-16}","Last","First","ID","Date Hired","Wage","Deparment");
            Console.WriteLine(new string('-',75));

            //write formatted strings to generic list
            for (int i = 0; i < employees.GetLength(0); i++)
            {
                int id = int.Parse(employees[i,2]);
                string tempDate = employees[i,3];
                DateTime dateHire = DateTime.Parse(tempDate);
                decimal wage = decimal.Parse(employees[i,4], NumberStyles.Currency, en_US);

               formattedEmployees.Add(String.Format("{0,-8} {1,-8} {2,-11:0000-0000} {3,-15:MMM dd, yyyy} {4,-12:C} {5,-16}",employees[i,0],employees[i,1],id,dateHire,wage,employees[i,5]));
            }

            //write formatted strings to console
            foreach (string str in formattedEmployees)
            {
                Console.WriteLine(str);
            }

            Console.ReadLine();
        }
    }
}
