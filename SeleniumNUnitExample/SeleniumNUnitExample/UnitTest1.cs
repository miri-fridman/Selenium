using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumNUnitExample.Pages; 

namespace SeleniumNUnitExample
{
    [TestFixture]

    public class GoogleSearchTest
    {

        private IWebDriver driver;
        private googleHomePage googleHomePage;
        private googleResultsPage googleResultsPage;
        public GoogleSearchTest() { }

        [OneTimeSetUp]
        public void Setup()
        {

            string path = "C:\\תכנות-מירי\\שנה ב\\Selenium\\SeleniumNUnitExample\\SeleniumNUnitExample";
            driver = new ChromeDriver(path + @"\drivers\");
            googleHomePage = new googleHomePage(driver);
            googleResultsPage = new googleResultsPage(driver);
        }

        [Test]
        public void Test()
        {
            googleHomePage.navigateTo("https://www.google.com/");
            Assert.AreEqual("Google", driver.Title);
            googleHomePage.search();
            googleResultsPage.ResultsDisplayed();
            // Verify that results are displayed
            Assert.IsTrue(googleResultsPage.ResultsDisplayed());

            //// Get the title of the first result and click it
            string firstResultTitle = googleResultsPage.GetFirstResultTitle();
            googleResultsPage.ClickFirstResult();

            //IWebElement results = driver.FindElement(By.Id("search"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => driver.Url.Equals("https://www.selenium.dev/documentation/webdriver/"));



            //// Verify the title of the new page
            Assert.IsTrue(driver.Url.Equals("https://www.selenium.dev/documentation/webdriver/"));

            //// Navigate back to the Google search results page
            driver.Navigate().Back();

            // Verify the search box still contains the search term
            Assert.AreEqual("Selenium WebDriver", driver.FindElement(By.Name("q")).GetAttribute("value"));

        }
        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Dispose();

        }
    }
}