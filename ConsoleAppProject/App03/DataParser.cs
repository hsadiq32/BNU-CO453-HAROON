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
        public string GradeIdentifier(int mark)
        {
            mark = reader.RangeInputChecker("number:", 0, 100);
            mark = Convert.ToInt16(db.ReadMaxValGradeDB("Grades", "range", "range <=" + mark));
            string grade = db.ReadGradeDB("Grades", "grade", "range =" + mark);
            string classification =  db.ReadGradeDB("Grades", "classification", "range =" + mark);
            return grade + "," + classification;
        }
        public void GradeData()
        {
            markData.Remove(markData);
            markData.Add("39,F,Fail");
            markData.Add("49,D,Third Class");
            markData.Add("59,C,Lower Second Class");
            markData.Add("69,B,Upper Second Class");
            markData.Add("70,A,First Class");
        }
    }
}
