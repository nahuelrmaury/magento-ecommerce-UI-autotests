using OpenQA.Selenium;
using TestProject2.Helpers;

namespace TestProject2.Pages
{
    public class LoginPage : BasePage
    {
        private IWebElement SignInButton => _driver.FindElement(By.ClassName("authorization-link"));
        private IWebElement UsernameInput => _driver.FindElement(By.Id("email"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("pass"));
        private IWebElement LoginButton => _driver.FindElement(By.Name("send"));
        private IWebElement WelcomeMessage => _driver.FindElement(By.ClassName("logged-in"));

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

        public (bool, string) IsLoggedIn()
        {
            /* helper method for explicit waits */
            _driver.WaitForElement(By.ClassName("logged-in"), TimeSpan.FromSeconds(10));
            return (WelcomeMessage.Displayed, WelcomeMessage.Text);
        }
    }
}
