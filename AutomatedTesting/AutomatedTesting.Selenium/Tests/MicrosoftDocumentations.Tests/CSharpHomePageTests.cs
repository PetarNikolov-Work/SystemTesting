namespace AutomatedTesting.Selenium.Tests.MicrosoftDocumentations.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.Reflection;
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome;

    [TestFixture]
    public class CSharpHomePageTests
    {
        private const string C_SHARP_HOMEPAGE_URL = "https://learn.microsoft.com/en-us/dotnet/csharp/";

        private IWebDriver driver;
        private CSharpHomePage homePage;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            this.homePage = new CSharpHomePage(this.driver);

            this.driver.Navigate().GoToUrl(C_SHARP_HOMEPAGE_URL);
            Thread.Sleep(1000);
        }

        [TearDown]
        public void Teardown()
        {
            this.driver.Quit();
            this.driver.Dispose();
        }

        [Test]
        public void Page_ShouldScrollTo_LearnToProgramSection()
        {
            //Arrange
            IWebElement learnToProgramSection = this.homePage.LearnToProgramSection;

            //Act
            this.homePage.ScrollPageToElement(2000);

            //Assert
            Assert.That(learnToProgramSection.Displayed);
        }

        [Test]
        public void Page_ShouldHave_ProperUrl()
        {
            //Assert
            Assert.That(this.driver.Url, Is.EqualTo(C_SHARP_HOMEPAGE_URL));
        }
    }
}
