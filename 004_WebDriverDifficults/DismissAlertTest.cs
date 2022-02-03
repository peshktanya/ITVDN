using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;

namespace _004_WebDriverDifficults
{
    [TestFixture]
    class DismissAlertTest
    {
        private IWebDriver driver;
        private string htmlPath = Directory.GetCurrentDirectory() + @"\..\..\..\HtmlPages\";
        private string driverPath = Directory.GetCurrentDirectory() + @"\..\..\..\Drivers";

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver(driverPath);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void AcceptAlertScript()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(htmlPath + "AlertPage.html");

            IWebElement btn = driver.FindElement(By.CssSelector("button[onclick]"));
            btn.Click();
      
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string alertText = alert.Text;
            alert.Accept();

            Assert.That(alertText.Contains("Alert Message"));
        }



        [Test]
        public void DismissConfirmScript()
        {
            driver.Navigate().GoToUrl(htmlPath + "ConfirmPage.html");

            IWebElement btn = driver.FindElement(By.CssSelector("button[onclick]"));
            btn.Click();
            
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            alert.Dismiss();

            Assert.That(alertText.Contains("Are you sure?"));
        }

        [Test]
        public void PromptSendTextScript()
        {
            driver.Navigate().GoToUrl(htmlPath + "PromptPage.html");

            IWebElement btn = driver.FindElement(By.CssSelector("button[onclick]"));
            btn.Click();
            
            IAlert alert = driver.SwitchTo().Alert();
            //Type your message
            alert.SendKeys("Hello from autotest");

            //Press the OK button
            alert.Accept();
            
        }
    }
}
