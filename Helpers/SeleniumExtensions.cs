using OpenQA.Selenium;

namespace TestProject2.Helpers
{
    public static class SeleniumExtensions
    {

        public static void Click(IWebElement element)
        {
            element.Click();
        }

        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
