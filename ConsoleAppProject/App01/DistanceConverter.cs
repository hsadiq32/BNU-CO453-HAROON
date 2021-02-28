
using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App01
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
        public Dictionary<string, string> unitConversion = new Dictionary<string, string>();
        public Dictionary<double, double> methodReverse = new Dictionary<double, double>();
        InputReader reader = new InputReader();
        SyntaxGenerator syntaxGen = new SyntaxGenerator();

        public DistanceUnits DistanceUnits
        {
            get => default;
            set
            {
            }
        }

        public string Unit1 { get; set; }
        public string Unit2 { get; set; }
        public double Unit1Value { get; set; }

        public string[] Splitter { get; set; }

        public double Result { get; set; }
        public string UnitData { get; set; }
        public double ConversionValue { get; set; }
        public double Method { get; set; }
        public bool WebVersion { get; set; }
        public void Run()
        {
            syntaxGen.SubheaderGen("Distance Converter");
            UserInput();
        }

        public void UnitConversionData()
        {
            unitConversion.Add("metres", "m,1");
            unitConversion.Add("lightyears", "m,9.461E+15");
            unitConversion.Add("kilometres", "m,1000");
            unitConversion.Add("miles", "m,1609.344");
            unitConversion.Add("yards", "d,1.094");
            unitConversion.Add("feet", "d,3.281");
            unitConversion.Add("inches", "d,39.37");
            unitConversion.Add("centimetres", "d,100");
            unitConversion.Add("millimetres", "d,1000");
            unitConversion.Add("micrometres", "d,1E+6");
            unitConversion.Add("nanometres", "d,1E+9");
            methodReverse.Add(0, 1);
            methodReverse.Add(1, 0);
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

        /// <summary>
        /// Prompt the user to enter the distance in miles
        /// Input the miles as a double number.
        /// </summary>
        public void UserInput()
        {
            Unit1 = DistanceChecker("Convert:");
            Unit2 = DistanceChecker("To:");
            Unit1Value = reader.DoubleInputChecker("Please enter the number of " + Unit1 + " > ");
            double res = ConverterResult(false);
            Console.WriteLine(syntaxGen.SyntaxFiller1(Unit1Value + " " + Unit1 + " ---> " + res + " " + Unit2));
            syntaxGen.SyntaxFiller2();
        }

        public double ConverterResult(bool version)
        {
            WebVersion = version;
            UnitConversionData();
            return Converter(Unit2, Converter(Unit1, Unit1Value, false), true);
        }

        public double Converter(string unitName, double unitValue, bool reverse)
        {
            Result = 0;
            int e = 0;
            if(WebVersion)
            {
                if(Int32.TryParse(unitName, out e))
                {
                    unitName = Enum.GetName(typeof(DistanceUnits), Int32.Parse(unitName));
                }
                else
                {
                    unitName = "metres";
                }
            }
            
            if (unitName != null)
            {
                UnitData = unitConversion[unitName];
            }
            else
            {
                UnitData = unitConversion["metres"];
            }
            ConversionValue = UnitConversionParser(UnitData, 1);
            Method = UnitConversionParser(UnitData, 0);
            if (reverse) { Method = methodReverse[Method]; }

            if (Method == 0)
            {
                Result = unitValue * ConversionValue;

            }
            else if (Method == 1)
            {
                Result = unitValue / ConversionValue;
            }
            return Result;
        }
        public double UnitConversionParser(string data, int dataType)
        {
            Splitter = data.Split(",");

            if (dataType == 0)
            {
                if (Splitter[0] == "m") { return 0; }
                else if (Splitter[0] == "d") { return 1; }
                else { return 3; }
            }
            else if (dataType == 1)
            {
                return Convert.ToDouble(Splitter[1]);
            }
            else
            {
                return 0;
            }
        }
    }
}