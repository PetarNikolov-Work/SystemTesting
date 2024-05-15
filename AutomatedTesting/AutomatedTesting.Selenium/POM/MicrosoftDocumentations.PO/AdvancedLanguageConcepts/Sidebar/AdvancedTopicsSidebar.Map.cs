namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.AdvancedLanguageConcepts.Sidebar
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class AdvancedTopicsSidebar
    {
        public IWebElement BuildExpressionsHyperlink
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("#title-10-1_3-2 > ul > li:nth-child(6) > a"));
            }
        }
    }
}
