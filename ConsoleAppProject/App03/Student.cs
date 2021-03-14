using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject.App03
{
    public class Student
    {
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        DatabaseManager db = new DatabaseManager();
        InputReader reader = new InputReader();
        DataParser parser = new DataParser();
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is Required.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabetical Characters are Allowed.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Marks is Required.")]
        [Range(0, 100)]
        public int Marks { get; set; }
        public string Grade { get; set; }
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
        public void ReadAll()
        {
            db.CountColumnDB("Students", "grade", "grade = 'B'");
            db.ReadAllDB("Students");
        }
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
