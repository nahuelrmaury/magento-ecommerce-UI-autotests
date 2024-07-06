using OpenQA.Selenium;

namespace TestProject2.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver { get; private set; }

        public BasePage(IWebDriver driver)
        { 
            _driver = driver;
        }

    }
}
