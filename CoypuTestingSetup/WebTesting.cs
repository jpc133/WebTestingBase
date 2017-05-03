﻿//Copyright 2017 Jonathan Clarke
//Please see NOTICE.txt, if NOTICE.txt is not present
//email jonathan.clarke73@gmail.com for a copy
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coypu;
using CoypuTestingSetup;

namespace TestExample
{
    [TestClass]
    public class UnitTest1
    {
        //Requires selenium server to be running manually
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
