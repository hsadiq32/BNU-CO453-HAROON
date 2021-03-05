using System;
using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Derek Peacock 14/12/2020
    /// </summary>
    public static class Program
    {
        public static DistanceConverter DistanceConverter
        {
            get => default;
            set
            {
            }
        }

        public static BMI BMI
        {
            get => default;
            set
            {
            }
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                InputReader reader = new InputReader();
                SyntaxGenerator syntaxGen = new SyntaxGenerator();
                syntaxGen.HeaderGen("BNU CO453 Applications Programming 2020-2021!");
                Console.WriteLine(syntaxGen.SyntaxFiller1("1. App01 - Distance Converter"));
                Console.WriteLine(syntaxGen.SyntaxFiller1("2. App02 - BMI Calculator"));
                Console.WriteLine(syntaxGen.SyntaxFiller1("3. App03 - Student Marks"));
                Console.WriteLine(syntaxGen.SyntaxFiller1("4. Quit"));
                syntaxGen.SyntaxFiller2();
                Console.Beep();

                int option = reader.RangeInputChecker("Enter Option:", 1, 4);
                if (option == 1)
                {
                    App01();
                }
                else if (option == 2)
                {
                    App02();
                }
                else if (option == 3)
                {   
                    App03();
                }
                else if(option == 4)
                {
                    Console.WriteLine(syntaxGen.SyntaxFiller1(""));
                    Console.WriteLine(syntaxGen.SyntaxFiller1("Goodbye"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(""));
                    syntaxGen.SyntaxFiller2();
                    break;
                }
            }
        }
        public static void App01()
        {
            DistanceConverter converter = new DistanceConverter();
            converter.Run();
        }
        public static void App02()
        {
            BMI bmi = new BMI();
            bmi.Run();
        }
        public static void App03()
        {
            StudentMarks studentMarks = new StudentMarks();
            studentMarks.Run();
        }
    }
}
