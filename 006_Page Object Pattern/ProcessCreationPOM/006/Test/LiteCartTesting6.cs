using NUnit.Framework;
using PageObjectModelPattern.ProcessCreationPOM._006.Base;
using PageObjectModelPattern.ProcessCreationPOM._006.Pages;

namespace PageObjectModelPattern.ProcessCreationPOM._006.Test
{
    [TestFixture]
    public class LoginExampleTest6 : TestBase
    {

        [Test]
        public void WhenLoginWithValidNameAndPassword_SuccessMessageShouldAppear()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.LoginWithNameAndPassword("user@email.com", "demo");
            mainPage.CheckThatAlertMessageContainsText("logged in as John Doe.");
        }
    }
}