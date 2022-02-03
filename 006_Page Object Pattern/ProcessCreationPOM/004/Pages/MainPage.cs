using NUnit.Framework;
using OpenQA.Selenium;


namespace PageObjectModelPattern.ProcessCreationPOM._004.Pages
{
    public class MainPage
    {
        private IWebDriver Driver;
        private By signIn = By.LinkText("Sign In");
        private By email = By.Name("email");
        private By password = By.Name("password");
        private By login = By.Name("login");
        private By alert = By.CssSelector(".alert-success");


        public MainPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void CheckThatAlertMessageContainsText(string message)
        {            
            Assert.That(Driver.FindElement(alert).Text.Contains(message));
        }

        public MainPage LoginWithNameAndPassword(string name, string pwd)
        {
            Driver.FindElement(signIn).Click();
            Driver.FindElement(email).Clear();
            Driver.FindElement(email).SendKeys(name);
            Driver.FindElement(password).Clear();
            Driver.FindElement(password).SendKeys(pwd);
            Driver.FindElement(login).Click();
            return new MainPage(Driver);
        }
    }
}
