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
    public class LinqPageTests : BaseTests
    {
        private const string LINQ_PAGE_URL = "https://learn.microsoft.com/en-us/dotnet/csharp/linq/";

        private List<IWebElement>? hyperlinks;

        private CSharpHomePage homePage;
        private LearnToProgramSection learnToProgramSection;
        private ArticlePage articlePage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.homePage = new CSharpHomePage(base.Driver);
            this.learnToProgramSection = new LearnToProgramSection(base.Driver);
            this.articlePage = new ArticlePage(base.Driver);

            //Arrange
            this.homePage.ScrollPageToElement(this.homePage.LearnToProgramSection, 1000);

            //Act
            this.learnToProgramSection.ScrollPageToElement(this.learnToProgramSection.LanguageConceptsColumnHyperlinks[1], 1000);
            this.learnToProgramSection.ClickElement(this.learnToProgramSection.LanguageConceptsColumnHyperlinks[1], 1000);
        }

        [TearDown]
        public override void Teardown()
        {
            base.Teardown();
        }

        [Test]
        public void HomePageHyperlink_ShouldNavigateTo_LinqPage()
        {
            //Assert
            Assert.That(base.Driver.Url, Is.EqualTo(LINQ_PAGE_URL));
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
