using System;
using System.Collections;
namespace ConsoleAppProject.App03
/// <summary>
/// This class parses datatypes to be used in the code
/// </summary>
/// <author>
/// Haroon Sadiq
/// </author>
{
    public class DataParser
    {
        // Link to SQLite database manager class
        DatabaseManager db = new DatabaseManager();
        //Works out percentage
        public double PercentileCalc(double lowVal, double highVal, double mark)
        {
            double percentage = (mark - lowVal) / (highVal - lowVal) * 100;
            return Math.Round((double)percentage, 1);
        }
        // Finds grade using the SQLite database
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
        // Used for a formatted syntax in table view
        public string GradeData(double total, double mark)
        {
            return mark + ": " + Math.Round((double)(mark / total * 100), 1);
        }
    }
}
