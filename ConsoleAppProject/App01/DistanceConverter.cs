
using System;
using System.Collections.Generic;
namespace ConsoleAppProject.App01
    {
        /// <summary>
        /// Please describe the main features of this App
        /// </summary>
        /// <author>
        /// Student Name version 0.1
        /// </author>
        public class DistanceConverter
        {
            // Distance measured in miles
            private double miles;
            // Distance measured in feet
            private double feet;

            // Create a new dictionary of strings, with string keys.
            Dictionary<string, double> unitConversion = new Dictionary<string, double>();
        public void Run()
            {
                unitConversion.Add("metre", 1);
                unitConversion.Add("kilometre", 1000);
                unitConversion.Add("miles", 1609.344);
                unitConversion.Add("feet", 0.3048);
                unitConversion.Add("centimetre", 0.01);
                unitConversion.Add("millimetre", 0.001);
                unitConversion.Add("nanometre", 0.00000001);


            InputMiles();
                CalculateFeet();
                OutputFeet();

            }

        public double DoubleInputChecker(string unit)
        {
            double data = 0;
            while (true)
            {
                Console.Write("Please enter the number of " + unit + " > ");
                string value = Console.ReadLine();
                try
                {
                    data = Convert.ToDouble(value);
                    break;
                }
                catch (System.FormatException)
                {
                    Console.Write("Invalid input\n");
                }
            }
            return data;
        }

        public string UnitInputChecker(string consoleWrite)
        {
            string data = "";
            while (true)
            {
                
                Console.Write(consoleWrite);
                data = Console.ReadLine();
                if (System.Enum.IsDefined(typeof(DistanceUnits), data.ToLower()))
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid unit\n");
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
            miles = DoubleInputChecker("miles");
            string unit1 = UnitInputChecker("Convert:");
            string unit2 = UnitInputChecker("To:");
            double unit1value = DoubleInputChecker(unit1);
            double answer = (unit1value * unitConversion[unit1]) / unitConversion[unit2];
            Console.WriteLine(answer);
        }

            private void CalculateFeet()
            {
            }

            private void OutputFeet()
            {
            }
        }
    }