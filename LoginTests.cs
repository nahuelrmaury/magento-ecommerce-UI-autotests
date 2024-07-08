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

        private static CreateAccountPage _createAccountPage;

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

            _createAccountPage = new CreateAccountPage(_driver);
        }

        [Test]
        public void T01_Login_ValidCredentials_Logged()
        {
            _loginPage.Login("nahuelrmaury@gmail.com", "teclado123!");

            var getLoggedIn = _loginPage.IsLoggedIn();
            Assert.That(getLoggedIn.Item1);
            Assert.That(Regex.IsMatch(getLoggedIn.Item2, welcomeMessagePattern));
        }

        [Test]
        public void T02_Login_ValidCredentials_Loggout()
        {
            _loginPage.Login("nahuelrmaury@gmail.com", "teclado123!");
            _loginPage.Logout();

            var getLoggedOut = _loginPage.IsLoggedOut();
            Assert.That(getLoggedOut, Is.True);
        }

        [Test]
        public void T03_Login_InvalidCredentials_WarningMessage()
        {
            _loginPage.Login("nahuelrmaury@gmail.com", "123456");

            var isCredentialInvalid = _loginPage.IsCredentialInvalid();
            Assert.That(isCredentialInvalid.Item1);
            Assert.That("The account sign-in was incorrect or your account is disabled temporarily. Please wait and try again later.", Is.EqualTo(isCredentialInvalid.Item2));
        }

        [Test]
        public void T04_CreateAccount_ValidCredentials_AccountCreated()
        {
            _createAccountPage.CreateAccount();
            var isAcountCreated = _loginPage.IsAccountCreated();
            Assert.That(isAcountCreated.Item1);
            Assert.That("Thank you for registering with Main Website Store.", Is.EqualTo(isAcountCreated.Item2));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

    }
}