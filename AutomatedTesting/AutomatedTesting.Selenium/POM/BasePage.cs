namespace AutomatedTesting.Selenium.POM
{
    using NUnit.Framework.Interfaces;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing.Imaging;

    public abstract class BasePage
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

        public void ScrollPageToElement(IWebElement element, double milliSeconds)
        {
            this.jse.ExecuteScript("arguments[0].scrollIntoView();", element);
            this.DelayPage(milliSeconds);
        }

        public void DelayPage(double milliSeconds)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromMilliseconds((double)milliSeconds));
            DateTime now = DateTime.Now;

            wait.Until(wd => (DateTime.Now - now) - TimeSpan.FromMilliseconds((double)milliSeconds) > TimeSpan.Zero);
        }
    }
}
