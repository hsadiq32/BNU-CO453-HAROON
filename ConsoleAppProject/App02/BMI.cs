using System.Collections;
using System;
namespace ConsoleAppProject.App02
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Haroon Sadiq
    /// </author>
    public class BMI
    {
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        ArrayList data = new ArrayList();
        public string bameMessage1 = "If you are Black, Asian or other minority ethnic groups you have a higher risk";
        public string bameMessage2 = "Adults 23.0 or more are at increased risk Adults 27.5 or more are at high risk";
        public string Colour { get; set; }
        public bool UnitVal { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Feet { get; set; }
        public double Inches { get; set; }
        public double Bmi { get; set; }
        public string Description { get; set; }
        public double BmiRange { get; set; }

        public InputReader InputReader
        {
            get => default;
            set
            {
            }
        }

        public SyntaxGenerator SyntaxGenerator
        {
            get => default;
            set
            {
            }
        }

        public BMIenum BMIenum
        {
            get => default;
            set
            {
            }
        }

        public void Run()
        {
            InputReader reader = new InputReader();
            syntaxGen.SubheaderGen("BMI Calculator");
            Console.WriteLine(syntaxGen.SyntaxFiller1("Choose metric:"));
            Console.WriteLine(syntaxGen.SyntaxFiller1(" 1. Metric"));
            Console.WriteLine(syntaxGen.SyntaxFiller1(" 2. Imperical"));
            int option = reader.OptionInputChecker("Enter Option:", 2);
            UnitVal = false;
            Height = 0;
            Weight = 0;
            if (option == 1)
            {
                Console.WriteLine(syntaxGen.SyntaxFiller1("Enter Height:"));
                Height = reader.DoubleInputChecker(" Metres:");
                Console.WriteLine(syntaxGen.SyntaxFiller1("Enter Weight:"));
                Weight = reader.DoubleInputChecker(" KG:");
                UnitVal = false;
            }
            else if (option == 2)
            {
                Console.WriteLine(syntaxGen.SyntaxFiller1("Enter Height:"));
                Feet = reader.IntInputChecker(" Feet:");
                Inches = reader.DoubleInputChecker(" Inches:");
                Console.WriteLine(syntaxGen.SyntaxFiller1("Enter Weight:"));
                Weight = reader.DoubleInputChecker(" Pounds:");
                UnitVal = true;
            }
            BMIOutput(UnitVal);

        }
        public string BMIcalc(bool imperical)
        {
            BMIdata();
            if (imperical)
            {
                Height = (Feet * 12) + Inches;
                Weight *= 703;
            }
            Bmi = Weight / (Height*Height);
            return Bmi.ToString("0.#");
        }
        public string BMIdescription(int selectData)
        {
            foreach (string arrayData in data)
            {
                if (Bmi <= BmiRange)
                {
                    break;
                }
                else
                {
                    string[] splitter = arrayData.Split(",");
                    BmiRange = Convert.ToDouble(splitter[0]);
                    Description = splitter[1];
                    Colour = splitter[2];
                }
            }
            if (selectData == 0)
            {
                return Description;
            }
            else
            {
                return Colour;
            }
        }
        public void BMIdata()
        {
            data.Remove(data);
            data.Add("18.5,Underweight,#b52f2f");
            data.Add("24.9,Normal,#2fb52f");
            data.Add("29.9,Overweight,#acb52f");
            data.Add("34.9,Obese Class I,#d49b22");
            data.Add("39.9,Obese Class II,#d45a22");
            data.Add("40,Obese Class III,#b52f2f");

        }
        public void BMIOutput(bool imperical)
        {
            Console.WriteLine(syntaxGen.SyntaxFiller1("Your BMI is: " + BMIcalc(imperical) + " this is " + BMIdescription(0)));
            Console.WriteLine(syntaxGen.SyntaxFiller1(bameMessage1));
            Console.WriteLine(syntaxGen.SyntaxFiller1(bameMessage2));
            syntaxGen.SyntaxFiller2();

        }
    }
}
