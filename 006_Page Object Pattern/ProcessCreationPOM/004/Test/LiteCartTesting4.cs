using NUnit.Framework;
using PageObjectModelPattern.ProcessCreationPOM._004.Base;
using PageObjectModelPattern.ProcessCreationPOM._004.Pages;

namespace PageObjectModelPattern.ProcessCreationPOM._004.Test
{
    [TestFixture]
    public class LoginExampleTest4 : TestBase
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