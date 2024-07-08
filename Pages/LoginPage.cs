using OpenQA.Selenium;
using TestProject2.Helpers;

namespace TestProject2.Pages
{
    public class LoginPage : BasePage
    {

        private readonly int TimeoutSeconds = 10;

        // Locators
        private By SignInButtonLocator = By.ClassName("authorization-link");
        private By UsernameInputLocator = By.Id("email");
        private By PasswordInputLocator = By.Id("pass");
        private By LoginButtonLocator = By.Name("send");
        private By WelcomeMessageLocator = By.ClassName("logged-in");
        private By ProfileDropdownButtonLocator = By.CssSelector("div[class='panel header'] button[type='button']");
        private By SignOutMessageLocator = By.ClassName("base");
        private By CredentialInvalidMessageLocator = By.CssSelector("div[data-bind='html: $parent.prepareMessageForHtml(message.text)']");
        private By CreatedAccountMessageLocator = By.CssSelector("div[data-bind='html: $parent.prepareMessageForHtml(message.text)']");


        // Web Elements
        private IWebElement SignInButton => _driver.FindElement(SignInButtonLocator);
        private IWebElement UsernameInput => _driver.FindElement(UsernameInputLocator);
        private IWebElement PasswordInput => _driver.FindElement(PasswordInputLocator);
        private IWebElement LoginButton => _driver.FindElement(LoginButtonLocator);
        private IWebElement WelcomeMessage => _driver.FindElement(WelcomeMessageLocator);
        private IWebElement ProfileDropdownButton => _driver.FindElement(ProfileDropdownButtonLocator);
        private IWebElement SignOutMessage => _driver.FindElement(SignOutMessageLocator);
        private IWebElement CredentialInvalidMessage => _driver.FindElement(CredentialInvalidMessageLocator);
        private IWebElement CreatedAccountMessage => _driver.FindElement(CreatedAccountMessageLocator);

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void Login(string username, string password)
        {
            SignInButton.Click();
            UsernameInput.EnterText(username);
            PasswordInput.EnterText(password);
            LoginButton.Click();
        }

        private (bool, string) WaitForElementAndGetText(By locator)
        {
            try
            {
                _driver.WaitForElement(locator, TimeSpan.FromSeconds(TimeoutSeconds));
                return (true, _driver.FindElement(locator).Text);
            }
            catch (WebDriverTimeoutException)
            {
                return (false, string.Empty);
            }
        }

        public (bool, string) IsLoggedIn()
        {
            return WaitForElementAndGetText(WelcomeMessageLocator);
        }

        public bool IsLoggedOut()
        {
            return WaitForElementAndGetText(SignOutMessageLocator).Item1;
        }

        public (bool, string) IsCredentialInvalid()
        {
            return WaitForElementAndGetText(CredentialInvalidMessageLocator);
        }

        public void Logout()
        {
            ProfileDropdownButton.Click();
            SignInButton.Click();
        }

        public (bool, string) IsAccountCreated()
        {
            return WaitForElementAndGetText(CreatedAccountMessageLocator);

        }

    }
}
