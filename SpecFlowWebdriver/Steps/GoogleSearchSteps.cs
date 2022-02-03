using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowWebdriver.Steps
{
    [Binding]
    public class GoogleSearchSteps
    {
        private WebDriverWait wait;
        private IWebDriver driver;

        private void SetUpDriver()
        {
            driver = new ChromeDriver(@"D:\itvdn\Drivers\");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private void CloseDriver()
        {
            driver.Close();
        }

        [Given(@"open search page")]
        public void GivenOpenSearchPage()
        {
            SetUpDriver();
            driver.Url = "https://google.com";

        }

        [When(@"type (.*) and click search")]
        public void WhenTypeAndClickSearch(string text)
        {
            driver.FindElement(By.Name("q")).SendKeys(text + Keys.Enter);
        }

        [Then(@"the result should contain (.*)")]
        public void ThenTheResultShouldContain(string text)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.XPath($"//h3[contains(text(), '{text}')]")));
            Assert.That(element.Text.Contains(text));

            CloseDriver();
        }
    }
}
