using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Test_automation_Selenium_WebDriver;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.MarkupUtils;

namespace NUnit_Test_App
{
    [TestFixture]
    public class SeleniumFirstTest
    {
        public static ExtentTest test;

        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports extent { get { return _lazy.Value; } }


        public SeleniumFirstTest()
        {
            ExtentHtmlReporter htmlReporter = new(@"..\..\..\..\TestReports\NewTest.html");
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.ReportName = "ExtentReports With NUnit And Selenium";
            htmlReporter.Config.DocumentTitle = "NUint Test Report With Selenium";
            htmlReporter.Config.ReportName = "RenameTest.html";
            extent.AttachReporter(htmlReporter);
            extent.AttachReporter(htmlReporter);
        }
        /*
        [OneTimeSetUp]
        public static void Report()
        {
            // htmlReporter = new(");
        }
        */
        [SetUp]
        public void Setup()
        {
            GoogleSearch.SetDriver();
        }

        [Test, Order(1)]
        public void Searching_Using_Words()
        {
            test = extent.CreateTest("Searching_By_Words_Using_Selenium");
            GoogleSearch.SearchUsingWords();
        }

        [Test, Order(2)]
        [TestCase("100000")]
        [TestCase("Ahmed")]
        [TestCase("a@a.a")]
        public void Searching_Using_Many_Test_Cases(string words)
        {
            IMarkup m = MarkupHelper.CreateLabel(words, ExtentColor.Blue);
            test = extent.CreateTest("Searching By Using Many Test Cases");
            test.Log(Status.Pass, m);
            GoogleSearch.Driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(2));
            GoogleSearch.Driver.FindElement(By.Name("q")).SendKeys(words + Keys.Enter);
        }

        [TearDown]
        public void End()
        {
            //ExtentReports
            test.Log(test.Status, TestContext.CurrentContext.Result.Message);
            //ExtentReports
            extent.Flush();

            // Close WebDriver
            GoogleSearch.Driver.Close();
        }

    }
}