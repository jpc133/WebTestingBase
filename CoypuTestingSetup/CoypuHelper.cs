using System;
using Coypu;
using Coypu.Drivers;

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
    }
}
