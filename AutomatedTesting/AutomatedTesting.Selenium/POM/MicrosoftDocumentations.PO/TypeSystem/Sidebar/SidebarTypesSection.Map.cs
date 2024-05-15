namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.TypeSystem.Sidebar
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class SidebarTypesSection
    {
        public IWebElement RecordsHyperlink 
        { 
            get
            {
                return base.FindElement(By.CssSelector("#title-3-1_2-2 > ul > li:nth-child(4) > a"));
            }
        }
    }
}
