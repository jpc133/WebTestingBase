using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace CoypuTestingSetup
{
    //In the following two classes replace 172.20.1.114:4444 with the address and port of your selenium server
    public class HeadlessChromeWebdriver : SeleniumWebDriver
    {
        public HeadlessChromeWebdriver(Browser browser)
            : base(new RemoteWebDriver(new Uri(@"http://172.20.1.114:4444/wd/hub"), CapabilitiesNew.HeadlessChrome()), browser)
        {
        }
    }

    public class ChromeWebdriver : SeleniumWebDriver
    {
        public ChromeWebdriver(Browser browser)
            : base(new RemoteWebDriver(new Uri(@"http://172.20.1.114:4444/wd/hub"), CapabilitiesNew.Chrome()), browser)
        {
        }
    }


    public static class CapabilitiesNew{
        static public DesiredCapabilities HeadlessChrome() 
        {
            ChromeOptions co = new ChromeOptions();
            co.AddArgument("--headless");
            co.AddArgument("--disable-gpu");
            co.AddArgument("--no-sandbox");

            DesiredCapabilities dc = DesiredCapabilities.Chrome();
            dc.SetCapability(ChromeOptions.Capability, co);

            return (DesiredCapabilities)co.ToCapabilities();
        }

        static public DesiredCapabilities Chrome()
        {
            ChromeOptions co = new ChromeOptions();
            co.AddArgument("--no-sandbox");

            DesiredCapabilities dc = DesiredCapabilities.Chrome();
            dc.SetCapability(ChromeOptions.Capability, co);

            return (DesiredCapabilities)co.ToCapabilities();
        }
    }
}
