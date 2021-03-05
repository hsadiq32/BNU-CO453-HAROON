using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App03
{
    public class Student
    {
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        DatabaseManager db = new DatabaseManager();
        InputReader reader = new InputReader();
        public int ID { get; set; }
        public string Name { get; set; }

        public void AddStudentCheck()
        {
            db.InitialiseTable();
            while (true)
            {
                Name = reader.StringInputChecker("Enter Name:");
                string res = db.ReadDB("Students", "name", "name = '" + Name + "'");
                if (reader.NullChecker(res))
                {
                    Console.WriteLine(Name);
                    db.InsertDB("Students", "name", "'" + Name + "'");
                    Console.WriteLine(syntaxGen.SyntaxFiller1("Added " + Name + " Successfully"));
                    break;
                }
                else
                {
                    Console.WriteLine(syntaxGen.SyntaxFiller1("Error: Invalid Input"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" 1. Try Again"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" 2. Quit"));
                    int option = reader.RangeInputChecker("Enter an Option:", 1, 2);
                    if(option == 2)
                    {
                        break;
                    }
                }
            }
        }
        public void AddStudentExecute()
        {
            db.InsertDB("Students", "name", "'" + Name + "'");
        }
        public void ReadAll()
        {
            db.InitialiseTable();
            db.ReadAllDB("Students");
        }
    }
}
