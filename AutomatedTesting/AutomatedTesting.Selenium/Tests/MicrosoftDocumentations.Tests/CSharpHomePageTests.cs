namespace AutomatedTesting.Selenium.Tests.MicrosoftDocumentations.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.Reflection;
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome;

    [TestFixture]
    public class CSharpHomePageTests : BaseTests
    {
        private CSharpHomePage homePage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.homePage = new CSharpHomePage(base.Driver);
        }

        [TearDown]
        public override void Teardown()
        {
           base.Teardown();
        }

        [Test]
        public void Page_ShouldScrollTo_LearnToProgramSection()
        {
            //Arrange
            IWebElement learnToProgramSection = this.homePage.LearnToProgramSection;

            //Act
            this.homePage.ScrollPageToElement(learnToProgramSection, 2000);

            //Assert
            Assert.That(learnToProgramSection.Displayed);
        }

        [Test]
        public void Page_ShouldHave_ProperUrl()
        {
            //Assert
            Assert.That(base.Driver.Url, Is.EqualTo(C_SHARP_HOMEPAGE_URL));
        }
    }
}
