using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace _004_WebDriverDifficults
{
    [TestFixture]
    public class WaitTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            string loginName = "standard_user";
            string password = "secret_sauce";

            IWebElement loginBtn = driver.FindElement(By.Id("login-button"));
            IWebElement userNameBtn = driver.FindElement(By.Id("user-name"));
            IWebElement passwordBtn = driver.FindElement(By.Id("password"));

            userNameBtn.SendKeys(loginName);
            passwordBtn.SendKeys(password);

            loginBtn.Click();
            IWebElement jacketLabel = driver.FindElement(By.XPath("//div[@class='inventory_item_name' and contains(text(), 'Jacket')]"));
            jacketLabel.Click();

            //Asert
            Assert.That(driver.FindElement(By.CssSelector(".shopping_cart_link")).Displayed);
            
            
            
        }
    }
}