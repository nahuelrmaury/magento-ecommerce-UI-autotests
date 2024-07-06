using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject2.Helpers
{
    public static class WebDriverExtensions
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By by, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            return wait.Until(ExpectedConditions.ElementExists(by));
        }
    }
}
