//Copyright 2017 Jonathan Clarke
//Please see NOTICE.txt, if NOTICE.txt is not present
//email jonathan.clarke73@gmail.com for a copy
using System;
using Coypu;
using Coypu.Drivers;

namespace CoypuTestingSetup
{
    public class CoypuHelper
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
