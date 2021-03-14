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
        public void Test_Grade_F()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 19;
                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "F";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_D()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 45;
                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "D";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_C()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 59;
                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "C";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_B()
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
                SaveData(GetCurrentMethod(), "Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
        [TestMethod]
        public void Test_Grade_A()
        {
            StudentMarks studentMarks = new StudentMarks();
            {
                string passCheck = "fail";
                int marks = 71;
                string result = studentMarks.GradeFinder(marks);
                string expectedResult = "A";

                if (result == expectedResult)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Marks:" + marks, expectedResult, result, passCheck);
                Assert.IsTrue(result == expectedResult);
            }
        }
    }
}
