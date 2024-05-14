namespace AutomatedTesting.Selenium.Tests.MicrosoftDocumentations.Tests.CSharpHome.Sections.LearnToProgram
{
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome.Sections.LearnToProgram;

    [TestFixture]
    public class LearnToProgramSectionTests
    {
        private const string C_SHARP_HOMEPAGE_URL = "https://learn.microsoft.com/en-us/dotnet/csharp/";

        private static readonly int[] positions = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

        private List<IWebElement>? hyperlinks;

        private IWebDriver driver;
        private CSharpHomePage homePage;
        private LearnToProgramSection learnToProgramSection;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            this.homePage = new CSharpHomePage(this.driver);
            this.learnToProgramSection = new LearnToProgramSection(this.driver);

            this.driver.Navigate().GoToUrl(C_SHARP_HOMEPAGE_URL);
            Thread.Sleep(1000);
            this.homePage.ScrollPageToElement(1000);
        }

        [TearDown]
        public void Teardown()
        {
            this.driver.Quit();
            this.driver.Dispose();
        }

        [Test]
        public void Page_ShouldScrollTo_LearnToProgramColumns_Hyperlinks()
        {
            //Arrange
            this.hyperlinks = this.learnToProgramSection.ColumnHyperlinks.ToList();

            foreach (IWebElement hyperlink in this.hyperlinks)
            {
                this.learnToProgramSection.ScrollPageToElement(hyperlink, 1000);

                //Assert
                Assert.That(hyperlink.Displayed);
            }
        }

        [TestCaseSource(nameof(positions))]
        public void ColumnHyperlinks_ShouldNavigateTo_DifferentWebPage(int position)
        {
            //Arrange
            this.hyperlinks = this.learnToProgramSection.ColumnHyperlinks.ToList();

            //Act
            this.learnToProgramSection.ScrollPageToElement(this.hyperlinks[position], 1000);
            this.learnToProgramSection.ClickElement(this.hyperlinks[position], 2000);

            //Assert
            Assert.That(this.driver.Url, Is.Not.EqualTo(C_SHARP_HOMEPAGE_URL));
        }
    }
}
