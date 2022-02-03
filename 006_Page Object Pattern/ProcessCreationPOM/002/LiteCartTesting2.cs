using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace PageObjectModelPattern.ProcessCreationPOM
{
    [TestFixture]
    public class LoginExampleTest2
    {

        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.litecart.net/");

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }

        [Test]
        public void WhenLoginWithValidNameAndPassword_SuccessMessageShouldAppear()
        {
            LoginWithNameAndPassword("user@email.com", "demo");
            CheckThatAlertMessageContainsText("logged in as John Doe.");
        }

        public void CheckThatAlertMessageContainsText(string message)
        {
            Assert.That(driver.FindElement(By.CssSelector(".alert-success")).Text.Contains(message));
        }

        public void LoginWithNameAndPassword(string name, string pwd)
        {
            driver.FindElement(By.LinkText("Sign In")).Click();
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(name);
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(pwd);
            driver.FindElement(By.Name("login")).Click();
        }

    }
}