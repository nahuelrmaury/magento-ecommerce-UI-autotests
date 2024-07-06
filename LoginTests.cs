using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using TestProject2.Pages;

namespace TestProject2
{
    public class Tests
    {
        private static IWebDriver _driver;

        private static IWebElement _basePage;

        private static LoginPage _loginPage;

        string welcomeMessagePattern = @"^Welcome, .+!$";

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArgument("headless");

            _driver = new ChromeDriver(chromeOptions);

            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/");

            _loginPage = new LoginPage(_driver);
        }

        [Test]
        public void T01_Login_ValidCredentials_Logged()
        {
            _loginPage.Login("nahuelrmaury@gmail.com", "teclado123!");

            var getLoggedIn = _loginPage.IsLoggedIn();
            Assert.That(getLoggedIn.Item1);
            Assert.That(Regex.IsMatch(getLoggedIn.Item2, welcomeMessagePattern));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

    }
}