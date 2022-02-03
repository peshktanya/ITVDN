using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_WebDriverDifficults
{
    [TestFixture]
    public class JSExecute
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://selenium.dev");
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ICanExecuteJSFromTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string title = (string)js.ExecuteScript("return document.title");

            //Vertical scroll down 		
            js.ExecuteScript("window.scrollBy(0,3000)");

            Assert.That(title.Contains("Selenium"));
            Assert.That(driver.FindElement(By.LinkText("About Selenium")).Displayed);
        }
    }
}
