using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace PageObjectModelPattern.ProcessCreationPOM._003
{
    public class MainPage
    {
        private IWebDriver Driver;

        public MainPage(IWebDriver driver)
        {
           Driver = driver;
        }

        public void CheckThatAlertMessageContainsText(string message)
        {
            Assert.That(Driver.FindElement(By.CssSelector(".alert-success")).Text.Contains(message));
        }

        public void LoginWithNameAndPassword(string name, string pwd)
        {
            Driver.FindElement(By.LinkText("Sign In")).Click();
            Driver.FindElement(By.Name("email")).Click();
            Driver.FindElement(By.Name("email")).Clear();
            Driver.FindElement(By.Name("email")).SendKeys(name);
            Driver.FindElement(By.Name("password")).Click();
            Driver.FindElement(By.Name("password")).Clear();
            Driver.FindElement(By.Name("password")).SendKeys(pwd);
            Driver.FindElement(By.Name("login")).Click();
        }
    }
}
