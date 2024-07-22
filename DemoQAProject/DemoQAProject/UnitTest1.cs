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
            string path = "C:\\תכנות-מירי\\Selenium\\DemoQAProject\\DemoQAProject";
            driver = new ChromeDriver(path + @"\drivers\");
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
        }

        [Test]
        public void Test()
        {
            // איתור כפתור alert עם השהיה
            var alertButton = driver.FindElement(By.Id("timerAlertButton"));

            // לחיצה על הכפתור
            alertButton.Click();

            // המתנה ל-alert
            Thread.Sleep(6000);

            // בדיקת הופעת ה-alert
            var alert = driver.SwitchTo().Alert();
            var alertText = alert.Text;
            Assert.That(alertText, Is.EqualTo("This alert appeared after 5 seconds"));

            // אישור ה-alert
            alert.Accept();
            driver.Navigate().GoToUrl("https://demoqa.com/Browser-Windows");
            //חלק ב'
            // הסתרת מודעות מפריעות באמצעות JavaScript
            var script = "var elements = document.getElementsByTagName('iframe');" +
                            "for (var i = 0; i < elements.length; i++) {" +
                                "if (elements[i].src.indexOf('adframe') > -1) {" +
                                    "elements[i].style.display = 'none';" +
                                "}" +
                            "}";
            ((IJavaScriptExecutor)driver).ExecuteScript(script);


            // איתור כפתור לפתיחת חלון חדש
            var windowButton = driver.FindElement(By.Id("windowButton"));

            // לחיצה על הכפתור
            windowButton.Click();

            // שמירת מזהה החלון הנוכחי
            var currentWindowHandle = driver.WindowHandles[0];

            // המתנה לחלון חדש
            Thread.Sleep(2000);

            // מעבר לחלון החדש
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            // בדיקת הכותרת בחלון החדש
            var newWindowTitle = driver.Title;
            Assert.That(newWindowTitle, Is.EqualTo("New Window"));

            // סגירת החלון החדש
            driver.Close();

            // חזרה לחלון המקורי
            driver.SwitchTo().Window(currentWindowHandle);

        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}