using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace XUnitTestExample
{
    public class Example
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver(@"D:\itvdn\Drivers\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.litecart.net/");
            driver.Close();
        }

           
    }

    public class ExampleTest2 : IDisposable
    {
        IWebDriver driver;

        public ExampleTest2()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            driver.Close();
        }

        [Fact]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://demo.litecart.net/");
        }

        [Fact]
        public void Test3()
        {
            driver.Navigate().GoToUrl("https://google.com/");
        }
    }
}
