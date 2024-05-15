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

    public partial class ArticlePage : BasePage
    {
        public ArticlePage(IWebDriver driver) : base(driver)
        {

        }

        public string GetArticleSectionID(IWebElement element)
        {
            base.ScrollPageToElement(element, 1000);
            element.Click();
            Thread.Sleep(2000);

            string hrefAttribute = element.GetAttribute("href");
            string articleSectionID = hrefAttribute.Substring(hrefAttribute.IndexOf('#') + 1);

            return articleSectionID;
        }
    }
}
