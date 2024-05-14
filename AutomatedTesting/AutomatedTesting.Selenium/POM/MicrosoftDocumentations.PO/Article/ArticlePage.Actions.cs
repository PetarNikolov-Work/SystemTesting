namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.Article
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public partial class ArticlePage
    {
        private IWebDriver driver;
        private IJavaScriptExecutor jse;
        public ArticlePage(IWebDriver driver)
        {
            this.driver = driver;
            this.jse = (IJavaScriptExecutor)this.driver;

            this.driver.Manage().Window.Maximize();
        }

        public string GetArticleSectionID(IWebElement element)
        {
            this.jse.ExecuteScript("arguments[0].scrollIntoView();", element);
            Thread.Sleep(1000);
            element.Click();
            Thread.Sleep(2000);

            string hrefAttribute = element.GetAttribute("href");
            string articleSectionID = hrefAttribute.Substring(hrefAttribute.IndexOf('#') + 1);

            return articleSectionID;
        }

        public void ScrollPageToElement(IWebElement element, int digit)
        {
            this.jse.ExecuteScript("arguments[0].scrollIntoView();", element);
            Thread.Sleep(digit);
        }
    }
}
