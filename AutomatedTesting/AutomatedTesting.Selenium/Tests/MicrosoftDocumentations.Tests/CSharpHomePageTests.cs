namespace AutomatedTesting.Selenium.Tests.MicrosoftDocumentations.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Chrome;
    using System.Reflection;
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome;
    using OpenQA.Selenium.DevTools.V122.Debugger;

    [TestFixture]
    public class CSharpHomePageTests
    {
        private const string C_SHARP_HOMEPAGE_URL = "https://learn.microsoft.com/en-us/dotnet/csharp/";

        private static readonly int[] positions = [0, 1, 2, 3, 4, 5 ];

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

        [Test]
        public void CSharpHomePage_ShouldHave_ProperUrl()
        {
            //Assert
            Assert.That(this.driver.Url, Is.EqualTo(C_SHARP_HOMEPAGE_URL));
        }

        [Test]
        public void CSharpHomePage_ShouldScrollTo_LearnToProgramSection()
        {
            //Arrange
            IWebElement learnToProgramSection = this.homePage.LearnToProgramSection;

            //Act
            this.homePage.ScrollPageToElement(2000);

            //Assert
            Assert.That(learnToProgramSection.Displayed);
        }

        [TestCaseSource(nameof(positions))]
        public void LearnToProgramSection_FundamentalsColumnHyperlinks_ShouldNavigateTo_DifferentWebPage(int position)
        {
            //Arrange
            List<IWebElement> hyperlinks = this.homePage.FundamentalsColumnHyperlinks.ToList();

            if (position >= hyperlinks.Count)
            {
                throw new ArgumentException(nameof(ArgumentException));
            }
            else 
            {
                //Act
                this.homePage.ScrollPageToElement(1000);
                this.homePage.ClickElement(hyperlinks[position], 3000);

                //Assert
                Assert.That(this.driver.Url, Is.Not.EqualTo(C_SHARP_HOMEPAGE_URL));
            }
        }

        [TearDown]
        public void Teardown()
        {
            this.driver.Quit();
            this.driver.Dispose();
        }
    }
}
