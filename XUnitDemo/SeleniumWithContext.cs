using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace XUnitDemo
{
    /// <summary>
    /// Selenium with Context
    /// </summary>
    public class SeleniumWithContext : IClassFixture<WebDriverFixture>
    {
        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public SeleniumWithContext(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestRegisterUser(string username, string password, string cpassword, string email)
        {
            var driver = webDriverFixture.ChromeDriver;
            testOutputHelper.WriteLine("First test");
            driver
                .Navigate()
                .GoToUrl("http://eaapp.somee.com");

            driver.FindElementByLinkText("Register").Click();
            driver.FindElementById("UserName").SendKeys(username);
            driver.FindElementById("Password").SendKeys(password);
            driver.FindElementById("ConfirmPassword").SendKeys(cpassword);
            driver.FindElementById("Email").SendKeys(email);

            testOutputHelper.WriteLine("Test completed");
        }


        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]
            {
                "Karthik",
                "kartPassword",
                "kartPassword",
                "karthik@gmail.com"
            },
            new object[]
            {
                "Prashanth",
                "PrasPassword",
                "PrasPassword",
                "Prashanth@gmail.com"
            },
            new object[]
            {
                "James",
                "JamesPassword",
                "JamesPassword",
                "james@gmail.com"
            }
        };
    }
}
