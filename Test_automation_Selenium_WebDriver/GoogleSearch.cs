using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Test_automation_Selenium_WebDriver
{
    public static class GoogleSearch
    {
        private static DriverManager Manager = new();
        public static IWebDriver Driver;

        public static void SetDriver()
        {
            Manager.SetUpDriver(new EdgeConfig());
            Driver = new EdgeDriver();
            Driver.Url = "http://google.com";
        }

        public static void SearchUsingWords()
        {
            Driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(2));
            Driver.FindElement(By.Name("q")).SendKeys("Test"+ Keys.Enter);

        }
    }
}
