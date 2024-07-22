using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample.Pages
{
    public class googleHomePage
    {
        private IWebDriver driver;
        public googleHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement searchBox => driver.FindElement(By.Name("q"));
        public void navigateTo(string url)
        {
            driver.Navigate().GoToUrl(url); 
        } 
        public void search()
        {
            searchBox.SendKeys("Selenium WebDriver");
            searchBox.Submit();
        }
    }
}
