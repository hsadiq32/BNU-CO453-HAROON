using System;
using System.Collections;
using System.Linq;

namespace ConsoleAppProject.App03
/// <summary>
/// This class is used to manage student data for the webApp version
/// </summary>
/// <author>
/// Haroon Sadiq
/// </author>
{
    public class StudentMarks
    {
        // Prerequisite classes
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        Student student = new Student();
        DatabaseManager db = new DatabaseManager();
        // Sends overall data in a string array
        public string[] Data { get; set; }
        // Grade A amount
        public string GradeA { get; set; }
        // Grade B amount
        public string GradeB { get; set; }
        // Grade C amount
        public string GradeC { get; set; }
        // Grade D amount
        public string GradeD { get; set; }
        // Grade F amount
        public string GradeF { get; set; }
        // Min amount
        public string Min { get; set; }
        // Max amount
        public string Max { get; set; }
        // Min amount
        public string Mean { get; set; }
        // run method for console app
        public void Run()
        {
            syntaxGen.SubheaderGen("Student Marks");
            db.InitialiseTable();
            student.OverallStats();
            syntaxGen.SyntaxFiller2();
        }
        // Finds grade value using mark data
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
        // A multifuncational method which provides different data depending on what you want
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
