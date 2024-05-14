namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome.Sections.LearnToProgram
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public partial class LearnToProgramSection
    {
        internal List<IWebElement> GetStartedColumnHyperlinks
        {
            get
            {
                return this.driver.FindElements(By.CssSelector("#product-cards > div:nth-child(1) > div > ul > li > a")).ToList();
            }
        }

        internal List<IWebElement> FundamentalsColumnHyperlinks
        {
            get
            {
                return this.driver.FindElements(By.CssSelector("#product-cards > div:nth-child(2) > div > ul > li > a")).ToList();
            }
        }

        internal List<IWebElement> LanguageConceptsColumnHyperlinks
        {
            get
            {
                return this.driver.FindElements(By.CssSelector("#product-cards > div:nth-child(3) > div > ul > li > a")).ToList();
            }
        }

        internal List<IWebElement> AdvancedLanguageConceptsColumnHyperlinks
        {
            get
            {
                return this.driver.FindElements(By.CssSelector("#product-cards > div:nth-child(4) > div > ul > li > a")).ToList();
            }
        }

        internal List<IWebElement> ColumnHyperlinks
        {
            get
            {
                return this.driver.FindElements(By.CssSelector("#product-cards > div > div > ul > li > a")).ToList();
            }
        }
    }
}
