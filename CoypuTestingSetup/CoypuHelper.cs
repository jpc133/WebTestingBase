using System;
using Coypu;
using Coypu.Drivers;
using System.Threading;
using System.Diagnostics;
using OpenQA.Selenium.Remote;

namespace CoypuTestingSetup
{
    class CoypuHelper
    {
        public static BrowserSession setupTestEnviroment(bool headless, string websiteToStartAt)
        {
            Browser browserToUse = Browser.Chrome;
            if (headless) { browserToUse = Browser.HtmlUnit; }
            SessionConfiguration sessionConfig = new SessionConfiguration()
            {
                Browser = browserToUse,
                Driver = typeof(Coypu.Drivers.Selenium.SeleniumWebDriver),
                AppHost = websiteToStartAt,
                SSL = true,
                Timeout = TimeSpan.FromSeconds(10),
                RetryInterval = TimeSpan.FromSeconds(0.1),
                Match = Match.First,
            };
            return new BrowserSession(sessionConfig);
        }

        //Please set the IPs in Headless profile.cs before using this method
        public static BrowserSession setupChromeHeadlessEnviroment(string websiteToStartAt)
        {
            Browser browserToUse = Browser.Chrome;
            
            SessionConfiguration sessionConfig = new SessionConfiguration()
            {
                Browser = browserToUse,
                Driver = typeof(HeadlessChromeWebdriver),
                AppHost = websiteToStartAt,
                SSL = true,
                Timeout = TimeSpan.FromSeconds(10),
                RetryInterval = TimeSpan.FromSeconds(0.1),
                Match = Match.First,
            };
            
            return new BrowserSession(sessionConfig);
        }

        //Please set the IPs in Headless profile.cs before using this method
        public static BrowserSession setupRemoteChromeEnviroment(string websiteToStartAt)
        {
            Browser browserToUse = Browser.Chrome;

            SessionConfiguration sessionConfig = new SessionConfiguration()
            {
                Browser = browserToUse,
                Driver = typeof(ChromeWebdriver),
                AppHost = websiteToStartAt,
                SSL = true,
                Timeout = TimeSpan.FromSeconds(10),
                RetryInterval = TimeSpan.FromSeconds(0.1),
                Match = Match.First,
            };

            return new BrowserSession(sessionConfig);
        }
    }
}
