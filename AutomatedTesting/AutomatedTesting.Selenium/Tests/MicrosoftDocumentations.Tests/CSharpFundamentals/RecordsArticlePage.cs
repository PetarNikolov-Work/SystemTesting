namespace AutomatedTesting.Selenium.Tests.MicrosoftDocumentations.Tests.CSharpFundamentals
{
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.Article;
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome.Sections.LearnToProgram;
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.TypeSystem.Sidebar;

    [TestFixture]
    public class RecordsArticlePage : BaseTests
    {
        private const string RECORDS_ARTICLE_PAGE_URL = "https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records";

        private List<IWebElement>? hyperlinks;

        private CSharpHomePage homePage;
        private LearnToProgramSection learnToProgramSection;
        private SidebarTypesSection sidebarTypesSection;
        private ArticlePage articlePage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.homePage = new CSharpHomePage(base.Driver);
            this.learnToProgramSection = new LearnToProgramSection(base.Driver);
            this.sidebarTypesSection = new SidebarTypesSection(base.Driver);
            this.articlePage = new ArticlePage(base.Driver);

            //Arrange
            this.homePage.ScrollPageToElement(this.homePage.LearnToProgramSection, 1000);

            //Act
            this.learnToProgramSection.ScrollPageToElement(this.learnToProgramSection.FundamentalsColumnHyperlinks[0], 1000);
            this.learnToProgramSection.ClickElement(this.learnToProgramSection.FundamentalsColumnHyperlinks[0], 1000);
            this.sidebarTypesSection.ScrollPageToElement(this.sidebarTypesSection.RecordsHyperlink, 1000);
            this.sidebarTypesSection.ClickElement(this.sidebarTypesSection.RecordsHyperlink, 1000);
        }

        [TearDown]
        public override void Teardown()
        {
            base.Teardown();
        }

        [Test]
        public void HomePageHyperlink_ShouldNavigateTo_RecordsArticlePage()
        {
            //Assert
            Assert.That(base.Driver.Url, Is.EqualTo(RECORDS_ARTICLE_PAGE_URL));
        }

        [Test]
        public void InThisArticleHyperlinks_ShouldScrollPageTo_SectionsWithEqualNames()
        {
            this.hyperlinks = this.articlePage.InThisArticleHyperlinks;

            foreach (IWebElement navigationHyperlink in this.hyperlinks)
            {
                //Act
                string articleSectionID = this.articlePage.GetArticleSectionID(navigationHyperlink);
                IWebElement articleSection = this.articlePage.ArticleSection(articleSectionID);

                this.articlePage.ScrollPageToElement(navigationHyperlink, 3000);

                //Assert
                Assert.That(navigationHyperlink.Text, Is.EqualTo(articleSection.Text));
                Assert.That(articleSection.Displayed);
                Assert.That(articleSection.TagName.Contains("h2"));
            }
        }
    }
}
