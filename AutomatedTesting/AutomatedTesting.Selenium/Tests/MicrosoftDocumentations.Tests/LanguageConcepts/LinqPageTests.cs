﻿namespace AutomatedTesting.Selenium.Tests.MicrosoftDocumentations.Tests.LanguageConcepts
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
    using System.Xml.Linq;

    [TestFixture]
    public class LinqPageTests
    {
        private const string C_SHARP_HOMEPAGE_URL = "https://learn.microsoft.com/en-us/dotnet/csharp/";

        private List<IWebElement>? hyperlinks;

        private IWebDriver driver;
        private CSharpHomePage homePage;
        private LearnToProgramSection learnToProgramSection;
        private ArticlePage articlePage;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            this.homePage = new CSharpHomePage(this.driver);
            this.learnToProgramSection = new LearnToProgramSection(this.driver);
            this.articlePage = new ArticlePage(this.driver);

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
        public void InThisArticleHyperlinks_ShouldScrollPageTo_SectionsWithEqualNames()
        {
            //Arrange
            this.homePage.ScrollPageToElement(1000);
            this.learnToProgramSection.ScrollPageToElement(this.learnToProgramSection.LanguageConceptsColumnHyperlinks[1], 1000);
            this.learnToProgramSection.ClickElement(this.learnToProgramSection.LanguageConceptsColumnHyperlinks[1], 1000);
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