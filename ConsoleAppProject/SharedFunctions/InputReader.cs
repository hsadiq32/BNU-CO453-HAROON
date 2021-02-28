using System;
namespace ConsoleAppProject
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Student Name version 0.1
    /// </author>
    public class InputReader
    {
        SyntaxGenerator syntaxGen = new SyntaxGenerator();

        public int IntInputChecker(string consoleWrite)
        {
            int data = 0;
            while (true)
            {
                Console.Write(syntaxGen.SyntaxFiller1(consoleWrite));
                string value = Console.ReadLine();
                try
                {
                    data = (int)Convert.ToInt64(value);
                    break;
                }
                catch (System.FormatException)
                {
                    Console.Write(syntaxGen.SyntaxFiller1("Invalid input\n"));
                }
            }
            return data;
        }

        public int OptionInputChecker(string consoleWrite, int maxoption)
        {
            int data = 0;
            while (true)
            {
                Console.Write(syntaxGen.SyntaxFiller1(consoleWrite));
                string value = Console.ReadLine();
                try
                {
                    data = (int)Convert.ToInt64(value);
                    if (data <= maxoption & data > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write(syntaxGen.SyntaxFiller1("Invalid input\n"));
                    }
                }
                catch (System.FormatException)
                {
                    Console.Write(syntaxGen.SyntaxFiller1("Invalid input\n"));
                }
            }
            return data;
        }

        public double DoubleInputChecker(string consoleWrite)
        {
            double data = 0;
            while (true)
            {
                Console.Write(syntaxGen.SyntaxFiller1(consoleWrite));
                string value = Console.ReadLine();
                try
                {
                    data = Convert.ToDouble(value);
                    break;
                }
                catch (System.FormatException)
                {
                    Console.Write(syntaxGen.SyntaxFiller1("Invalid input\n"));
                }
            }
            return data;
        }
    }
}