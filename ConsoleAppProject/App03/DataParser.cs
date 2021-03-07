using System;
using System.Collections;

namespace ConsoleAppProject.App03
{
    class DataParser
    {
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        ArrayList markData = new ArrayList();
        InputReader reader = new InputReader();
        DatabaseManager db = new DatabaseManager();

        public string Grade { get; set; }
        public int Marks { get; set; }
        public string GradeDescription { get; set; }
        public int MarkRange { get; set; }

        public double PercentileCalc(double lowVal, double highVal, double mark)
        {
            double percentage = (mark - lowVal) / (highVal - lowVal) * 100;
            Console.WriteLine(percentage);
            return Math.Round((double)percentage, 1);
        }
        public string GradeIdentifier(int mark, int option)
        {
            mark = Convert.ToInt16(db.ReadMaxValGradeDB("Grades", "range", "range <=" + mark));
            string grade = db.ReadGradeDB("Grades", "grade", "range =" + mark);
            string classification =  db.ReadGradeDB("Grades", "classification", "range =" + mark);
            if(option == 0)
            {
                return grade;
            }
            else if (option == 1)
            {
                return classification;
            }
            else
            {
                return "NaN";
            }
        }
        public string GradeData(double total, double mark)
        {
            return mark + ": " + Math.Round((double)(mark / total * 100), 1);
        }
    }
}
