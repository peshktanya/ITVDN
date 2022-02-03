using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestExample.DemoExamples
{
    class TestCaseExample
    {

        [TestCase(12, 3, ExpectedResult = 4)]
        [TestCase(12, 2, ExpectedResult = 6)]
        [TestCase(12, 4, ExpectedResult = 3)]
        public int DivideTest(int n, int d)
        {
            return n / d;
        }

        [TestCase("https://demo.litecart.net/", "My Store | Online Store", TestName = "Check litecart")]
        [TestCase("https://google.com/", "Google", TestName = "Check Google")]
        [TestCase("https://example.com/", "Example Domain", TestName = "Check example")]
        public void PageTitleShouldBeValid(string url, string expectedTitle)

        {
            IWebDriver driver = new ChromeDriver(@"D:\itvdn\Drivers\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            string title = driver.Title;

            Assert.That(title == expectedTitle);
            driver.Close();
        }
    }


}
