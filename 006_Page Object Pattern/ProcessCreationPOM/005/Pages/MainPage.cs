using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModelPattern.ProcessCreationPOM._005.Base;

namespace PageObjectModelPattern.ProcessCreationPOM._005.Pages
{
    public class MainPage : PageBase
    {
        private By signIn = By.LinkText("Sign In");
        private By email = By.Name("email");
        private By password = By.Name("password");
        private By login = By.Name("login");
        private By alert = By.CssSelector("#main .alert");


        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void CheckThatAlertMessageContainsText(string message)
        {
            string alertText = GetText(alert);
            Assert.That(alertText.Contains(message));
        }

        public MainPage LoginWithNameAndPassword(string name, string pwd)
        {
            Click(signIn);
            Click(email);
            Clear(email);
            SendKeys(email, name);

            Click(password);
            Clear(password);
            SendKeys(password, pwd);

            Click(login);
            
            return new MainPage(Driver);
        }
    }
}
