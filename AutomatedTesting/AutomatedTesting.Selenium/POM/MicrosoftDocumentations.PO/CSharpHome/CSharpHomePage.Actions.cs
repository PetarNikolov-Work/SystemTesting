namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public partial class CSharpHomePage
    {
        private IWebDriver driver;
        private IJavaScriptExecutor jse;
        public CSharpHomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.jse = (IJavaScriptExecutor)this.driver;

            this.driver.Manage().Window.Maximize();
        }

        public void ScrollPageToElement(int digit)
        {
            this.jse.ExecuteScript("arguments[0].scrollIntoView();", this.LearnToProgramSection);
            Thread.Sleep(digit);
        }

        public void ClickElement(IWebElement element, int digit)
        {
            element.Click();
            Thread.Sleep(digit);
        }
    }
}
