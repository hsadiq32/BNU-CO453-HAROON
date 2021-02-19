
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
            syntaxGen.SubheaderGen("Distance Converter");
            UserInput();
        }

        public string DistanceChecker(string consoleWrite)
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

        public void UnitConversionData()
        {
            unitConversion.Add("metres", 1);
            unitConversion.Add("lightyears", 9.461E+15);
            unitConversion.Add("kilometres", 1000);
            unitConversion.Add("miles", 1609.344);
            unitConversion.Add("yards", 0.91407678245);
            unitConversion.Add("feet", 0.3048);
            unitConversion.Add("inches", 0.0254000508);
            unitConversion.Add("centimetres", 0.01);
            unitConversion.Add("millimetres", 0.001);
            unitConversion.Add("micrometres", 0.000001);
            unitConversion.Add("nanometres", 0.000000001);
        }

        /// <summary>
        /// Prompt the user to enter the distance in miles
        /// Input the miles as a double number.
        /// </summary>
        public void UserInput()
        {
            string unit1 = DistanceChecker("Convert:");
            string unit2 = DistanceChecker("To:");
            double unit1value = reader.DoubleInputChecker("Please enter the number of " + unit1 + " > ");
            UnitConversionData();
            double answer = (unit1value * unitConversion[unit1]) / unitConversion[unit2];
            Console.WriteLine(syntaxGen.SyntaxFiller1(unit1value + " " + unit1 + " ---> " + answer.ToString() + " " + unit2));
            syntaxGen.SyntaxFiller2();
        }
    }
}