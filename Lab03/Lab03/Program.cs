using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo en_US = CultureInfo.GetCultureInfo("en-US");

            string seperator = new string('=', 78);

            //initialize array
            string[] employeeData = { "White", "Walter", "743289347", "Manufacturer", "$10000000.00", "01/20/2008"};

            //convert strings to number types
            int employeeId = int.Parse(employeeData[2]);
            decimal convSalary = Decimal.Parse(employeeData[4], NumberStyles.Currency, en_US);
            DateTime dateHired = DateTime.Parse(employeeData[5]);

            //print header and array data
            Console.WriteLine("{0,-7} {1,-7} {2,-10} {3,-15} {4,-15} {5,-10}", "Last", "First", "ID","Job Title","Salary","Date of Hire");
            Console.WriteLine(seperator);
            Console.WriteLine("{0,-7} {1,-7} {2,-10} {3,-15} {4,-15} {5:MMMM d, yyyy}", employeeData[0], employeeData[1], employeeId, employeeData[3], convSalary, dateHired);

            //initialize generic list by passing the previous array constructor
            List<string> empDataGen = new List<string>(employeeData);

            //don't know if I need to do these conversions again but here they are anyway
            int employeeIdGen = int.Parse(empDataGen[2]);
            decimal convSalaryGen = Decimal.Parse(empDataGen[4], NumberStyles.Currency, en_US);
            DateTime dateHiredGen = DateTime.Parse(empDataGen[5]);

            //add a line and then print the valuse again
            Console.WriteLine();
            Console.WriteLine("{0,-7} {1,-7} {2,-10} {3,-15} {4,-15} {5:MMMM d, yyyy}", empDataGen[0], empDataGen[1], employeeIdGen, empDataGen[3], convSalaryGen, dateHiredGen);

            Console.ReadLine();
        }
    }
}
