using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;
using Xunit.Abstractions;

namespace XUnitDemo
{
    /// <summary>
    /// Selenium withoutContext
    /// </summary>
    public class SeleniumWithOutContext
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly ChromeDriver chromeDriver;

        public SeleniumWithOutContext(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            //WebDriverManager
            var driver = new DriverManager().SetUpDriver(new ChromeConfig());
            chromeDriver = new ChromeDriver();

        }

        [Fact]
        public void Test1()
        {
            Console.WriteLine("First test");
            testOutputHelper.WriteLine("First test");
            chromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
        }
    }
}
