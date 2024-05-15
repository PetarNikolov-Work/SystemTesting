namespace AutomatedTesting.Selenium.POM.MicrosoftDocumentations.PO.Article
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class ArticlePage
    {
        public List<IWebElement> InThisArticleHyperlinks
        {
            get
            {
                return base.FindElements(By.CssSelector("#content-well-in-this-article-list > li > a")).ToList();
            }
        }

        public IWebElement ArticleSection(string articleSectionID)
        {
            return base.FindElement(By.Id(articleSectionID));
        }
    }
}
