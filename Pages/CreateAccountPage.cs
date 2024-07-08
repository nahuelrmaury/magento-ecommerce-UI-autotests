using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Helpers;

namespace TestProject2.Pages
{
    public class CreateAccountPage : BasePage
    {
        // Locators
        private By CreateAccountFirstNameLocator = By.Id("firstname");
        private By CreateAccountSecondNameLocator = By.Id("lastname");
        private By CreateAccountEmailLocator = By.Id("email_address");
        private By CreateAccountPasswordLocator = By.Id("password");
        private By CreateAccountConfirmPasswordLocator = By.Id("password-confirmation");
        private By ConfirmCreateAccountButtonLocator = By.CssSelector("button[title='Create an Account'] span");
        private By CreateAccountButtonLocator = By.CssSelector("header[class='page-header'] li:nth-child(3) a:nth-child(1)");
        //Web Elements
        private IWebElement CreateAccountButton => _driver.FindElement(CreateAccountButtonLocator);
        private IWebElement CreateAccountFirstName => _driver.FindElement(CreateAccountFirstNameLocator);
        private IWebElement CreateAccountSecondName => _driver.FindElement(CreateAccountSecondNameLocator);
        private IWebElement CreateAccountEmail => _driver.FindElement(CreateAccountEmailLocator);
        private IWebElement CreateAccountPassword => _driver.FindElement(CreateAccountPasswordLocator);
        private IWebElement CreateAccountConfirmPassword => _driver.FindElement(CreateAccountConfirmPasswordLocator);
        private IWebElement ConfirmCreateAccountButton => _driver.FindElement(ConfirmCreateAccountButtonLocator);

        public CreateAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public void CreateAccount()
        {
            CreateAccountButton.Click();
            CreateAccountFirstName.EnterText(GenerateUsername());
            CreateAccountSecondName.EnterText(GenerateUsername());
            CreateAccountEmail.EnterText(GenerateEmail());
            string generatedPassword = GeneratePassword();
            CreateAccountPassword.EnterText(generatedPassword);
            CreateAccountConfirmPassword.EnterText(generatedPassword);
            ConfirmCreateAccountButton.Click();
        }
        private string GenerateUsername()
        {
            return RandomUserGenerator.GenerateName();
        }

        private string GeneratePassword()
        {
            return RandomUserGenerator.GeneratePassword();
        }

        private string GenerateEmail()
        {
            return RandomUserGenerator.GenerateEmail();
        }
    }
}