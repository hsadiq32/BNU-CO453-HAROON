using System;
using System.Collections;
using System.Linq;

namespace ConsoleAppProject.App03
{
    public class StudentMarks
    {
        ArrayList data = new ArrayList();
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        Student student = new Student();
        DatabaseManager db = new DatabaseManager();
        DataParser parse = new DataParser();
        public string[] Data { get; set; }
        public string GradeA { get; set; }
        public string GradeB { get; set; }
        public string GradeC { get; set; }
        public string GradeD { get; set; }
        public string GradeF { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Mean { get; set; }
        public void Run()
        {
            syntaxGen.SubheaderGen("Student Marks");
            db.InitialiseTable();
            student.OverallStats();
            syntaxGen.SyntaxFiller2();
        }

        public string GradeFinder(int mark)
        {
            string grade = "";
            int markRange = 70;
            string[] gradeData = { "70,A", "60,B", "50,C", "40,D", "0,F" };
            for (int i = 0; i < 5; i++)
            {
                if (i != 4)
                {
                    if (markRange <= mark)
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
        public double[] StatFinder(string option)
        {
            if (option.Contains("multi"))
            {
                string allData = "";
                foreach (string res in Data)
                {
                    string[] splitter = res.Split(",");
                    int mark = Convert.ToInt16(splitter[1]);
                    allData += GradeFinder(mark);
                }
                double[] listData = new double[6];
                listData[0] = allData.Length;
                listData[1] = allData.ToCharArray().Count(c => c == 'A');
                listData[2] = allData.ToCharArray().Count(c => c == 'B');
                listData[3] = allData.ToCharArray().Count(c => c == 'C');
                listData[4] = allData.ToCharArray().Count(c => c == 'D');
                listData[5] = allData.ToCharArray().Count(c => c == 'F');
                return listData;
            }
            else if (option.Contains("min"))
            {
                double min = 100;
                foreach (string res in Data)
                {
                    string[] splitter = res.Split(",");
                    double mark = Convert.ToDouble(splitter[1]);
                    if (mark < min)
                    {
                        min = mark;
                    }
                }
                Min = min.ToString();
                double[] listData = new double[1];
                listData[0] = min;
                return listData;
            }
            else if (option.Contains("max"))
            {
                double max = 0;
                foreach (string res in Data)
                {
                    string[] splitter = res.Split(",");
                    double mark = Convert.ToDouble(splitter[1]);
                    if (mark > max)
                    {
                        max = mark;
                    }
                }
                Max = max.ToString();
                double[] listData = new double[1];
                listData[0] = max;
                return listData;
            }
            else if (option.Contains("mean"))
            {
                double total = 0;
                double mean = 0;
                foreach (string res in Data)
                {
                    string[] splitter = res.Split(",");
                    double mark = Convert.ToDouble(splitter[1]);
                    total += mark;
                }
                try
                {
                    mean = total / Convert.ToDouble(Data.Length);
                }
                catch (Exception)
                {
                    mean = 0;
                }
                double[] listData = new double[1];
                listData[0] = mean;
                Mean = mean.ToString();
                return listData;
            }
            else
            {
                double[] listData = new double[1];
                listData[0] = 0;
                return listData;
            }
        }
    }

}
