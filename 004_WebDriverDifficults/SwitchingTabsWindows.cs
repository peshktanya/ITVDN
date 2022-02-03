using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace _004_WebDriverDifficults
{
    [TestFixture]
    public class SwitchingTabsWindows
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://google.com");
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void CreateNewWindowOrTabAndSwitchTest()
        {
            // Opens a new tab and switches to new tab
            driver.SwitchTo().NewWindow(WindowType.Tab);

            // Opens a new window and switches to new window
            driver.SwitchTo().NewWindow(WindowType.Window);
        }       

        [Test]
        public void ICanSwitchToNewTabTest()
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
            var tabs = driver.WindowHandles;
            driver.Navigate().GoToUrl("http://google.com");
            driver.SwitchTo().Window(tabs[0]);
            driver.Navigate().GoToUrl("http://gmail.com");
        }

        [Test]
        public void ICanSwitchToSecondWindowTest()
        {
            string firstWindowId = driver.CurrentWindowHandle;

            //Open new window
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.open();");

            //Switch to new window opened
            var windows = driver.WindowHandles;
            foreach (var id in windows)
            {
                if (!id.Contains(firstWindowId))
                {
                    driver.SwitchTo().Window(id);
                }
            }

            // Perform the actions on new window
            driver.Navigate().GoToUrl("https://gmail.com");
            driver.Close();

            // Switch back to original browser (first window)
            driver.SwitchTo().Window(firstWindowId);
            driver.Navigate().GoToUrl("https://gmail.com");
        }
    }
}
