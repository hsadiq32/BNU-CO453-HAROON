using System;
using System.Collections;

namespace ConsoleAppProject.App03
{
    class StudentMarks
    {
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        InputReader reader = new InputReader();
        Student student = new Student();
        DatabaseManager db = new DatabaseManager();

        public void Run()
        {
            syntaxGen.SubheaderGen("Student Marks");
            db.InitialiseTable();
            student.OverallStats();
            student.StudentOptions();
        }
    }

}
