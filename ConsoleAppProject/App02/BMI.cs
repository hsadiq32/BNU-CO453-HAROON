using System.Collections;
using System;
namespace ConsoleAppProject
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Student Name version 0.1
    /// </author>
    public class BMI
    {
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        ArrayList data = new ArrayList();
        string bameMessage1 = "If you are Black, Asian or other minority ethnic groups you have a higher risk";
        string bameMessage2 = "Adults 23.0 or more are at increased risk Adults 27.5 or more are at high risk";

        public void Run()
        {
            InputReader reader = new InputReader();
            syntaxGen.SubheaderGen("BMI Calculator");
            Console.WriteLine(syntaxGen.SyntaxFiller1("Choose metric:"));
            Console.WriteLine(syntaxGen.SyntaxFiller1(" 1. Metric"));
            Console.WriteLine(syntaxGen.SyntaxFiller1(" 2. Imperical"));
            int option = reader.OptionInputChecker("Enter Option:", 2);
            data.Add("18.5,Underweight");
            data.Add("24.9,Normal");
            data.Add("29.9,Overweight");
            data.Add("34.9,Obese Class I");
            data.Add("39.9,Obese Class II");
            data.Add("40,Obese Class III");
            int unitVal = 0;
            double height = 0;
            double weight = 0;
            if (option == 1)
            {
                Console.WriteLine(syntaxGen.SyntaxFiller1("Enter Height:"));
                height = reader.DoubleInputChecker(" Metres:");
                Console.WriteLine(syntaxGen.SyntaxFiller1("Enter Weight:"));
                weight = reader.DoubleInputChecker(" KG:");
                unitVal = 0;
            }
            else if (option == 2)
            {
                Console.WriteLine(syntaxGen.SyntaxFiller1("Enter Height:"));
                int foot = reader.IntInputChecker(" Feet:");
                double inches = reader.DoubleInputChecker(" Inches:");
                Console.WriteLine(syntaxGen.SyntaxFiller1("Enter Weight:"));
                weight = reader.DoubleInputChecker(" Pounds:");
                height = (foot * 12) + inches;
                unitVal = 1;
            }
            BMIcalc(weight, height, unitVal);

        }
        public void BMIcalc(double weight, double height, int units)
        {
            double bmi = 0;
            if (units == 1) { weight = weight * 703; }
            bmi = weight / (height*height);
            string description = "None";
            foreach (string arrayData in data)
            {
                string[] splitter = arrayData.Split(",");
                double bmiRange = Convert.ToDouble(splitter[0]);
                description = splitter[1];
                if (bmi <= bmiRange) { break; }
            }
            Console.WriteLine(syntaxGen.SyntaxFiller1("Your BMI is: " + bmi.ToString("0.#") + " this is " + description));
            Console.WriteLine(syntaxGen.SyntaxFiller1(bameMessage1));
            Console.WriteLine(syntaxGen.SyntaxFiller1(bameMessage2));
            syntaxGen.SyntaxFiller2();

        }


    }
}
