using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;

namespace XUnitDemo
{
    /// <summary>
    /// Contains Selenium Test with IClassFixture running in Sequence
    /// </summary>
    [Collection("Sequence")]
    public class SecondSeleniumTest : IClassFixture<WebDriverFixture>
    {

        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public SecondSeleniumTest(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ClassFixtureTestNavigate()
        {
            testOutputHelper.WriteLine("First test");
            webDriverFixture.ChromeDriver
                .Navigate()
                .GoToUrl("http://eaapp.somee.com");

            var anchor = webDriverFixture.ChromeDriver
                                .FindElementsByTagName("a");

            anchor.Should().HaveCountGreaterThan(2);

        }



        [Theory]
        [InlineData("admin", "password")]
        [InlineData("admin", "password2")]
        [InlineData("admin", "password3")]
        [InlineData("admin", "password4")]
        public void TestLoginWithFillData(string username, string password)
        {
            var driver = webDriverFixture.ChromeDriver;
            testOutputHelper.WriteLine("First test");
            driver
                .Navigate()
                .GoToUrl("http://eaapp.somee.com");

            driver.FindElementByLinkText("Login").Click();
            driver.FindElementById("UserName").SendKeys(username);
            driver.FindElementById("Password").SendKeys(password);

            var exception = Assert.Throws<NoSuchElementException>(
                () => driver.FindElementByCssSelector(".btn-defaults")
                            .Click());

            exception.Message
                .Should()
                .Contain("no such element: Unable");

            testOutputHelper.WriteLine("Test completed");
        }
    }
}
