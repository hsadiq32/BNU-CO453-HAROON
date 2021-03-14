using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App03;
using System;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class TestApp03
    {
        public string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            string name = sf.GetMethod().Name;
            name = name.Replace("_", " ");
            return name;
        }
        public void SaveData(string testName, string inputData, string expectedResult, string actualResult, string comment)
        {
            string createText = "| " + testName + " | " + inputData + " | " + expectedResult + " | " + actualResult + " | " + comment + " |" + Environment.NewLine;
            File.AppendAllText(@"C:\programs\file.txt", createText);
        }
        [TestMethod]
        public void Test_Grade_F_10_Marks()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 10;

                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "F";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_F_20_Marks()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 20;

                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "F";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_F_30_Marks()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 30;

                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "F";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_D_40_Marks()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 40;

                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "D";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_C_50_Marks()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 50;

                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "C";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_B_60_Marks()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 60;

                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "B";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_A_70_Marks()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 70;

                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "A";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_A_80_Marks()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 80;

                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "A";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_A_90_Marks()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 90;

                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "A";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_A_100_Marks()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 100;

                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "A";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_F_Random()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string result = "fail";
                string expectedResult = "";
                Random rand = new Random();
                for (int i = 1; i < 6; i++)
                {
                    string passCheck = "fail";
                    int marks = rand.Next(0, 40);
                    result = studentMarks.GradeFinder(marks);
                    expectedResult = "F";

                    if (result == expectedResult)
                    {
                        passCheck = "pass";
                    }
                    SaveData(GetCurrentMethod() + " Loop Test: " + i, "Marks:" + marks, expectedResult, result, passCheck);
                }
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_D_Random()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string result = "fail";
                string expectedResult = "";
                Random rand = new Random();
                for (int i = 1; i < 6; i++)
                {
                    string passCheck = "fail";
                    int marks = rand.Next(40, 50);
                    result = studentMarks.GradeFinder(marks);
                    expectedResult = "D";

                    if (result == expectedResult)
                    {
                        passCheck = "pass";
                    }
                    SaveData(GetCurrentMethod() + " Loop Test: " + i, "Marks:" + marks, expectedResult, result, passCheck);
                }
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_C_Random()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string result = "fail";
                string expectedResult = "";
                Random rand = new Random();
                for (int i = 1; i < 6; i++)
                {
                    string passCheck = "fail";
                    int marks = rand.Next(50, 60);
                    result = studentMarks.GradeFinder(marks);
                    expectedResult = "C";

                    if (result == expectedResult)
                    {
                        passCheck = "pass";
                    }
                    SaveData(GetCurrentMethod() + " Loop Test: " + i, "Marks:" + marks, expectedResult, result, passCheck);
                }
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_B_Random()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string result = "fail";
                string expectedResult = "";
                Random rand = new Random();
                for (int i = 1; i < 6; i++)
                {
                    string passCheck = "fail";
                    int marks = rand.Next(60, 70);
                    result = studentMarks.GradeFinder(marks);
                    expectedResult = "B";

                    if (result == expectedResult)
                    {
                        passCheck = "pass";
                    }
                    SaveData(GetCurrentMethod() + " Loop Test: " + i, "Marks:" + marks, expectedResult, result, passCheck);
                }
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_A_Random()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string result = "fail";
                string expectedResult = "";
                Random rand = new Random();
                for (int i = 1; i < 6; i++)
                {
                    string passCheck = "fail";
                    int marks = rand.Next(70, 100);
                    result = studentMarks.GradeFinder(marks);
                    expectedResult = "A";

                    if (result == expectedResult)
                    {
                        passCheck = "pass";
                    }
                    SaveData(GetCurrentMethod() + " Loop Test: " + i, "Marks:" + marks, expectedResult, result, passCheck);
                }
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Percentage_10()
        {
            DataParser dataParser = new DataParser();
            {
                string passCheck = "fail";
                int marks = 10;
                string[] splitter = dataParser.GradeData(100, marks).Split(": ");
                string result = splitter[1] + "%";
                string expectedResult = "10%";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Percentage_20()
        {
            DataParser dataParser = new DataParser();
            {
                string passCheck = "fail";
                int marks = 20;
                string[] splitter = dataParser.GradeData(100, marks).Split(": ");
                string result = splitter[1] + "%";
                string expectedResult = "20%";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Percentage_30()
        {
            DataParser dataParser = new DataParser();
            {
                string passCheck = "fail";
                int marks = 30;
                string[] splitter = dataParser.GradeData(100, marks).Split(": ");
                string result = splitter[1] + "%";
                string expectedResult = "30%";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Percentage_40()
        {
            DataParser dataParser = new DataParser();
            {
                string passCheck = "fail";
                int marks = 40;
                string[] splitter = dataParser.GradeData(100, marks).Split(": ");
                string result = splitter[1] + "%";
                string expectedResult = "40%";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Percentage_50()
        {
            DataParser dataParser = new DataParser();
            {
                string passCheck = "fail";
                int marks = 50;
                string[] splitter = dataParser.GradeData(100, marks).Split(": ");
                string result = splitter[1] + "%";
                string expectedResult = "50%";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Percentage_60()
        {
            DataParser dataParser = new DataParser();
            {
                string passCheck = "fail";
                int marks = 60;
                string[] splitter = dataParser.GradeData(100, marks).Split(": ");
                string result = splitter[1] + "%";
                string expectedResult = "60%";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Percentage_70()
        {
            DataParser dataParser = new DataParser();
            {
                string passCheck = "fail";
                int marks = 70;
                string[] splitter = dataParser.GradeData(100, marks).Split(": ");
                string result = splitter[1] + "%";
                string expectedResult = "70%";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Percentage_80()
        {
            DataParser dataParser = new DataParser();
            {
                string passCheck = "fail";
                int marks = 80;
                string[] splitter = dataParser.GradeData(100, marks).Split(": ");
                string result = splitter[1] + "%";
                string expectedResult = "80%";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Percentage_90()
        {
            DataParser dataParser = new DataParser();
            {
                string passCheck = "fail";
                int marks = 90;
                string[] splitter = dataParser.GradeData(100, marks).Split(": ");
                string result = splitter[1] + "%";
                string expectedResult = "90%";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Percentage_100()
        {
            DataParser dataParser = new DataParser();
            {
                string passCheck = "fail";
                int marks = 100;
                string[] splitter = dataParser.GradeData(100, marks).Split(": ");
                string result = splitter[1] + "%";
                string expectedResult = "100%";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Total: 100, Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
    }
}
