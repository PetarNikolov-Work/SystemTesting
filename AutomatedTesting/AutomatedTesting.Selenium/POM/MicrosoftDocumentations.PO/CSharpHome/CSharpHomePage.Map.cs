namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class CSharpHomePage
    {
        internal IWebElement LearnToProgramSection
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("#product-directory .columns"));
            }
        }

        internal List<IWebElement> FundamentalsColumnHyperlinks
        {
            get
            {
                return this.driver.FindElements(By.CssSelector("#product-cards > div:nth-child(2) > div > ul > li > a")).ToList();
            }
        }
    }
}
