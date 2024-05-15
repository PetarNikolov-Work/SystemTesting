namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.AdvancedLanguageConcepts.Sidebar
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class AdvancedTopicsSidebar : BasePage
    {
        public AdvancedTopicsSidebar(IWebDriver driver) : base(driver)
        {

        }

        public void ClickElement(IWebElement element, int digit)
        {
            element.Click();
            Thread.Sleep(digit);
        }
    }
}
