//Kevin Vo
//CSC 4101 Programming Assignment #3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace floatingPointConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Asks the user for a decimal number
            Console.Write("Please enter a decimal number: ");
            double decimalNum = double.Parse(Console.ReadLine());
            Console.WriteLine();



            /*Single Precision*/
            Console.WriteLine("This is the Single Precision");
            Console.WriteLine("------------------------");
            Console.WriteLine("The sign bit | The exponent bits | The mantissa bits");
            List<int> singlePrecisionList = new List<int>(); //List for the single precision bits
            //Function for the first bit, the sign bit (if it is negative or positive)
            int firstBit;
            if (decimalNum >= 0)
            {
                firstBit = 0;
            }
            else
            {
                firstBit = 1;
                decimalNum = decimalNum * -1; //this turns the negative to positive to make negative numbers work
            }
            Console.Write(firstBit); //prints the sign bit
            Console.Write(" | ");

            //The conversion of the decimal number to base 2 scientific notataion
            double mantissaVal;
            int exponentCount = 0;
            if (decimalNum > 0 && decimalNum < 1) //this loop is when user input is a decimal number ex: 0.085
            {
                do
                {
                    mantissaVal = decimalNum * 2;
                    decimalNum = mantissaVal;
                    exponentCount--;
                }
                while ((decimalNum >= 1 && decimalNum < 2) == false); //condition to stop the loop; stops it at 1.
            }
            else if (decimalNum > 1) //this loop is when user input is an integer
            {
                do
                {
                    mantissaVal = decimalNum / 2;
                    decimalNum = mantissaVal;
                    exponentCount++;
                }
                while ((decimalNum >= 1 && decimalNum < 2) == false); //condition to stop the loop; stops it at 1.
            }
            double singleExpoValue = 127 + exponentCount;

            //convert singleExpoValue to bit form; gets the exponent bits
            double divisionTotal;
            double modulusTotal;
            for (int i = 0; i < 8; i++) //runs the loop 8 times for 8 bits in the exponent
            {
                    divisionTotal = singleExpoValue / 2;
                    modulusTotal = singleExpoValue % 2;
                    if (Math.Floor(modulusTotal) == 1)
                    {
                        singlePrecisionList.Add(1);
                    }
                    else if (Math.Floor(modulusTotal) == 0) 
                    {
                        singlePrecisionList.Add(0);
                    }
                singleExpoValue = divisionTotal;
            }
            singlePrecisionList.Reverse();
            for (int k = 0; k < singlePrecisionList.Count(); k++)
            {
                Console.Write(singlePrecisionList[k]); //prints the exponent bits
            }
            Console.Write(" | ");

            //the calculation of the mantissa for single precision
            double mantissa = decimalNum - 1;
            double calcResult;
            double remainder;
            for (int j = 0; j < 23; j++) //run the loop for 23 times for 23 bits in mantissa
            {
                calcResult = mantissa * 2;
                mantissa = calcResult;
                remainder = calcResult % 2;
                Console.Write(Math.Floor(remainder)); //prints the mantissa bits
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            
            /*Double Precision*/
            Console.WriteLine("This is the Double Precision");
            Console.WriteLine("------------------------");
            Console.WriteLine("The sign bit | The exponent bits | The mantissa bits");
            List<int> doublePrecisionList = new List<int>(); //List for the double precision bits
            Console.Write(firstBit); //prints the sign bit
            Console.Write(" | ");

            //converts the doubleExpoValue to bit form
            double doubleExpoValue = 1023 + exponentCount; 
            double doubleDivisionTotal;
            double doubleModulusTotal;
            for (int t = 0; t < 11; t++) //runs the loop 11 times for 11 bits in the exponent
            {
                doubleDivisionTotal = doubleExpoValue / 2;
                doubleModulusTotal = doubleExpoValue % 2;
                if (Math.Floor(doubleModulusTotal) == 1)
                {
                    doublePrecisionList.Add(1);
                }
                else if (Math.Floor(doubleModulusTotal) == 0) 
                {
                    doublePrecisionList.Add(0);
                }
                doubleExpoValue = doubleDivisionTotal;
            }
            doublePrecisionList.Reverse();
            for (int v = 0; v < doublePrecisionList.Count(); v++)
            {
                Console.Write(doublePrecisionList[v]); //prints the exponent bits
            }
            Console.Write(" | ");

            //The calculation of mantissa for double precision
            double doubleMantissa = decimalNum - 1;
            double doubleCalcResult;
            double doubleRemainder;
            for (int n = 0; n < 52; n++) //run the loop for 52 times for 52 bits in mantissa
            {
                doubleCalcResult = doubleMantissa * 2;
                doubleMantissa = doubleCalcResult;
                doubleRemainder = doubleCalcResult % 2;
                Console.Write(Math.Floor(doubleRemainder)); //prints the mantissa bits
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
