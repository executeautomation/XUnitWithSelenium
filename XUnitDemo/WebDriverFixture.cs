using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace XUnitDemo
{

    /// <summary>
    /// WebDriverFixture code for XUnit to handle
    /// Selenium WebDriver
    /// </summary>
    public class WebDriverFixture : IDisposable
    {
        public ChromeDriver ChromeDriver { get; private set; }

        public WebDriverFixture()
        {
            //WebDriverManager
            var driver = new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver = new ChromeDriver();
        }


        public void Dispose()
        {
            ChromeDriver.Quit();
            ChromeDriver.Dispose();
        }
    }
}
