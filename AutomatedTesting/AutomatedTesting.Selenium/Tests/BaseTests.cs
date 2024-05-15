namespace AutomatedTesting.Selenium.Tests
{
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class BaseTests
    {
        public const string C_SHARP_HOMEPAGE_URL = "https://learn.microsoft.com/en-us/dotnet/csharp/";

        private IWebDriver driver;

        public virtual void SetUp()
        {
            this.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            this.driver.Navigate().GoToUrl(C_SHARP_HOMEPAGE_URL);
            Thread.Sleep(1000);
        }

        public virtual void Teardown()
        {
            this.driver.Quit();
            this.driver.Dispose();
        }

        protected IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }
    }
}
