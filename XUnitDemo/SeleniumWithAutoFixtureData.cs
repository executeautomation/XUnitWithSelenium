using AutoFixture;
using System.Net.Mail;
using Xunit;
using Xunit.Abstractions;

namespace XUnitDemo
{
    /// <summary>
    /// Selenium with AutoFixtureData tests
    /// </summary>
    public class SeleniumWithAutoFixtureData : IClassFixture<WebDriverFixture>
    {

        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public SeleniumWithAutoFixtureData(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestRegisterUser()
        {
            var driver = webDriverFixture.ChromeDriver;
            testOutputHelper.WriteLine("First test");
            driver
                .Navigate()
                .GoToUrl("http://eaapp.somee.com");

            var userName = new Fixture().Create<string>();
            var password = new Fixture().Create<string>();
            var email = new Fixture().Create<MailAddress>();

            driver.FindElementByLinkText("Register").Click();
            driver.FindElementById("UserName").SendKeys(userName);
            driver.FindElementById("Password").SendKeys(password);
            driver.FindElementById("ConfirmPassword").SendKeys(password);
            driver.FindElementById("Email").SendKeys(email.Address);

            testOutputHelper.WriteLine("Test completed");
        }


        [Fact]
        public void TestRegisterUserWithType()
        {
            var driver = webDriverFixture.ChromeDriver;
            testOutputHelper.WriteLine("First test");
            driver
                .Navigate()
                .GoToUrl("http://eaapp.somee.com");

            var fixture = new Fixture();

            var model = fixture.Build<RegisterUserModel>()
                               .With(x => x.Email == "karthik@ea.com")
                               .Create();

            driver.FindElementByLinkText("Register").Click();
            driver.FindElementById("UserName").SendKeys(model.Name);
            driver.FindElementById("Password").SendKeys(model.Password);
            driver.FindElementById("ConfirmPassword").SendKeys(model.CPassword);
            driver.FindElementById("Email").SendKeys(model.Email);

            testOutputHelper.WriteLine("Test completed");
        }

    }
}
