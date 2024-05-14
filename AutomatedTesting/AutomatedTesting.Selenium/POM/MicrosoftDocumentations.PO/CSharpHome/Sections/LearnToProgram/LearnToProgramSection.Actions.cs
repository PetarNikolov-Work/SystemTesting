namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome.Sections.LearnToProgram
{
    using OpenQA.Selenium;
    
    public partial class LearnToProgramSection
    {
        private IWebDriver driver;
        private IJavaScriptExecutor jse;

        public LearnToProgramSection(IWebDriver driver)
        {
            this.driver = driver;
            this.jse = (IJavaScriptExecutor)this.driver;

            this.driver.Manage().Window.Maximize();
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
