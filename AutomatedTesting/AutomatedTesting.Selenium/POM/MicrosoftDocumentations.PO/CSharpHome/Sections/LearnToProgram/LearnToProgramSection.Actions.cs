namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome.Sections.LearnToProgram
{
    using OpenQA.Selenium;
    
    public partial class LearnToProgramSection: BasePage
    {
        public LearnToProgramSection(IWebDriver driver) : base(driver)
        {

        }

        public void ClickElement(IWebElement element, int digit)
        {
            element.Click();
            Thread.Sleep(digit);
        }
    }
}
