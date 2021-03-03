using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App02;
using System;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class TestApp02
    {
        public string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            string name = sf.GetMethod().Name;
            name = name.Replace("Test", "");
            name = name.Replace("_", " ");
            return name;
        }
        public void SaveData(string testName, string inputData, string expectedResult, string actualResult, string comment)
        {
            string createText = "| " + testName + " | " + inputData + " | " + expectedResult + " | " + actualResult + " | " + comment + " |" + Environment.NewLine;
            File.AppendAllText(@"C:\programs\file.txt", createText);
        }
        [TestMethod]
        public void Test_Imperical_5ft0_UnderWeightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 100;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 19;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_5ft0_NormalBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 135;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 26;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_5ft0_OverweightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 155;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 30;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_5ft0_ObeseClassIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 180;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 35;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_5ft0_ObeseClassIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 210;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 41;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_5ft0_ObeseClassIIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 250;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 40;
                //Compensate for decimals
                if (expectedBMI <= result)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#") + "=<", result.ToString("0.#"), passCheck);
                Assert.IsTrue(expectedBMI <= result);
            }
        }
        [TestMethod]
        public void Test_Imperical_5ft6_UnderWeightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 6;
                double outputInches = bmi.Inches;

                bmi.Weight = 100;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 16;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_5ft6_NormalBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 6;
                double outputInches = bmi.Inches;

                bmi.Weight = 135;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 21;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_5ft6_OverweightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 6;
                double outputInches = bmi.Inches;

                bmi.Weight = 155;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 25;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_5ft6_ObeseClassIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 6;
                double outputInches = bmi.Inches;

                bmi.Weight = 180;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 29;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_5ft6_ObeseClassIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 6;
                double outputInches = bmi.Inches;

                bmi.Weight = 210;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 34;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_5ft6_ObeseClassIIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 5;
                double outputFeet = bmi.Feet;
                bmi.Inches = 6;
                double outputInches = bmi.Inches;

                bmi.Weight = 400;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 40;
                //Compensate for decimals
                if (expectedBMI <= result)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#") + "=<", result.ToString("0.#"), passCheck);
                Assert.IsTrue(expectedBMI <= result);
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft0_UnderWeightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 105;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 14;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft0_NormalBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 155;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 21;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft0_OverweightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 190;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 25;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft0_ObeseClassIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 215;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 29;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft0_ObeseClassIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 250;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 34;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft0_ObeseClassIIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 0;
                double outputInches = bmi.Inches;

                bmi.Weight = 400;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 40;
                //Compensate for decimals
                if (expectedBMI <= result)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#") + "=<", result.ToString("0.#"), passCheck);
                Assert.IsTrue(expectedBMI <= result);
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft4_UnderWeightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 4;
                double outputInches = bmi.Inches;

                bmi.Weight = 135;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 16;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft4_NormalBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 4;
                double outputInches = bmi.Inches;

                bmi.Weight = 175;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 21;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft4_OverweightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 4;
                double outputInches = bmi.Inches;

                bmi.Weight = 210;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 25;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft4_ObeseClassIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 4;
                double outputInches = bmi.Inches;

                bmi.Weight = 240;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 29;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft4_ObeseClassIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 4;
                double outputInches = bmi.Inches;

                bmi.Weight = 290;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 35;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Imperical_6ft4_ObeseClassIIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Feet = 6;
                double outputFeet = bmi.Feet;
                bmi.Inches = 4;
                double outputInches = bmi.Inches;

                bmi.Weight = 400;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(true);
                double result = bmi.Bmi;
                double expectedBMI = 40;
                //Compensate for decimals
                if (expectedBMI <= result)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "Feet: " + outputFeet + ", Inches:" + outputInches + ", Weight:" + outputWeight, expectedBMI.ToString("0.#") + "=<", result.ToString("0.#"), passCheck);
                Assert.IsTrue(expectedBMI <= result);
            }
        }
        [TestMethod]
        public void Test_Metric_152CM_UnderWeightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.52;
                double outputHeight = bmi.Height;



                bmi.Weight = 45.3592;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 19;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_152CM_NormalBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.52;
                double outputHeight = bmi.Height;



                bmi.Weight = 61.235;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 26;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_152CM_OverweightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.52;
                double outputHeight = bmi.Height;



                bmi.Weight = 70.3068;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 30;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_152CM_ObeseClassIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.52;
                double outputHeight = bmi.Height;



                bmi.Weight = 81.6466;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 35;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_152CM_ObeseClassIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.52;
                double outputHeight = bmi.Height;



                bmi.Weight = 95.2544;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 41;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_152CM_ObeseClassIIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.52;
                double outputHeight = bmi.Height;



                bmi.Weight = 113.398;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 40;
                //Compensate for decimals
                if (expectedBMI <= result)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#") + "=<", result.ToString("0.#"), passCheck);
                Assert.IsTrue(expectedBMI <= result);
            }
        }
        [TestMethod]
        public void Test_Metric_167CM_UnderWeightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.67;
                double outputHeight = bmi.Height;


                bmi.Weight = 45.3592;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 16;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_167CM_NormalBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.67;
                double outputHeight = bmi.Height;


                bmi.Weight = 61.235;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 21;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_167CM_OverweightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.67;
                double outputHeight = bmi.Height;


                bmi.Weight = 70.3068;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 25;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_167CM_ObeseClassIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.67;
                double outputHeight = bmi.Height;


                bmi.Weight = 81.6466;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 29;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_167CM_ObeseClassIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.67;
                double outputHeight = bmi.Height;


                bmi.Weight = 95.2544;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 34;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_167CM_ObeseClassIIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.67;
                double outputHeight = bmi.Height;


                bmi.Weight = 181.437;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 40;
                //Compensate for decimals
                if (expectedBMI <= result)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#") + "=<", result.ToString("0.#"), passCheck);
                Assert.IsTrue(expectedBMI <= result);
            }
        }
        [TestMethod]
        public void Test_Metric_182CM_UnderWeightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.82;
                double outputHeight = bmi.Height;



                bmi.Weight = 47.6272;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 14;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_182CM_NormalBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.82;
                double outputHeight = bmi.Height;



                bmi.Weight = 70.3068;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 21;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_182CM_OverweightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.82;
                double outputHeight = bmi.Height;



                bmi.Weight = 86;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 25;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_182CM_ObeseClassIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.82;
                double outputHeight = bmi.Height;



                bmi.Weight = 97.5224;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 29;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_182CM_ObeseClassIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.82;
                double outputHeight = bmi.Height;



                bmi.Weight = 113.398;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 34;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_182CM_ObeseClassIIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.82;
                double outputHeight = bmi.Height;



                bmi.Weight = 181.437;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 40;
                //Compensate for decimals
                if (expectedBMI <= result)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#") + "=<", result.ToString("0.#"), passCheck);
                Assert.IsTrue(expectedBMI <= result);
            }
        }
        [TestMethod]
        public void Test_Metric_193CM_UnderWeightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.93;
                double outputHeight = bmi.Height;


                bmi.Weight = 61.235;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 16;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_193CM_NormalBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.93;
                double outputHeight = bmi.Height;


                bmi.Weight = 79.3787;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 21;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_193CM_OverweightBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.93;
                double outputHeight = bmi.Height;


                bmi.Weight = 95.2544;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 25;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_193CM_ObeseClassIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.93;
                double outputHeight = bmi.Height;


                bmi.Weight = 108.862;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 29;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_193CM_ObeseClassIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.93;
                double outputHeight = bmi.Height;


                bmi.Weight = 131.542;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 35;
                //Compensate for decimals
                if ((expectedBMI - 1) <= result && result <= (expectedBMI + 1))
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#"), result.ToString("0.#"), passCheck);
                Assert.IsTrue((expectedBMI - 1) <= result && result <= (expectedBMI + 1));
            }
        }
        [TestMethod]
        public void Test_Metric_193CM_ObeseClassIIIBMI()
        {
            BMI bmi = new BMI();
            {
                string passCheck = "fail";
                bmi.Height = 1.93;
                double outputHeight = bmi.Height;


                bmi.Weight = 181.437;
                double outputWeight = bmi.Weight;

                bmi.BMIcalc(false);
                double result = bmi.Bmi;
                double expectedBMI = 40;
                //Compensate for decimals
                if (expectedBMI <= result)
                {
                    passCheck = "pass";
                }
                SaveData(GetCurrentMethod(), "CM: " + outputHeight + ", Weight:" + outputWeight, expectedBMI.ToString("0.#") + "=<", result.ToString("0.#"), passCheck);
                Assert.IsTrue(expectedBMI <= result);
            }
        }
    }
}
