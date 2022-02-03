using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;

namespace _004_WebDriverDifficults
{
    [TestFixture]
    class WaitForPageLoad
    {
        private string htmlPath = Directory.GetCurrentDirectory() + @"\..\..\..\HtmlPages";
        private string driverPath = Directory.GetCurrentDirectory() + @"\..\..\..\Drivers";

        [Test]
        public void WaitExampleScript()
        {
            IWebDriver driver = new ChromeDriver(driverPath);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            driver.Navigate().GoToUrl("file:///"+ htmlPath + "/WaitExamplePage.html");
            
            IWebElement btn = driver.FindElement(By.XPath("//button[@onclick]"));
            btn.Click();

            IWebElement msg = driver.FindElement(By.Id("here"));      
            string msgTxt = msg.Text;
            wait.Until(ExpectedConditions.TextToBePresentInElement(msg, "Hello! I'm here"));
            msgTxt = msg.Text;
            Assert.That(msgTxt == "Hello! I'm here");
            driver.Close();
        }

        [Test]
        public void ExplicitWaitTest() //явное ожидание
        {
            IWebDriver driver = new ChromeDriver(driverPath);
            driver.Url = "https://www.google.com/";
            driver.FindElement(By.Name("q")).SendKeys("wine" + Keys.Enter);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement firstResult = wait.Until( e => e.FindElement(By.XPath("//a/h3")));
            
            Console.WriteLine(firstResult.Text);

            IWebElement element = wait.Until(
                ExpectedConditions.ElementExists(By.XPath("//h3[contains(text(), 'Вікіпедія')]")));

            Console.WriteLine(element.Text);
            driver.Close();
        }

        [Test]
        public void ImplicitWaitTest()
        {
            IWebDriver driver = new ChromeDriver(driverPath);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Url = "https://www.google.com/";
            driver.FindElement(By.Name("q")).SendKeys("wine" + Keys.Enter);
            
            IWebElement firstResult = driver.FindElement(By.XPath("//a/h3"));
            Console.WriteLine(firstResult.Text);
            driver.Close();
        }


    }
}
