# WebTestingBase
This contains the setup code and some useful helper classes for using C# Coypu and selenium for web test automation.

## Local Chrome testing
Local Chrome testing is the simplest way of testing, just use the following method:
```c#
setupTestEnviroment(false,"https://www.google.com")
```
this will return a BrowserSession that can then be used to run tests.

Here's an example of a method using local Chrome testing:
```c#
BrowserSession browser = CoypuHelper.setupTestEnviroment(false,"https://www.google.com");
string[,] data = FileHandling.readCSV("C:\\Users\\jonat\\Documents\\dataFile.csv");
for (int i = 0; i < data.GetLength(1); i++)
{
    browser.Visit("https://www.bing.com");
    browser.FindId("sb_form_q").SendKeys(data[0,i]);
    browser.FindId("sb_form_go").Click();
}
browser.Dispose();
```


## Remote Chrome testing / Remote headless Chrome testing
Remote testing is similar to local testing but requires a bit more configuration, the first thing you should do is setup either
a physical or virtual machine (Tested on an Ubuntu 16.04 Virtual Machine) with the following installed:
1. Google Chrome (not Chromium)
2. ChromeDriver (Must be installed in a place recognised by Selenium server)
3. Selenium server (Which requires java to be installed)

Next step is to setup the project, in the project there is a script file called HeadlessProfile.cs this contains IP addresses that
need to be set to the IP of the machine you set up earlier with Selenium server on.

Now you can use the methods ```setupChromeHeadlessEnviroment``` and ```setupChromeEnviroment``` 
like you would ```setupTestEnviroment```.

Before running your tests make sure Selenium server is running on the other machine and check the IPs are correct.
