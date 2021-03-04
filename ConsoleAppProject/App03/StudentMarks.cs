using System;
using System.Collections;

namespace ConsoleAppProject.App03
{
    class StudentMarks
    {
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        ArrayList markData = new ArrayList();
        InputReader reader = new InputReader();
        public string Grade { get; set; }
        public int Marks { get; set; }
        public string GradeDescription { get; set; }
        public int MarkRange { get; set; }

        public void Run()
        {
            Marks = reader.IntInputChecker("Marks:");
            Console.WriteLine(GradeIdentifier(0));
            Console.WriteLine(GradeIdentifier(1));
        }

        public string GradeIdentifier(int dataOutputType)
        {
            GradeData();
            foreach (string arrayData in markData)
            {
                if (!reader.NullChecker(Marks))
                {
                    if (Marks <= MarkRange)
                    {
                        break;
                    }
                    else
                    {
                        string[] splitter = arrayData.Split(",");
                        MarkRange = Convert.ToInt16(splitter[0]);
                        Grade = splitter[1];
                        GradeDescription = splitter[2];
                    }
                }
                else
                {
                    Grade = "";
                    GradeDescription = "";
                }
            }
            if (dataOutputType == 0)
            {
                return Grade;
            }
            else
            {
                return GradeDescription;
            }
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
