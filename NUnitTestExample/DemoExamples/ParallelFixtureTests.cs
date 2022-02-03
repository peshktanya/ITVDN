using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace NUnitTestExample.DemoExamples
{
   
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class Parallel2Fixture
    {
        
        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.litecart.net/");
            driver.Close();
        }

        [Test]
        public void Test2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.litecart.net/");
            driver.Close();
        }

        [NonParallelizable]
        [Test]
        public void Test3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.litecart.net/");
            driver.Close();
        }
    }

    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class Parallel3Fixture
    {

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.litecart.net/");
            driver.Close();
        }

        [Test]
        public void Test2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.litecart.net/");
            driver.Close();
        }

        [NonParallelizable]
        [Test]
        public void Test3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.litecart.net/");
            driver.Close();
        }

    }

    
}