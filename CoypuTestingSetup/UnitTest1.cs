using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coypu;
using System.Threading;

namespace CoypuTestingSetup
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SelfTest()
        {
            BrowserSession browser = CoypuHelper.setupTestEnviroment(true,"https://www.google.com");
            string[,] data = FileHandling.readCSV("C:\\Users\\jonat\\Documents\\dataFile.csv");
            for (int i = 0; i < data.GetLength(1); i++)
            {
                browser.Visit("https://www.bing.com");
                browser.FindId("sb_form_q").SendKeys(data[0,i]);
                browser.FindId("sb_form_go").Click();
            }
            browser.Dispose();
        }


        [TestMethod]
        public void Test2()
        {
            //                                                    headless, URL
            BrowserSession browser = CoypuHelper.setupTestEnviroment(false, "https://www.google.com");
            browser.Visit("https://www.google.com");

            browser.Dispose();
        }

    }
}
