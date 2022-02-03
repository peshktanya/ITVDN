using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectModelPattern.ProcessCreationPOM._006.Pages
{
    public class MainPage
    {
        public IWebDriver Driver;

        [FindsBy(How = How.LinkText, Using = "Sign In")]
        public IWebElement signIn { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement email { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='login' and text()='Sign In']")]
        private IWebElement login { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main .alert")]
        private IWebElement alert { get; set; }

        public MainPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void CheckThatAlertMessageContainsText(string message)
        {
            Assert.That(alert.Text.Contains(message));
        }

        public MainPage LoginWithNameAndPassword(string name, string pwd)
        {
            signIn.Click();
            email.Clear();
            email.SendKeys(name);

            password.Clear();
            password.SendKeys(pwd);

            login.Click();
            return new MainPage(Driver);
        }
    }
}
