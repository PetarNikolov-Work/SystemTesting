namespace AutomatedTesting.Selenium.Tests.MicrosoftDocumentations.Tests.AdvancedLanguageConcepts
{
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.Article;
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome.Sections.LearnToProgram;
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.CSharpHome;
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.TypeSystem.Sidebar;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.AdvancedLanguageConcepts.Sidebar;

    [TestFixture]
    public class BuildExpressionsArticlePageTests
    {
        private const string C_SHARP_HOMEPAGE_URL = "https://learn.microsoft.com/en-us/dotnet/csharp/";
        private const string BUILD_EXPRESSIONS_ARTICLE_PAGE_URL = "https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/expression-trees/expression-trees-building";

        private List<IWebElement>? hyperlinks;

        private IWebDriver driver;
        private CSharpHomePage homePage;
        private LearnToProgramSection learnToProgramSection;
        private AdvancedTopicsSidebar advancedTopicsSidebar;
        private ArticlePage articlePage;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            this.homePage = new CSharpHomePage(this.driver);
            this.learnToProgramSection = new LearnToProgramSection(this.driver);
            this.advancedTopicsSidebar = new AdvancedTopicsSidebar(this.driver);
            this.articlePage = new ArticlePage(this.driver);

            this.driver.Navigate().GoToUrl(C_SHARP_HOMEPAGE_URL);
            Thread.Sleep(1000);

            //Arrange
            this.homePage.ScrollPageToElement(1000);

            //Act
            this.learnToProgramSection.ScrollPageToElement(this.learnToProgramSection.AdvancedLanguageConceptsColumnHyperlinks[2], 1000);
            this.learnToProgramSection.ClickElement(this.learnToProgramSection.AdvancedLanguageConceptsColumnHyperlinks[2], 1000);
            this.advancedTopicsSidebar.ScrollPageToElement(this.advancedTopicsSidebar.BuildExpressionsHyperlink, 1000);
            this.advancedTopicsSidebar.ClickElement(this.advancedTopicsSidebar.BuildExpressionsHyperlink, 1000);
        }

        [TearDown]
        public void Teardown()
        {
            this.driver.Quit();
            this.driver.Dispose();
        }

        [Test]
        public void HomePageHyperlink_ShouldNavigateTo_BuildExpressionsArticlePage()
        {
            //Assert
            Assert.That(this.driver.Url, Is.EqualTo(BUILD_EXPRESSIONS_ARTICLE_PAGE_URL));
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
