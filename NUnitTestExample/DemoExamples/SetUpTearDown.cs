using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace NUnitTestExample.DemoExamples
{

    [TestFixture]
    public class SetupTearDown
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Init()
        {
            Console.WriteLine("-=Init=-");
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            Console.WriteLine("-=CleanUp=-");
            driver.Close();
        }

        [Test(Description = "My google test")]
        public void GoogleTest()
        {
            driver.Navigate().GoToUrl("https://google.com/");

        }

        [Test(Description = "My litecart test")]
        public void LiteCartTest()
        {
            driver.Navigate().GoToUrl("https://demo.litecart.net/");
        }

    }


    public class BaseClass
    {
        [SetUp]
        public void BaseSetUp() 
        { 
            Console.WriteLine("-=Base Init=-"); 
        }
        
        [TearDown]
        public void BaseTearDown() 
        { 
            Console.WriteLine("-=Base CleanUp=-"); 
        }
    }

    [TestFixture]
    public class DerivedClass : BaseClass
    {
        [SetUp]
        public void DerivedSetUp() { Console.WriteLine("--=Derived Init=--"); }

        [TearDown]
        public void DerivedTearDown() { Console.WriteLine("--=Derived CleanUp=--"); }

        [Test]
        public void TestMethod() { Console.WriteLine("Test method"); }
    }
}
