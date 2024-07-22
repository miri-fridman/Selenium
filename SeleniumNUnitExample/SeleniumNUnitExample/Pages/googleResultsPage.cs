using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample.Pages
{
    internal class googleResultsPage
    {
        private IWebDriver driver;
        private IList<IWebElement> Results;
        ReadOnlyCollection<IWebElement> searchResults;
        private WebDriverWait wait;

        public googleResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 

        }

        public bool ResultsDisplayed()
        {
            IWebElement resultsPanel = driver.FindElement(By.Id("search"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => driver.Title.Contains("Selenium WebDriver"));
            searchResults = resultsPanel.FindElements(By.XPath(".//a"));
            return searchResults.Count() > 0;
           
        }
        public string GetFirstResultTitle()
        {
                      string  searchResult=searchResults[0].FindElement(By.ClassName("byrV5b")).Text; 
            int index = searchResult.IndexOf('c');
            searchResult= searchResult.Substring(0, index-4);
            return searchResult;
        }
        public void ClickFirstResult()
        {
            searchResults[0].FindElement(By.TagName("h3")).Click();
        }
    }
}

