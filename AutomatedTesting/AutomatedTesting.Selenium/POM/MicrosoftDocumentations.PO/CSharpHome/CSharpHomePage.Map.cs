﻿namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome
{
    using OpenQA.Selenium;
   
    public partial class CSharpHomePage
    {
        internal IWebElement LearnToProgramSection
        {
            get
            {
                return base.FindElement(By.CssSelector("#product-directory .columns"));
            }
        }
    }
}
