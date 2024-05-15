﻿namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.AdvancedLanguageConcepts.Sidebar
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class AdvancedTopicsSidebar
    {
        private IWebDriver driver;
        private IJavaScriptExecutor jse;

        public AdvancedTopicsSidebar(IWebDriver driver)
        {
            this.driver = driver;
            this.jse = (IJavaScriptExecutor)this.driver;
        }

        public void ScrollPageToElement(IWebElement element, int digit)
        {
            this.jse.ExecuteScript("arguments[0].scrollIntoView();", element);
            Thread.Sleep(digit);
        }

        public void ClickElement(IWebElement element, int digit)
        {
            element.Click();
            Thread.Sleep(digit);
        }
    }
}
