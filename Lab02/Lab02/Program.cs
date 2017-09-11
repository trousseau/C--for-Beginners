using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            //PI = 3.141592653589793238462643383279502884197169399375105820974944592307816406286;

            //5 variables of different data types
            int dataInt = 5;
            double dataDouble = 7.395768432;
            decimal dataDecimal = 5.10928374756568748M;
            float dataFloat = 1.1234F;
            bool dataBool = true;

            //parse variables to strings and store in string variables
            string strInt = dataInt.ToString();
            string strDouble = dataDouble.ToString();
            string strDecimal = dataDecimal.ToString();
            string strFloat = dataFloat.ToString();
            string strBool = dataBool.ToString();

            //write the string variables to the console window
            Console.WriteLine("Int: " + strInt);
            Console.WriteLine("Double: " + strDouble);
            Console.WriteLine("Decimal: " + strDecimal);
            Console.WriteLine("Float: " + strFloat);
            Console.WriteLine("Bool: " + strBool);

            Console.WriteLine();

            //convert pi to various number types (not including unsigned types)
            byte bytePI = (byte)3.141592653589793238462643383279502884197169399375105820974944592307816406286;
            short shortPI = (short)3.141592653589793238462643383279502884197169399375105820974944592307816406286;
            long longPI = (long)3.141592653589793238462643383279502884197169399375105820974944592307816406286;
            int intPI = (int)3.141592653589793238462643383279502884197169399375105820974944592307816406286;
            decimal decPI = 3.141592653589793238462643383279502884197169399375105820974944592307816406286M;
            double doubPI = 3.141592653589793238462643383279502884197169399375105820974944592307816406286;
            float floatPI = 3.141592653589793238462643383279502884197169399375105820974944592307816406286F;

            //print values
            Console.WriteLine("Byte: " + bytePI);
            Console.WriteLine("Short: " + shortPI);
            Console.WriteLine("Long: " + longPI);
            Console.WriteLine("Int: " + intPI);
            Console.WriteLine("Decimal: " + decPI);
            Console.WriteLine("Double: " + doubPI);
            Console.WriteLine("Float: " + floatPI);

            Console.ReadLine();

        }
    }
}
