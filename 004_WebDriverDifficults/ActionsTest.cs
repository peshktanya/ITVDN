using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Drawing;

namespace _004_WebDriverDifficults
{
    [TestFixture]
    public class ActionsTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void UseActionsScript()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Actions action = new Actions(driver);
            
            // Store google search box WebElement
            IWebElement search = driver.FindElement(By.Name("q"));

            action.KeyDown(Keys.Shift)
                .SendKeys(search, "cheese")
                .KeyUp(Keys.Shift)
                .SendKeys(Keys.Enter).Perform();

            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.XPath("//h3[contains(text(), 'Β³κ³οεδ³ÿ')]")));
            Console.WriteLine(element.Text);
        }

        [Test]
        public void ICanPerformActions()
        {
            driver.Navigate().GoToUrl("http://jqueryui.com");
            driver.FindElement(By.XPath("//a[contains(text(), 'Resizable')]")).Click();

            IWebElement frameDraggable = driver.FindElement(By.ClassName("demo-frame"));
            driver.SwitchTo().Frame(frameDraggable);

            IWebElement resizeElement = driver.FindElement(By.Id("resizable"));

            Size size = resizeElement.Size;

            Actions action = new Actions(driver);

            IAction resize = action.MoveToElement(resizeElement, size.Width - 2, size.Height - 2)
                    .ClickAndHold()
                    .MoveByOffset(size.Width + 50, size.Height + 50)
                    .Release()
                    .Build();

            resize.Perform();
        }
    }
}