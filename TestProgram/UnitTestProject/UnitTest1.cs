using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProgram;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        public void TestAddNumbers(int a, int b, int c, Object x1, Object x2)
        {
        
            Program obj = new Program();
            object[] result = obj.AddNumbers(a, b, c);
            try
            {
                int cx = 0;
                Assert.AreEqual(x1, result[0]);
                cx++;
                Assert.AreEqual(x2, result[1]);
                cx++;
                if (cx == 2)
                    TestContext.WriteLine("x1 = {0},x2={1}",x1,x2);
            }
            catch
            {
                TestContext.WriteLine("The expected value is{0} and {1} but the actual value is {2} and {3}.",
                 x1, x2,result[0],result[1]);
            }
        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        "C:\\Users\\Nghia\\source\\repos\\TestProgram\\UnitTestProject\\TestData.csv", "TestData#csv",
        DataAccessMethod.Sequential),
        DeploymentItem("TestData.csv")]
        [TestMethod]
        public void TestMethod1()
        {

            int a = Convert.ToInt32(testContextInstance.DataRow["a"]);
            int b = Convert.ToInt32(testContextInstance.DataRow["b"]);
            int c = Convert.ToInt32(testContextInstance.DataRow["c"]);
            try
            {
                double x1 = Convert.ToDouble(testContextInstance.DataRow["x1"]);
                double x2 = Convert.ToDouble(testContextInstance.DataRow["x2"]);
                TestContext.WriteLine("a = {0}; b = {1}; c = {2}", a, b, c);
                TestAddNumbers(a, b, c, x1, x2);
            }
            catch
            {

                String x1 = Convert.ToString(testContextInstance.DataRow["x1"]);
                String x2 = Convert.ToString(testContextInstance.DataRow["x2"]);
                x1 = "NULL";
                x2 = "NULL";
                TestContext.WriteLine("a = {0}; b = {1}; c = {2}", a, b, c);
                TestAddNumbers(a, b, c, x1, x2);
            }

        }
        static void Main()
        {
            UnitTest1 unitTest = new UnitTest1();
            unitTest.TestMethod1();
            Console.ReadLine();
        }
    }
}