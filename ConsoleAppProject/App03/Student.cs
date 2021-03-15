using System;
using System.ComponentModel.DataAnnotations;
namespace ConsoleAppProject.App03
/// <summary>
/// This class manages students data and prompts to modify, create and delete given data
/// </summary>
/// <author>
/// Haroon Sadiq
/// </author>
{
    public class Student
    {
        // Link required classes
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        DatabaseManager db = new DatabaseManager();
        InputReader reader = new InputReader();
        DataParser parser = new DataParser();
        // ID of student
        public int ID { get; set; }
        // Name of student with input protection
        [Required(ErrorMessage = "Name is Required.")]
        [RegularExpression("^[a-zA-Z ']*$", ErrorMessage = "Only Alphabetical Characters are Allowed.")]
        public string Name { get; set; }
        // Marks of student with input protection
        [Required(ErrorMessage = "Marks is Required.")]
        [Range(0, 100)]
        public int Marks { get; set; }
        // Grade of student
        public string Grade { get; set; }

        // Finds grade using an efficient list range algorithm I made
        public string GradeFinder()
        {
            string grade = "";
            int markRange = 70;
            string[] gradeData = { "70,A", "60,B", "50,C", "40,D", "0,F" };
            for (int i = 0; i < 5; i++)
            {
                if (i != 4)
                {
                    if (markRange <= Marks)
                    {
                        grade = gradeData[i][3].ToString();
                        break;
                    }
                    markRange -= 10;
                }
                else
                {
                    grade = "F";
                }
            }
            return grade;
        }
        // Checks in the SQLite databse if student already exists, if so allow the user to proceed
        public void StudentMatchCheck()
        {
            while (true)
            {
                Name = reader.StringInputChecker("Enter Name:");
                string res = db.ReadDB("Students", "name", "name = '" + Name + "'");
                if (!reader.NullChecker(res))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(syntaxGen.SyntaxFiller1("Error: Invalid Input"));
                }
            }
        }
        // Checks in the SQLite databse if student already exists, if not allow the user to proceed
        public void StudentConflictCheck()
        {
            while (true)
            {
                Name = reader.StringInputChecker("Enter Name:");
                string res = db.ReadDB("Students", "name", "name = '" + Name + "'");
                if (reader.NullChecker(res))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(syntaxGen.SyntaxFiller1("Error: Invalid Input"));
                }
            }
        }
        // Adds student to the database
        public void AddStudent(bool check)
        {
            db.InitialiseTable();
            if (check)
            {
                StudentConflictCheck();
            }
            else
            {
                Name = reader.StringInputChecker("Enter Name:");
            }
            Marks = reader.RangeInputChecker("Marks:", 0, 100);
            Grade = parser.GradeIdentifier(Marks, 0);
            db.InsertDB("Students", "name,marks,grade", "'" + Name + "'," + Marks + ",'" + Grade + "'");
            Console.WriteLine(syntaxGen.SyntaxFiller1("Added " + Name + " Successfully"));
        }
        // Student super user options, allowing the user to modify names and marks and delete the students data
        public void StudentOptions()
        {
            bool choice = false;
            int min;
            int max;
            try
            {
                min = Convert.ToInt16(db.ReadMinValDB("Students", "Marks"));
                max = Convert.ToInt16(db.ReadMaxValDB("Students", "Marks"));
            }
            catch (FormatException)
            {
                choice = true;
            }
            if (!choice)
            {
                StudentMatchCheck();
                while (true)
                {
                    int id = Convert.ToInt16(db.ReadDB("Students", "ID", "name = '" + Name + "'"));
                    int mark = Convert.ToInt16(db.ReadDB("Students", "marks", "name = '" + Name + "'"));
                    string grade = db.ReadDB("Students", "grade", "name = '" + Name + "'");
                    min = Convert.ToInt16(db.ReadMinValDB("Students", "Marks"));
                    max = Convert.ToInt16(db.ReadMaxValDB("Students", "Marks"));
                    double percentile = parser.PercentileCalc(min, max, mark);
                    Console.WriteLine(syntaxGen.SyntaxFiller1("You are now logged in " + Name + "'s Data"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(""));
                    Console.WriteLine(syntaxGen.SyntaxFiller1("Account Data:"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" ┌────┬────────────────────────────────────┬─────┬─────┬──────────┐"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" │" + $@"{"ID",-4}│{"Name",-36}│{"Mark",-5}│{"Grade",-5}│{"Percentile",-10}" + "│"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" ├────┼────────────────────────────────────┼─────┼─────┼──────────┤"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" │" + $@"{id,-4}│{Name,-36}│{mark,-5}│{grade,-5}│{percentile + "%",-10}" + "│"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" └────┴────────────────────────────────────┴─────┴─────┴──────────┘"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(""));
                    Console.WriteLine(syntaxGen.SyntaxFiller1("Account Options:"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" 1. Change Name"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" 2. Change Mark"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" 3. Delete Data"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" 4. Go Back"));
                    int option = reader.RangeInputChecker("Enter an Option: ", 1, 4);
                    if (option.Equals(1))
                    {
                        // If changing the name check for conflicts to avoid duplicates in database
                        StudentConflictCheck();
                        db.UpdateDB("Students", "name = '" + Name + "'", "ID = " + id);
                    }
                    else if (option.Equals(2))
                    {
                        int newMark = reader.RangeInputChecker("Enter new Mark: ", 0, 100);
                        db.UpdateDB("Students", "marks = " + newMark + ", grade = '" + parser.GradeIdentifier(newMark, 0) + "'", "ID = " + id);
                    }
                    else if (option.Equals(3))
                    {
                        db.DeleteRowDB("Students", "ID = " + id);
                        break;
                    }
                    else if (option.Equals(4))
                    {
                        break;
                    }
                }
            }
        }
        // Reads all data in database
        public void ReadAll()
        {
            db.CountColumnDB("Students", "grade", "grade = 'B'");
            db.ReadAllDB("Students");
        }
        // Provides sleek looking tables to view overall data of students
        public void OverallStats()
        {
            while (true)
            {
                int min = 0;
                int max = 0;
                double mean = 0;
                bool check = false;
                try
                {
                    min = Convert.ToInt16(db.ReadMinValDB("Students", "Marks"));
                    max = Convert.ToInt16(db.ReadMaxValDB("Students", "Marks"));
                    mean = Math.Round((double)Convert.ToDouble(db.ColumnAverageDB("Students", "marks", "none")), 1);
                }
                catch (FormatException)
                {
                    Console.WriteLine(syntaxGen.SyntaxFiller1(""));
                    Console.WriteLine(syntaxGen.SyntaxFiller1("Data Not Found, add a student to see results"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(""));
                    check = true;
                }
                if (!check)
                {
                    db.ReadAllDB("Students");
                    double a = Convert.ToDouble(db.CountColumnDB("Students", "grade", "grade = 'A'"));
                    double b = Convert.ToDouble(db.CountColumnDB("Students", "grade", "grade = 'B'"));
                    double c = Convert.ToDouble(db.CountColumnDB("Students", "grade", "grade = 'C'"));
                    double d = Convert.ToDouble(db.CountColumnDB("Students", "grade", "grade = 'D'"));
                    double f = Convert.ToDouble(db.CountColumnDB("Students", "grade", "grade = 'F'"));
                    double total = a + b + c + d + f;
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" ┌──────────────┐ ┌────────────┐"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" │" + $@"{" Grades",-14}│ │{" Marks",-12}│"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" ├───┬──────────┤ ├──────┬─────┤"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" │ A │" + $@"{" " + parser.GradeData(total, a) + "%",-10}│ │ Min  │{" " + min,-5}│"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" │ B │" + $@"{" " + parser.GradeData(total,b) + "%",-10}│ │ Max  │{" " + max,-5}│"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" │ C │" + $@"{" " + parser.GradeData(total, c) + "%",-10}│ │ Mean │{" " + mean,-5}│"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" │ D │" + $@"{" " + parser.GradeData(total, d) + "%",-10}│ └──────┴─────┘"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" │ F │" + $@"{" " + parser.GradeData(total, f) + "%",-10}│"));
                    Console.WriteLine(syntaxGen.SyntaxFiller1(" └───┴──────────┘"));
                }
                Console.WriteLine(syntaxGen.SyntaxFiller1("Options: "));
                Console.WriteLine(syntaxGen.SyntaxFiller1(" 1. Add Student "));
                Console.WriteLine(syntaxGen.SyntaxFiller1(" 2. Modify Student "));
                Console.WriteLine(syntaxGen.SyntaxFiller1(" 3. Quit "));
                int option = reader.RangeInputChecker("Enter an Option:", 1, 3);
                if (option.Equals(1))
                {
                    AddStudent(true);
                }
                else if (option.Equals(2))
                {
                    StudentOptions();
                }
                else
                {
                    break;
                }
            }

        }
    }
}
