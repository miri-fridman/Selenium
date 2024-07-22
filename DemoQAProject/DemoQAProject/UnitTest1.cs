using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemoTests
{
    [TestFixture]
    public class DemoTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            string path = "C:\\�����-����\\Selenium\\DemoQAProject\\DemoQAProject";
            driver = new ChromeDriver(path + @"\drivers\");
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
        }

        [Test]
        public void Test()
        {
            // ����� ����� alert �� �����
            var alertButton = driver.FindElement(By.Id("timerAlertButton"));

            // ����� �� ������
            alertButton.Click();

            // ����� �-alert
            Thread.Sleep(6000);

            // ����� ����� �-alert
            var alert = driver.SwitchTo().Alert();
            var alertText = alert.Text;
            Assert.That(alertText, Is.EqualTo("This alert appeared after 5 seconds"));

            // ����� �-alert
            alert.Accept();
            driver.Navigate().GoToUrl("https://demoqa.com/Browser-Windows");
            //��� �'
            // ����� ������ ������� ������� JavaScript
            var script = "var elements = document.getElementsByTagName('iframe');" +
                            "for (var i = 0; i < elements.length; i++) {" +
                                "if (elements[i].src.indexOf('adframe') > -1) {" +
                                    "elements[i].style.display = 'none';" +
                                "}" +
                            "}";
            ((IJavaScriptExecutor)driver).ExecuteScript(script);


            // ����� ����� ������ ���� ���
            var windowButton = driver.FindElement(By.Id("windowButton"));

            // ����� �� ������
            windowButton.Click();

            // ����� ���� ����� ������
            var currentWindowHandle = driver.WindowHandles[0];

            // ����� ����� ���
            Thread.Sleep(2000);

            // ���� ����� ����
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            // ����� ������ ����� ����
            var newWindowTitle = driver.Title;
            Assert.That(newWindowTitle, Is.EqualTo("New Window"));

            // ����� ����� ����
            driver.Close();

            // ���� ����� ������
            driver.SwitchTo().Window(currentWindowHandle);

        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}