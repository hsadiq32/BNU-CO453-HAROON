
using System;
using System.Collections.Generic;
namespace ConsoleAppProject
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Haroon Sadiq
    /// </author>
    public class DistanceConverter
    {
        // Create a new dictionary of strings, with string keys.
        Dictionary<string, double> unitConversion = new Dictionary<string, double>();
        InputReader reader = new InputReader();
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        public void Run()
        {
            
            unitConversion.Add("metre", 1);
            unitConversion.Add("lightyear", 9.461E+15);
            unitConversion.Add("kilometre", 1000);
            unitConversion.Add("miles", 1609.344);
            unitConversion.Add("feet", 0.3048);
            unitConversion.Add("centimetre", 0.01);
            unitConversion.Add("millimetre", 0.001);
            unitConversion.Add("nanometre", 0.00000001);
            syntaxGen.SubheaderGen("Distance Converter");
            InputMiles();
        }

        public string UnitInputChecker(string consoleWrite)
        {
            string data = "";
            while (true)
            {
                Console.Write(syntaxGen.SyntaxFiller1(consoleWrite));
                data = Console.ReadLine().ToLower();
                if (System.Enum.IsDefined(typeof(DistanceUnits), data))
                {
                    break;
                }
                else
                {
                    Console.Write(syntaxGen.SyntaxFiller1("Invalid unit\n"));
                }
            }
            return data;
        }

    /// <summary>
    /// Prompt the user to enter the distance in miles
    /// Input the miles as a double number.
    /// </summary>
    private void InputMiles()
        {
            string unit1 = UnitInputChecker("Convert:");
            string unit2 = UnitInputChecker("To:");
            double unit1value = reader.DoubleInputChecker("Please enter the number of " + unit1 + " > ");
            double answer = (unit1value * unitConversion[unit1]) / unitConversion[unit2];
            Console.WriteLine(syntaxGen.SyntaxFiller1(answer.ToString()));
            syntaxGen.SyntaxFiller2();
        }
    }
}