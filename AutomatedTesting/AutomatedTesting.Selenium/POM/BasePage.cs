namespace AutomatedTesting.Selenium.POM
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class BasePage
    {
        private IWebDriver driver;
        private IJavaScriptExecutor jse;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.jse = (IJavaScriptExecutor)this.driver;

            this.driver.Manage().Window.Maximize();
        }

        protected internal IWebElement FindElement(By by)
        {
            return this.driver.FindElement(by);
        }

        protected internal IEnumerable<IWebElement> FindElements(By by)
        {
            return this.driver.FindElements(by);
        }

        public void ScrollPageToElement(IWebElement element, int digit)
        {
            this.jse.ExecuteScript("arguments[0].scrollIntoView();", element);
            Thread.Sleep(digit);
        }
    }
}
